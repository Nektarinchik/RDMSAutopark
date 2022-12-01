CREATE TABLE [dbo].[Generations]
(
	[Id]      INT          NOT NULL IDENTITY (1, 1),
	[ModelId] INT          NOT NULL,
	[Title]   NVARCHAR(40) NOT NULL,

	CONSTRAINT PK_Generations_Id             PRIMARY KEY (Id),
	CONSTRAINT FK_Generations_Models_ModelId FOREIGN KEY (ModelId) REFERENCES Models (Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE
)
