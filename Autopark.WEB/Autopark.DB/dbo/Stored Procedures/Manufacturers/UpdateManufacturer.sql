CREATE PROCEDURE [dbo].[UpdateManufacturer]
	@Id INT,
	@Title NVARCHAR(40)
AS
BEGIN
	UPDATE [dbo].[Manufacturers]
	SET Title = @Title
	WHERE Id = @Id;
END
