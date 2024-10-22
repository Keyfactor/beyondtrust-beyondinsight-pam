// Copyright 2023 Keyfactor
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
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Newtonsoft.Json;

namespace Keyfactor.Extensions.Pam.BeyondInsight.PasswordSafe
{
    public class Client : IDisposable
    {        
        private HttpClient _httpClient { get; }
        private readonly JsonSerializerSettings serializerSettings = new JsonSerializerSettings()
        {
            NullValueHandling = NullValueHandling.Ignore
        };

        public Client(string url, string username, string apiKey, X509Certificate2 clientCert = null)
        {
            var handler = new HttpClientHandler();
            if (clientCert != null)
            {
                handler.ClientCertificates.Add(clientCert);
            }
#if DEBUG
            handler.ServerCertificateCustomValidationCallback = (a, b, c, d) => { return true; };
#endif

            _httpClient = new HttpClient(handler);
            _httpClient.BaseAddress = new Uri(url);
            _httpClient.Timeout = TimeSpan.FromSeconds(30);
            _httpClient.DefaultRequestHeaders.Add("Authorization", $"PS-Auth key={apiKey}; runas={username};");
            _httpClient.DefaultRequestHeaders.Add("ContentType", "application/json");
        }

        public API.ManagedAccount GetAccount(string systemName, string accountName)
        {
            HttpResponseMessage response = _httpClient.GetAsync($"ManagedAccounts?systemName={systemName}&accountName={accountName}").Result;
            API.ManagedAccount account = GetResponse<API.ManagedAccount>(response);

            return account;
        }

        public int RequestCredential(int systemId, int accountId)
        {
            API.NewRequest credentialRequest = new API.NewRequest
            {
                SystemID = systemId,
                AccountID = accountId,
                DurationMinutes = 1,
                ConflictOption = "reuse",
                Reason = "Automated request for Keyfactor PAM Provider plugin"
            };

            StringContent content = new StringContent(JsonConvert.SerializeObject(credentialRequest, serializerSettings), Encoding.UTF8, "application/json");
            HttpResponseMessage response = _httpClient.PostAsync("Requests", content).Result;
            int credentialRequestResponse = GetResponse<int>(response);

            return credentialRequestResponse; 
        }

        public string RetrieveCredential(int requestId)
        {
            HttpResponseMessage response = _httpClient.GetAsync($"Credentials/{requestId}").Result;
            string credential = GetResponse<string>(response);
            return credential;
        }

        public bool StartPlatformAccess()
        {
            HttpResponseMessage response = _httpClient.PostAsync("Auth/SignAppin", null).Result;
            API.UserSession session = GetResponse<API.UserSession>(response);
            return true; // if reached, platform session was started successfully
        }

        private void EndPlatformAccess()
        {
            HttpResponseMessage response = _httpClient.PostAsync("Auth/Signout", null).Result;
            EnsureSuccessfulResponse(response, response.Content.ReadAsStreamAsync().Result);
        }

        private T GetResponse<T>(HttpResponseMessage response)
        {
            Stream content = response.Content.ReadAsStreamAsync().Result;
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