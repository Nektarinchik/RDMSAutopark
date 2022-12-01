CREATE PROCEDURE [dbo].[InsertCustomerType]
	@Title NVARCHAR(40)
AS
BEGIN
	INSERT INTO [dbo].[CustomerTypes]
	(Title)
	VALUES(@Title);
END
