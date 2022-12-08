CREATE PROCEDURE [dbo].[InsertOrder]
	@CustomerUserId INT,
	@EmployeeId     INT,
	@DiscountId     INT,
	@CarId          INT
AS
BEGIN
	INSERT INTO [dbo].[CustomerEmployee]
	(CustomerUserId, EmployeeId)
	VALUES(@CustomerUserId, @EmployeeId);

	DECLARE @CustomerEmployeeId INT = SCOPE_IDENTITY();

	INSERT INTO [dbo].[Orders]
	(CustomerEmployeeId, DiscountId, CarId, Date)
	VALUES(@CustomerEmployeeId, @DiscountId, @CarId, GETDATE());
END