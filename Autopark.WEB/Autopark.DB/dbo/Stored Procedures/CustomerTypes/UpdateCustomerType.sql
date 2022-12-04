CREATE PROCEDURE [dbo].[UpdateCustomerType]
	@Id INT,
	@Title NVARCHAR(40)
AS
BEGIN
	UPDATE [dbo].[CustomerTypes]
	SET Title = @Title
	WHERE Id = @Id;
END