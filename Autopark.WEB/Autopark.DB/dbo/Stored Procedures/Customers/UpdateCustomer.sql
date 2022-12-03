CREATE PROCEDURE [dbo].[UpdateCustomer]
	@Id              INT,
	@CustomerTypeId  INT,
	@SpendingBalance FLOAT
AS
BEGIN
	UPDATE [dbo].[Customers]
	SET CustomerTypeId  = @CustomerTypeId,
		SpendingBalance = @SpendingBalance
	WHERE Id = @Id;
END