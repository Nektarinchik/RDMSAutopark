CREATE PROCEDURE [dbo].[DeleteCarShowroom]
	@Id INT
AS
BEGIN
	DELETE FROM [dbo].[CarShowrooms]
	WHERE Id = @Id;
END
