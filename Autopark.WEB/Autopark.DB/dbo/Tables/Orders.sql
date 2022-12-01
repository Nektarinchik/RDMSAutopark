CREATE TABLE [dbo].[Orders]
(
	[Id]                 INT  NOT NULL IDENTITY (1, 1),
	[CustomerEmployeeId] INT  NULL,
	[DiscountId]         INT  NULL,
	[CarId]              INT  NULL,
	[Date]               DATE NOT NULL CHECK([Date] <= GETDATE()),

	CONSTRAINT PK_Orders_Id                                  PRIMARY KEY (Id),
	CONSTRAINT FK_Orders_CustomerEmployee_CustomerEmployeeId FOREIGN KEY (CustomerEmployeeId) REFERENCES CustomerEmployee (Id)
		ON DELETE SET NULL
		ON UPDATE CASCADE,
	CONSTRAINT FK_Orders_Discounts_DiscountId FOREIGN KEY (DiscountId) REFERENCES Discounts (Id)
		ON DELETE SET NULL
		ON UPDATE CASCADE,
	CONSTRAINT FK_Orders_Cars_CarId FOREIGN KEY (CarId) REFERENCES Cars (Id)
		ON DELETE SET NULL
		ON UPDATE CASCADE
)
