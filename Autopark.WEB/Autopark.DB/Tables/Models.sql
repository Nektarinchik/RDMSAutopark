CREATE TABLE [dbo].[Models]
(
	[Id]             INT          NOT NULL IDENTITY (1, 1),
	[ManufacturerId] INT          NOT NULL,
	[Title]          NVARCHAR(40) NOT NULL,

	CONSTRAINT PK_Models_Id                           PRIMARY KEY (Id),
	CONSTRAINT FK_Models_Manufacturers_ManufacturerId FOREIGN KEY (ManufacturerId) REFERENCES Manufacturers (Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE
)
