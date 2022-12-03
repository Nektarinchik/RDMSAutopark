CREATE PROCEDURE [dbo].[DeleteCarType]
	@Id INT
AS
BEGIN
	DELETE FROM [dbo].[CarTypes]
	WHERE Id = @Id;
END