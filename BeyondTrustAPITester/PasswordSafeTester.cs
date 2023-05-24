using Keyfactor.Extensions.Pam.BeyondInsight.PasswordSafe;
using System;
using System.Collections.Generic;

namespace BeyondTrustAPITester
{
    class PasswordSafeTester
    {
        static string USERNAME = "myuser";
        static string PASSWORD = "Beyondtrust123!";
        static string APIUSER = "apiuser";
        static string APIKEY = "a48d82117ce24d6afd76d1b0c7338ceffcdd4e36e1614e2324fb90310a99b427b96f3c5c08f8889b36dd3879dbaac1a29c5a02d93ed229ce711aa976075e3d35";
        static string URL = "https://20.119.41.120/BeyondTrust/api/public/v3/";
        static string CERT_THUMB = "f98bbadefc0365bbf69aa0c42c84c5193fba39b5";
        static string CERT_PASS = "Beyondtrust123";

        static void Main(string[] args)
        {
            var pam = new PasswordSafePAM();
            var initVars = new Dictionary<string, string>()
            {
                { "Host", URL },
                { "APIKey", APIKEY },
                { "Username", USERNAME },
                //{ "ClientCertificate", CERT_THUMB },
                //{ "ClientCertificatePassword", CERT_PASS }
            };

            var instanceVars = new Dictionary<string, string>()
            {
                { "SystemId", "3" },
                { "AccountId", "5" }
            };

            string password = pam.GetPassword(instanceVars, initVars);
            string s = password;
        }
    }
}
