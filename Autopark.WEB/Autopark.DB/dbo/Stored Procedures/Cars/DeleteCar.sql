CREATE PROCEDURE [dbo].[DeleteCar]
	@Id INT
AS
BEGIN
	DELETE FROM [dbo].[Cars]
	WHERE Id = @Id;
END