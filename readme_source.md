### Configuring Parameters
The following are the parameter names and a description of the values needed to configure the Beyond Trust Password Safe PAM Provider.

| Initialization parameter | Description | Instance parameter | Description |
| :---: | --- | :---: | --- |
| Host | The IP address or URL of the BeyondTrust instance, including the API endpoint | SystemName | The name of the system that holds the requested credential |
| APIKey | The base64 encode API registration key from BeyondTrust | AccountName | The name of the account on the system, whose password will be retrieved |
| Username | The username that the API request will be run as. This user needs to have sufficient permissions on the API key and the credentials to request | IsAWSAccessKey | (OPTIONAL) If set, will interpret the credential retrieved as a concatenated AWS Access Key and Secret Key, and retrieve the first part before a separator (' ', ':', ';') |
| ClientCertificate | (OPTIONAL) The thumbprint for a client certificate to authenticate with BeyondTrust. Can be blank. Certificate should be present with exportable private key in the User's Personal store. | IsAWSSecretKey | (OPTIONAL) If set, will interpret the credential retrieved as a concatenated AWS Access Key and Secret Key, and retrieve the second part after a separator (' ', ':', ';') |


### Configuring for PAM Usage
#### In Beyond Trust
The Beyond Trust platform needs to be configured to allow for API requests to retrieve credentials for the systems and accounts necessary.
In the Web Console, the Configuration section API Registrations will allow an API Key to be generated for a user, as well as specify if a Client Certificate will be required.
The user that gets assigned this API Key should not be the default Administrator, and they will also need to be granted access to retrieve Credentials from the appropriate accounts in the User Management section.
If using a Client Certificate, this will need to be exported from the Beyond Trust platform itself or issued from a properly configured PKI that the platform trusts.

After defining the necessary Functional Account to handle Managed System actions and administration, a Managed System can be defined and then a Managed Account with a Credential added.
The names given to the Managed System and Managed Account will later be used to lookup the credentials in the PAM Provider plugin.

#### In Keyfactor - PAM Provider
This new PAM Provider implementation will need to be added to an existing Keyfactor installation by inserting the PAM Provider definition into the application database with the included SQL script.
Take note, that when defining the PAM Provider you can choose to include parameters that are meant for special handling of AWS Credentials. This definition should be used if PAM instances will be configured that will retrieve AWS Credentials.
After creating the record of the PAM Provider implementation in the Keyfactor application database, new PAM Providers of the Beyond Trust type can be added as normal in the Keyfactor Platform.
