CREATE PROCEDURE [dbo].[UpdateOrder]
	@Id                 INT,
	@CustomerEmployeeId INT,
	@DiscountId         INT,
	@CarId              INT,
	@Date               DATE
AS
BEGIN
	UPDATE [dbo].[Orders]
	SET CustomerEmployeeId = @CustomerEmployeeId,
		DiscountId         = @DiscountId,
		CarId              = @CarId,
		Date               = @Date
	WHERE Id = @Id;
END