CREATE PROCEDURE [dbo].[InsertCustomerEmployee]
	@CustomerId INT,
	@EmployeeId INT
AS
BEGIN
	INSERT INTO [dbo].[CustomerEmployee]
	(CustomerId, EmployeeId)
	VALUES(@CustomerId, @EmployeeId);
END
