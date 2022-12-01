CREATE TABLE [dbo].[Manufacturers]
(
	[Id] INT NOT NULL IDENTITY (1, 1),
	[Title] NVARCHAR(40) NOT NULL,

	CONSTRAINT PK_Manufacturers_Id PRIMARY KEY (Id)
)
