CREATE PROCEDURE [dbo].[UpdateCarShowroom]
	@Id     INT,
	@Title  NVARCHAR(40),
	@Rating INT,
	@Phone  NVARCHAR(40)
AS
BEGIN
	UPDATE [dbo].[CarShowrooms]
	SET Title  = @Title,
		Rating = @Rating,
		Phone  = @Phone
	WHERE Id = @Id;
END