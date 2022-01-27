# BeyondTrust Password Safe

The BeyondTrust Password Safe PAM Provider allows for the retrieval of stored account credentials from the Password Safe solution. A valid API registration in BeyondTrust is used to open a request and retrieve credentials for a given account on a system.

## About the Keyfactor PAM Provider

Keyfactor supports the retrieval of credentials from 3rd party Priviledged Access Management (PAM) solutions. Secret values can normally be stored, encrypted at rest, in the Keyfactor Platform database. A PAM Provider can allow these secrets to be stored, managed, and rotated in an external platform. This integration is usually configured on the Keyfactor Platform itself, where the platform can request the credential values when needed. In certain scenarios, a PAM Provider can instead be run on a remote location in conjunction with a Keyfactor Orchestrator to allow credential requests to originate from a location other than the Keyfactor Platform.

---

### Configuring Parameters
The following are the parameter names and a description of the values needed to configure the Beyond Trust Password Safe PAM Provider.

| Initialization parameter | Description | Instance parameter | Description |
| :---: | --- | :---: | --- |
| Host | The IP address or URL of the BeyondTrust instance, including the API endpoint | SystemID | The ID number of the system that holds the requested credential |
| APIKey | The base64 encode API registration key from BeyondTrust | AccountID | The ID number of the account on the system, whose password will be retrieved |
| Username | The username that the API request will be run as. This user needs to have sufficient permissions on the API key and the credentials to request |
