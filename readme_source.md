### Configuring Parameters
The following are the parameter names and a description of the values needed to configure the Beyond Trust Password Safe PAM Provider.

| Initialization parameter | Description | Instance parameter | Description |
| :---: | --- | :---: | --- |
| Host | The IP address or URL of the BeyondTrust instance, including the API endpoint | SystemID | The ID number of the system that holds the requested credential |
| APIKey | The base64 encode API registration key from BeyondTrust | AccountID | The ID number of the account on the system, whose password will be retrieved |
| Username | The username that the API request will be run as. This user needs to have sufficient permissions on the API key and the credentials to request |
| ClientCertificate | The thumbprint for a client certificate to authenticate with BeyondTrust. Can be blank. Certificate should be present with exportable private key in the User's Personal store. |
