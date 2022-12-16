CREATE PROCEDURE [dbo].[UpdateCustomerEmployee]
	@Id INT,
	@CustomerId INT,
	@EmployeeId INT
AS
BEGIN
	UPDATE [dbo].[CustomerEmployee]
	SET CustomerId = @CustomerId,
		EmployeeId = @EmployeeId
	WHERE Id = @Id;
END
