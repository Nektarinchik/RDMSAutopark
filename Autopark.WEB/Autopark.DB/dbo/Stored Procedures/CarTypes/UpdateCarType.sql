CREATE PROCEDURE [dbo].[UpdateCarType]
	@Id    INT,
	@Title NVARCHAR(40)
AS
BEGIN
	UPDATE [dbo].[CarTypes]
	SET Title = @Title
	WHERE Id = @Id;
END
