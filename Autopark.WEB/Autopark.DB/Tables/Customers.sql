CREATE TABLE [dbo].[Customers]
(
	[Id]              INT   NOT NULL,
	[CustomerTypeId]  INT   NOT NULL,
	[SpendingBalance] FLOAT NULL     CHECK (SpendingBalance >= 0),

	CONSTRAINT PK_Customers_Id             PRIMARY KEY (Id),
	CONSTRAINT FK_Customers_AspNetUsers_Id FOREIGN KEY (Id) REFERENCES AspNetUsers (Id)
		ON DELETE NO ACTION
		ON UPDATE CASCADE,
	CONSTRAINT FK_Customers_CustomerTypes_CustomerTypeId FOREIGN KEY (CustomerTypeId) REFERENCES CustomerTypes (Id)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION
)
