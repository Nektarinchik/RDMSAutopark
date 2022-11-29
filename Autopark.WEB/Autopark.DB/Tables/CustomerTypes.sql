CREATE TABLE [dbo].[CustomerTypes]
(
	[Id]    INT          NOT NULL IDENTITY (1, 1),
	[Title] NVARCHAR(40) NOT NULL,

	CONSTRAINT PK_CustomerTypes_Id PRIMARY KEY (Id)
)
