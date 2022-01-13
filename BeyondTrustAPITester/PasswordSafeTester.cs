using Keyfactor.Extensions.Pam.BeyondInsight.PasswordSafe;
using System;
using System.Collections.Generic;

namespace BeyondTrustAPITester
{
    class PasswordSafeTester
    {
        static string USERNAME = "beyondtrust";
        static string PASSWORD = "###";
        static string APIUSER = "apiuser";
        static string APIKEY = "###";
        static string URL = "https://###/BeyondTrust/api/public/v3/";

        static void Main(string[] args)
        {
            var client = new PasswordSafePAM();
            var initVars = new Dictionary<string, string>()
            {
                { "Host", URL },
                { "APIKey", APIKEY },
                { "Username", USERNAME }
            };

            var instanceVars = new Dictionary<string, string>()
            {
                { "SystemID", "1" },
                { "AccountID", "1" }
            };

            client.GetPassword(instanceVars, initVars);
        }
    }
}
