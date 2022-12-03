CREATE PROCEDURE [dbo].[DeleteModel]
	@Id INT
AS
BEGIN
	DELETE FROM [dbo].[Models]
	WHERE Id = @Id;
END