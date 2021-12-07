// Copyright 2021 Keyfactor
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

using System;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Keyfactor.Extensions.Pam.BeyondInsight.PasswordSafe
{
    public class Client : IDisposable
    {
        private string _apiKey;
        private string _username;
        private string _url;
        private bool _sessionStarted = false;
        
        private HttpClient _httpClient { get; }
        private readonly JsonSerializerSettings serializerSettings = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore
        };

        public Client(string url, string username, string apiKey)
        {
            _url = url;
            _username = username;
            _apiKey = apiKey;
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(url);
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"PS-Auth key={apiKey} runas={username}");
        }

        public async Task<int> RequestCredential(string systemId, string accountId)
        {
            API.NewRequest credentialRequest = new API.NewRequest
            {
                SystemID = int.Parse(systemId),
                AccountID = int.Parse(accountId),
                DurationMinutes = 2,
                Reason = "Automated request for Keyfactor PAM Provider plugin"
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(credentialRequest, serializerSettings), Encoding.UTF8, "application/json");
            HttpResponseMessage response = await _httpClient.PostAsync("Requests", content);
            API.CreatedRequest credentialRequestResponse = await GetResponseAsync<API.CreatedRequest>(response);

            return credentialRequestResponse.RequestID; 
        }

        public async Task<string> RetrieveCredential(int requestId)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"Credentials/{requestId}");
            API.Credential credential = await GetResponseAsync<API.Credential>(response);
            return credential.Credentials;
        }

        public async Task<bool> StartPlatformAccess()
        {
            HttpResponseMessage response = await _httpClient.PostAsync("Auth/SignAppin", null);
            API.UserSession session = await GetResponseAsync<API.UserSession>(response);
            return true; // if reached, platform session was started successfully
        }

        private async void EndPlatformAccess()
        {
            HttpResponseMessage response = await _httpClient.PostAsync("Auth/Signout", null);
            EnsureSuccessfulResponse(response, await response.Content.ReadAsStreamAsync());
        }

        private async Task<T> GetResponseAsync<T>(HttpResponseMessage response)
        {
            Stream content = await response.Content.ReadAsStreamAsync();
            EnsureSuccessfulResponse(response, content);
            string stringResponse = new StreamReader(content).ReadToEnd();
            return JsonConvert.DeserializeObject<T>(stringResponse);
        }

        private void EnsureSuccessfulResponse(HttpResponseMessage response, Stream content)
        {
            if (!response.IsSuccessStatusCode)
            {
                string error = new StreamReader(content).ReadToEnd();
                throw new Exception($"Request to Beyond Insight Password Safe was not successful - {response.StatusCode} - {error}");
            }
        }

        public void Dispose()
        {
            EndPlatformAccess();
            _httpClient.Dispose();
        }
    }
}