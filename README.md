<h1 align="center" style="border-bottom: none">
    BeyondTrust Password Safe PAM Provider
</h1>

<p align="center">
  <!-- Badges -->
<img src="https://img.shields.io/badge/integration_status-production-3D1973?style=flat-square" alt="Integration Status: production" />
<a href="https://github.com/Keyfactor/beyondtrust-beyondinsight-pam/releases"><img src="https://img.shields.io/github/v/release/Keyfactor/beyondtrust-beyondinsight-pam?style=flat-square" alt="Release" /></a>
<img src="https://img.shields.io/github/issues/Keyfactor/beyondtrust-beyondinsight-pam?style=flat-square" alt="Issues" />
<img src="https://img.shields.io/github/downloads/Keyfactor/beyondtrust-beyondinsight-pam/total?style=flat-square&label=downloads&color=28B905" alt="GitHub Downloads (all assets, all releases)" />
</p>

<p align="center">
  <!-- TOC -->
  <a href="#overview">
    <b>Overview</b>
  </a>
  ·
  <a href="#installation">
    <b>Installation</b>
  </a>
  ·
  <a href="#usage">
    <b>Usage</b>
  </a>
  ·
  <a href="#support">
    <b>Support</b>
  </a>
  ·
  <a href="#license">
    <b>License</b>
  </a>
  ·
  <a href="https://github.com/orgs/Keyfactor/repositories?q=pam">
    <b>Related Integrations</b>
  </a>
</p>

## Overview

TODO this section is required

## Getting Started

The BeyondTrust Password Safe PAM Provider is used by Command to resolve PAM-eligible credentials for Universal Orchestrator extensions and for accessing Certificate Authorities. When configured, Command will use the BeyondTrust Password Safe PAM Provider to retrieve credentials needed to communicate with the target system. There are two ways to install the BeyondTrust Password Safe PAM Provider, and you may elect to use one or both methods:

1. **Locally on the Keyfactor Command server**: PAM credential resolution via the BeyondTrust Password Safe PAM Provider will occur on the Keyfactor Command server each time an eligible credential is needed.
2. **Remotely on Universal Orchestrators**: When Jobs are dispatched to Universal Orchestrators, the associated Certificate Store extension assembly will use the BeyondTrust Password Safe PAM Provider to resolve eligible PAM credentials.

Before proceeding with installation, you should consider which pattern is best for your requirements and use case.

### Installation

> [!IMPORTANT]
> For the most up-to-date and complete documentation on how to install a PAM provider extension, please visit our [product documentation](https://software.keyfactor.com/Core-OnPrem/Current/Content/ReferenceGuide/Preparing%20Third%20Party%20PAM%20Providers%20to%20Work%20with.htm?Highlight=pam%20provider#InstallingCustomPAMProviderExtensions).

To install BeyondTrust Password Safe PAM Provider, it is recommended you install [kfutil](https://github.com/Keyfactor/kfutil). `kfutil` is a command-line tool that simplifies the process of creating PAM Types in Keyfactor Command.

#### Requirements

   TODO Requirements is a required section

#### Create PAM type in Keyfactor Command

##### Using `kfutil`

Create the required PAM Types in the connected Command platform.

```shell
# BeyondTrust-PasswordSafe
kfutil pam-types create -r beyondtrust-beyondinsight-pam -n BeyondTrust-PasswordSafe
```

##### Using the API

For full API docs please visit our [product documentation](https://software.keyfactor.com/Core-OnPrem/Current/Content/WebAPI/KeyfactorAPI/PAMProvidersPOSTTypes.htm?Highlight=pam%20type).

Below is the payload to `POST` to the Keyfactor Command API:

```json
{
  "Name": "BeyondTrust-PasswordSafe",
  "Parameters": [
    {
      "Name": "Host",
      "DisplayName": "BeyondTrust Host",
      "DataType": 1,
      "InstanceLevel": false
    },
    {
      "Name": "APIKey",
      "DisplayName": "BeyondTrust API Key",
      "DataType": 2,
      "InstanceLevel": false
    },
    {
      "Name": "Username",
      "DisplayName": "BeyondTrust Username",
      "DataType": 1,
      "InstanceLevel": false
    },
    {
      "Name": "ClientCertificate",
      "DisplayName": "BeyondTrust Client Certificate Thumbprint",
      "DataType": 1,
      "InstanceLevel": false
    },
    {
      "Name": "SystemId",
      "DisplayName": "BeyondTrust System ID",
      "DataType": 1,
      "InstanceLevel": true
    },
    {
      "Name": "AccountId",
      "DisplayName": "BeyondTrust Account ID",
      "DataType": 1,
      "InstanceLevel": true
    }
  ]
}
```

#### Install PAM provider on Keyfactor Command Host (Local)

TODO Platform Install is an optional section. If this section doesn't seem necessary, please delete it.

#### Install PAM provider on a Universal Orchestrator Host (Remote)

TODO Orchestrator Install is an optional section. If this section doesn't seem necessary, please delete it.

### Usage

#### From Keyfactor Command Host (Local)

TODO Platform Usage is an optional section. If this section doesn't seem necessary, please delete it.
#### From a Universal Orchestrator Host (Remote)

TODO Orchestrator Usage is an optional section. If this section doesn't seem necessary, please delete it.
> [!NOTE]
> Additional information on BeyondTrust-PasswordSafe can be found in the [supplemental documentation](docs/beyondtrust-passwordsafe.md).

#### Extension Mechanics

TODO Extension Mechanics is an optional section. If this section doesn't seem necessary, please delete it.

## Support

The BeyondTrust Password Safe PAM Provider is supported by Keyfactor for Keyfactor customers. If you have a support issue, please open a support ticket via the Keyfactor Support Portal at https://support.keyfactor.com.

> To report a problem or suggest a new feature, use the **[Issues](../../issues)** tab. If you want to contribute actual bug fixes or proposed enhancements, use the **[Pull requests](../../pulls)** tab.

## License

Apache License 2.0, see [LICENSE](LICENSE)

## Related Integrations

See all [Keyfactor PAM Provider extensions](https://github.com/orgs/Keyfactor/repositories?q=pam).
