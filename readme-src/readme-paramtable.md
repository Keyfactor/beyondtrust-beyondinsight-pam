__Initialization Parameters for each defined PAM Provider instance__
| Initialization parameter | Display Name | Description |
| :---: | :---: | --- |
| Host | BeyondTrust Host | The IP address or URL of the BeyondTrust instance, including the API endpoint (default endpoint: BeyondTrust/api/public/v3/) |
| APIKey | BeyondTrust API Key | The base64 encode API registration key from BeyondTrust |
| Username | BeyondTrust Username | The username that the API request will be run as. This user needs to have sufficient permissions on the API key and the credentials to request |
| ClientCertificate | BeyondTrust Client Certificate Thumbprint | (OPTIONAL - enter whitespace if unused) The thumbprint for a client certificate to authenticate with BeyondTrust. Can be blank. Certificate should be present with exportable private key in the User's Personal store. |


__Instance Parameters for each retrieved secret field__
| Instance parameter | Display Name | Description |
| :---: | :---: | --- |
| SystemId | BeyondTrust System ID | The ID of the system that holds the requested credential |
| AccountId | BeyondTrust Account ID | The ID of the account on the system, whose password will be retrieved |
