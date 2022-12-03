CREATE PROCEDURE [dbo].[InsertModel]
	@ManufacturerId INT,
	@Title NVARCHAR(40)
AS
BEGIN
	INSERT INTO [dbo].[Models]
	(ManufacturerId, Title)
	VALUES(@ManufacturerId, @Title);
END
