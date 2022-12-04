CREATE PROCEDURE [dbo].[UpdateDiscount]
	@Id    INT,
	@Title NVARCHAR(40),
	@Value INT
AS
BEGIN 
	UPDATE [dbo].[Discounts]
	SET Title = @Title,
		Value = @Value
	WHERE Id = @Id;
END