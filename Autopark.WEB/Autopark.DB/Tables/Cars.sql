CREATE TABLE [dbo].[Cars]
(
	[Id]            INT   NOT NULL IDENTITY (1, 1),
	[CarTypeId]     INT   NOT NULL,
	[CarShowroomId] INT   NULL,
	[GenerationId]  INT   NOT NULL,
	[Price]         FLOAT NULL CHECK(Price > 0.0),

	CONSTRAINT PK_Cars_Id                 PRIMARY KEY (Id),
	CONSTRAINT FK_Cars_CarTypes_CarTypeId FOREIGN KEY (CarTypeId) REFERENCES CarTypes (Id)
		ON DELETE NO ACTION
		ON UPDATE CASCADE,
	CONSTRAINT FK_Cars_CarShowrooms_CarShowroomId FOREIGN KEY (CarShowroomId) REFERENCES CarShowrooms (Id)
		ON DELETE SET NULL
		ON UPDATE CASCADE,
	CONSTRAINT FK_Cars_Generations_GenerationId FOREIGN KEY (GenerationId) REFERENCES Generations (Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE

)
