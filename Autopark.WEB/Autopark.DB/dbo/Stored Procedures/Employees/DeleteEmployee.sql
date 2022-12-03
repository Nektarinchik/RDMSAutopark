CREATE PROCEDURE [dbo].[DeleteEmployee]
	@Id INT
AS
BEGIN
	DELETE FROM [dbo].[Employees]
	WHERE Id = @Id;
END