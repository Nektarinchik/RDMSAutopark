CREATE PROCEDURE [dbo].[InsertDiscount]
	@Title NVARCHAR(40),
	@Value INT
AS
BEGIN
	INSERT INTO [dbo].[Discounts]
	(Title, Value)
	VALUES(@Title, @Value);
END