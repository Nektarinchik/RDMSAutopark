CREATE PROCEDURE [dbo].[InsertManufacturer]
	@Title NVARCHAR(40)
AS
BEGIN
	INSERT INTO [dbo].[Manufacturers]
	(Title)
	VALUES(@Title);
END
