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

using Keyfactor.Platform.Extensions;
using System.Collections.Generic;

namespace Keyfactor.Extensions.Pam.BeyondInsight.PasswordSafe
{
    public class PasswordSafePAM : IPAMProvider
    {
        public string Name => "BeyondInsight-PasswordSafe";

        public string GetPassword(Dictionary<string, string> instanceParameters, Dictionary<string, string> initializationInfo)
        {
            string url = initializationInfo["Host"];
            string apiKey = initializationInfo["APIKey"];
            string username = initializationInfo["Username"];

            string systemId = instanceParameters["SystemID"];
            string accountId = instanceParameters["AccountID"];
            
            string credential;
            using(Client client = new Client(url, username, apiKey))
            {
                bool access = client.StartPlatformAccess().Result;

                int requestId = client.RequestCredential(systemId, accountId).Result;
                credential = client.RetrieveCredential(requestId).Result;
            }

            return credential;
        }
    }
}