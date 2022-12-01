CREATE TABLE [dbo].[CarTypes]
(
	[Id]    INT          NOT NULL IDENTITY (1, 1),
	[Title] NVARCHAR(40) NOT NULL,

	CONSTRAINT PK_CarTypes_Id PRIMARY KEY (Id)
)
