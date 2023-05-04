### Configuring for PAM Usage
#### In Beyond Trust
The Beyond Trust platform needs to be configured to allow for API requests to retrieve credentials for the systems and accounts necessary.
In the Web Console, the Configuration section API Registrations will allow an API Key to be generated for a user, as well as specify if a Client Certificate will be required.
The user that gets assigned this API Key should not be the default Administrator, and they will also need to be granted access to retrieve Credentials from the appropriate accounts in the User Management section.
If using a Client Certificate, this will need to be exported from the Beyond Trust platform itself or issued from a properly configured PKI that the platform trusts.
__If you are not using a Client Certificate, enter whitespace into this field during configuration in Keyfactor.__

After defining the necessary Functional Account to handle Managed System actions and administration, a Managed System can be defined and then a Managed Account with a Credential added.
You will need to get the IDs for the Account and System to use them in Keyfactor. In order to obtain these, start by going to the "Managed System" or "Managed Accounts" area in Beyond Trust. Find the relevant system or account you are looking for, and click the 3-dot options on the far-right, and go to the "Advanced Details". The ID number will show up in the URL field after opening the Advanced Details.
