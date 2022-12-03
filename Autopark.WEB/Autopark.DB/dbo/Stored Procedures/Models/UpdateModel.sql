CREATE PROCEDURE [dbo].[UpdateModel]
	@Id             INT,
	@ManufacturerId INT,
	@Title          NVARCHAR(40)
AS
BEGIN
	UPDATE [dbo].[Models]
	SET ManufacturerId = @ManufacturerId,
		Title = @Title
	WHERE Id = @Id;
END