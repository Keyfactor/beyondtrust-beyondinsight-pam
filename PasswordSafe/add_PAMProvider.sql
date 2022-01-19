declare @pamid uniqueidentifier;
set @pamid = newid();

insert into [pam].[ProviderTypes]([Id], [Name])
values (@pamid, 'BeyondTrust PasswordSafe');

insert into [pam].[ProviderTypeParams]([ProviderTypeId], [Name], [DisplayName], [DataType], [InstanceLevel])
values	(@pamid, 'Host', 'BeyondTrust Host', 1, 0),
		(@pamid, 'APIKey', 'BeyondTrust API Key', 1, 0),
		(@pamid, 'Username', 'BeyondTrust Username', 1, 0),
		(@pamid, 'SystemID', 'BeyondTrust System ID', 1, 1),
		(@pamid, 'AccountID', 'BeyondTrust Account ID', 1, 1);

