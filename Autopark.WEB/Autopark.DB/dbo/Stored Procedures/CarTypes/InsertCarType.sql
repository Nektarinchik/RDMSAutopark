CREATE PROCEDURE [dbo].[InsertCarType]
	@Title NVARCHAR(40)
AS
BEGIN
	INSERT INTO [dbo].[CarTypes]
	(Title)
	VALUES(@Title);
END