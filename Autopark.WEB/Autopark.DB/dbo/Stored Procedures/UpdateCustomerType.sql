CREATE PROCEDURE [dbo].[UpdateCustomerType]
	@Id int,
	@Title NVARCHAR(40)
AS
BEGIN
	UPDATE [dbo].[CustomerTypes]
	SET Title = @Title
	WHERE Id = @Id;
END