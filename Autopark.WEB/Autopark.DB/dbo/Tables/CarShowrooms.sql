CREATE TABLE [dbo].[CarShowrooms]
(
	[Id]     INT          NOT NULL IDENTITY (1, 1),
	[Title]  NVARCHAR(40) NOT NULL,
	[Rating] INT          NULL     CHECK (Rating >= 0 AND Rating <= 10), 
	[Phone]  NVARCHAR(40) NOT NULL,

	CONSTRAINT PK_CarShowrooms_Id PRIMARY KEY (Id)
)
