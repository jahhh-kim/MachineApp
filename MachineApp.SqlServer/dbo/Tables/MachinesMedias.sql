CREATE TABLE [dbo].[MachinesMedias]
(
	[Id] INT NOT NULL Identity(1,1) PRIMARY KEY,
	[MachinId] Int NULL,
	[MediaId] Int NULL,

	[CreatedBy] NVarChar(255) Null,
	[Created] DateTime Default (GetDate()),
	[ModifieBy]NVarChar(255) Null,
	[Modified] DateTime Null,

)
