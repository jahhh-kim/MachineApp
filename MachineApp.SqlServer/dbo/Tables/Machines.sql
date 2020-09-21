CREATE TABLE [dbo].[Machines]
(
	[Id] INT NOT NULL Identity(1,1) PRIMARY KEY, --Serial Number
	[Name] NVarChar(255) Not Null,               --H/W Name

	[CreatedBy] NVarChar(255) Null,
	[Created] DateTime Default (GetDate()),
	[ModifieBy]NVarChar(255) Null,
	[Modified] DateTime Null,

)
