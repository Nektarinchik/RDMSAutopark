CREATE PROCEDURE [dbo].[DeleteCustomer]
	@Id INT
AS
BEGIN
	DELETE FROM [dbo].[Customers]
	WHERE Id = @Id;
END