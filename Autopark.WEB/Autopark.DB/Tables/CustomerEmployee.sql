CREATE TABLE [dbo].[CustomerEmployee]
(
	[Id]         INT NOT NULL IDENTITY (1, 1),
	[EmployeeId] INT NOT NULL,
	[CustomerId] INT NOT NULL,

	CONSTRAINT PK_CustomerEmployee_Id                  PRIMARY KEY (Id),
	CONSTRAINT FK_CustomerEmployee_Customer_CustomerId FOREIGN KEY (CustomerId) REFERENCES Customers (Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	CONSTRAINT FK_CustomerEmployee_Employee_EmployeeId FOREIGN KEY (EmployeeId) REFERENCES Employees (Id)
		ON DELETE CASCADE
		ON UPDATE CASCADE,
	CONSTRAINT UQ_EmployeeId_CustomerId UNIQUE (EmployeeId, CustomerId)
)
