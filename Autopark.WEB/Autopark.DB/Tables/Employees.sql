CREATE TABLE [dbo].[Employees]
(
	[Id]            INT  NOT NULL,
	[StartDate]     DATE NOT NULL CHECK (StartDate <= GETDATE()),
	[EndDate]       DATE NULL     CHECK (EndDate >= StartDate AND EndDate <= GETDATE()),

	CONSTRAINT PK_Employees_Id             PRIMARY KEY (Id),
	CONSTRAINT FK_Employees_AspNetUsers_Id FOREIGN KEY (Id) REFERENCES AspNetUsers (Id)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
)
