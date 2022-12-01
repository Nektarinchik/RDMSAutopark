CREATE PROCEDURE [dbo].[DeleteCustomerType]
	@Id int
AS
BEGIN
	DELETE FROM [dbo].[CustomerTypes]
	WHERE Id = @Id;
END
