CREATE PROCEDURE [dbo].[DeleteGeneration]
	@Id INT
AS
BEGIN
	DELETE FROM [dbo].[Generations]
	WHERE Id = @Id;
END