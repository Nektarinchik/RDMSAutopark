CREATE PROCEDURE [dbo].[InsertCustomer]
	@Id              INT,
	@CustomerTypeId  INT,
	@SpendingBalance FLOAT
AS
BEGIN
	INSERT INTO [dbo].[Customers]
	(Id, CustomerTypeId, SpendingBalance)
	VALUES(@Id, @CustomerTypeId,@SpendingBalance);
END