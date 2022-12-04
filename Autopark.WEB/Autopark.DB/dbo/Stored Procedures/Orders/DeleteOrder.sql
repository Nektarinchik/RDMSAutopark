CREATE PROCEDURE [dbo].[DeleteOrder]
	@Id INT
AS
BEGIN
	DELETE FROM [dbo].[Orders]
	WHERE Id = @Id;
END