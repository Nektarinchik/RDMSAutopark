CREATE PROCEDURE [dbo].[DeleteCustomerEmployee]
	@CustomerId INT,
	@EmployeeId INT
AS
BEGIN
	DELETE FROM [dbo].[CustomerEmployee]
	WHERE CustomerId = @CustomerId 
		AND EmployeeId = @EmployeeId;
END