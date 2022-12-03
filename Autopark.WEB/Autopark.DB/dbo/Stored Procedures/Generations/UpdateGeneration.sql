CREATE PROCEDURE [dbo].[UpdateGeneration]
	@Id      INT,
	@ModelId INT,
	@Title   NVARCHAR(40)
AS
BEGIN
	UPDATE [dbo].[Generations]
	SET ModelId = @ModelId,
		Title   = @Title
	WHERE Id = @Id;
END
