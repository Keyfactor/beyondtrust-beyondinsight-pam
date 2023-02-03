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

    public class NewRequest
    {
        public int SystemID { get; set; }
        public int AccountID { get; set; }
        public int DurationMinutes { get; set; }
        public string Reason { get; set; }
        public string ConflictOption { get; set; }
    }
    
    public class ManagedAccount
    {
        public int SystemId { get; set; }
        public string SystemName { get; set; }
        public int AccountId { get; set; }
        public string AccountName { get; set; }
        public string DomainName { get; set; }
        public int ApplicationID { get; set; }
        public int DefaultReleaseDuration { get; set; }
        public int MaximumReleaseDuration { get; set; }
    }
}
