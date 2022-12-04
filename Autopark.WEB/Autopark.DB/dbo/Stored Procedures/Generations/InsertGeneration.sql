CREATE PROCEDURE [dbo].[InsertGeneration]
	@ModelId INT,
	@Title   NVARCHAR(40)
AS
BEGIN
	INSERT INTO [dbo].[Generations]
	(ModelId, Title)
	VALUES(@ModelId, @Title);
END