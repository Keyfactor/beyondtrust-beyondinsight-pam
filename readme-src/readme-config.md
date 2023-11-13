### Configuring for PAM Usage
#### In Beyond Trust
The Beyond Trust platform needs to be configured to allow for API requests to retrieve credentials for the systems and accounts necessary.
In the Web Console, the Configuration section API Registrations will allow an API Key to be generated for a user, as well as specify if a Client Certificate will be required.
The user that gets assigned this API Key should not be the default Administrator, and they will also need to be granted access to retrieve Credentials from the appropriate accounts in the User Management section.
If using a Client Certificate, this will need to be exported from the Beyond Trust platform itself or issued from a properly configured PKI that the platform trusts.
__If you are not using a Client Certificate, enter whitespace into this field during configuration in Keyfactor.__

After defining the necessary Functional Account to handle Managed System actions and administration, a Managed System can be defined and then a Managed Account with a Credential added.
You will need to get the IDs for the Account and System to use them in Keyfactor. In order to obtain these, start by going to the "Managed System" or "Managed Accounts" area in Beyond Trust. Find the relevant system or account you are looking for, and click the 3-dot options on the far-right, and go to the "Advanced Details". The ID number will show up in the URL field after opening the Advanced Details.

#### On Keyfactor Universal Orchestrator
##### Installation
Configuring the UO to use the Beyond Trust Password Safe PAM Provider requires first installing it as an extension by copying the release contents into a new extension folder named `BeyondTrust-PasswordSafe`.
A `manifest.json` file is included in the release. This file needs to be edited to enter in the "initialization" parameters for the PAM Provider. Specifically values need to be entered for the parameters in the `manifest.json` of the __PAM Provider extension__:

~~~ json
"Keyfactor:PAMProviders:BeyondTrust-PasswordSafe:InitializationInfo": {
      "Host": "https://<IP address | FQDN>/BeyondTrust/api/public/v3/",
      "APIKey": "base64 API Key from BeyondTrust",
      "Username": "username (with API Key and credential access)",
      "ClientCertificate": "thumbprint of Client Auth Cert - whitespace or blank if unused"
    }
~~~

##### Usage
To use the PAM Provider to resolve a field, for example a Server Password, instead of entering in the actual value for the Server Password, enter a `json` object with the parameters specifying the field.
The parameters needed are the "instance" parameters above:

~~~ json
{"SystemId":"numeric ID of the system with the requested credential","AccountId":"numeric ID of the Account on the system with the password to retrieve"}
~~~

If a field supports PAM but should not use PAM, simply enter in the actual value to be used instead of the `json` format object above.