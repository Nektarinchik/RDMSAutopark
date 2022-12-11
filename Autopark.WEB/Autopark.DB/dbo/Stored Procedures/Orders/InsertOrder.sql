CREATE PROCEDURE [dbo].[InsertOrder]
	@CustomerId INT,
	@EmployeeId     INT,
	@DiscountId     INT,
	@CarId          INT
AS
BEGIN
	INSERT INTO [dbo].[CustomerEmployee]
	(CustomerId, EmployeeId)
	VALUES(@CustomerId, @EmployeeId);

	DECLARE @CustomerEmployeeId INT = SCOPE_IDENTITY();

	INSERT INTO [dbo].[Orders]
	(CustomerEmployeeId, DiscountId, CarId, Date)
	VALUES(@CustomerEmployeeId, @DiscountId, @CarId, GETDATE());
END