CREATE PROCEDURE [dbo].[DeleteManufacturer]
	@Id INT
AS
BEGIN
	DELETE FROM [dbo].[Manufacturers]
	WHERE Id = @Id;
END
