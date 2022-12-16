CREATE PROCEDURE [dbo].[InsertOrder]
	@CustomerEmployeeId INT,
	@DiscountId         INT,
	@CarId              INT
AS
BEGIN
	INSERT INTO [dbo].[Orders]
	(CustomerEmployeeId, DiscountId, CarId, Date)
	VALUES(@CustomerEmployeeId, @DiscountId, @CarId, GETDATE());
END