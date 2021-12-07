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

namespace Keyfactor.Extensions.Pam.BeyondInsight.PasswordSafe.API
{
    public class UserSession
    {
        public int UserId { get; set; }
        public string SID { get; set; }
        public string EmailAddres { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
    }

    public class AccessPolicyTest
    {
        public int SystemId { get; set; }
        public int AccountId { get; set; }
        public int DurationMinutes { get; set; }
    }

    public class Credential
    {
        public string Credentials { get; set; }
    }

    public class NewRequest
    {
        public int SystemID { get; set; }
        public int AccountID { get; set; }
        public int DurationMinutes { get; set; }
        public string Reason { get; set; }
    }

    public class CreatedRequest
    {
        public int RequestID { get; set; }
    }
    
    public class Request
    {
        public int RequestID { get; set; }
        public int SystemID { get; set; }
        public string SystemName { get; set; }
        public int AccountID { get; set; }
        public string AccountName { get; set; }
        public string DomainName { get; set; }
        public int AliasID { get; set; }
        public int ApplicationID { get; set; }
        public string RequestReleaseDate { get; set; }
        public string ApprovedDate { get; set; }
        public string ExpiresDate { get; set; }
        public string Status { get; set; }
        public string AccessType { get; set; }
    }
}
