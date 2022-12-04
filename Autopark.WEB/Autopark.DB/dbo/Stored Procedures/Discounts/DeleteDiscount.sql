CREATE PROCEDURE [dbo].[DeleteDiscount]
	@Id INT
AS
BEGIN
	DELETE FROM [dbo].[Discounts]
	WHERE Id = @Id;
END