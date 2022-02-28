declare @pamid uniqueidentifier;
set @pamid = newid();

insert into [pam].[ProviderTypes]([Id], [Name])
values (@pamid, 'BeyondTrust-PasswordSafe');

insert into [pam].[ProviderTypeParams]([ProviderTypeId], [Name], [DisplayName], [DataType], [InstanceLevel])
values	(@pamid, 'Host', 'BeyondTrust Host', 1, 0),
		(@pamid, 'APIKey', 'BeyondTrust API Key', 1, 0),
		(@pamid, 'Username', 'BeyondTrust Username', 1, 0),
		(@pamid, 'ClientCertificate', 'BeyondTrust Client Certificate Thumbprint', 1, 0),
		(@pamid, 'SystemName', 'BeyondTrust System Name', 1, 1),
		(@pamid, 'AccountName', 'BeyondTrust Account Name', 1, 1);

-- NOTE: Use this insert statement when setting up the pam provider to support AWS credentials
-- AWS credentials are stored concatenated together in a Credential field in Beyond Trust

--insert into [pam].[ProviderTypeParams]([ProviderTypeId], [Name], [DisplayName], [DataType], [InstanceLevel])
--values	(@pamid, 'Host', 'BeyondTrust Host', 1, 0),
--		(@pamid, 'APIKey', 'BeyondTrust API Key', 1, 0),
--		(@pamid, 'Username', 'BeyondTrust Username', 1, 0),
--		(@pamid, 'ClientCertificate', 'BeyondTrust Client Certificate Thumbprint', 1, 0),
--		(@pamid, 'SystemName', 'BeyondTrust System Name', 1, 1),
--		(@pamid, 'AccountName', 'BeyondTrust Account Name', 1, 1)
--		(@pamid, 'IsAWSAccessKey', 'Is an AWS Access Key', 4, 1)
--		(@pamid, 'IsAWSSecretKey', 'Is an AWS Secret Key', 4, 1);