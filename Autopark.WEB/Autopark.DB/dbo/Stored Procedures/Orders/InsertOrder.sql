CREATE PROCEDURE [dbo].[InsertOrder]
	@CustomerEmployeeId INT,
	@CarId              INT
AS
BEGIN
	DECLARE @DiscountId INT;
	IF (SELECT DISTINCT [dbo].[AspNetUsers].[CustomerTypeId]
		FROM [dbo].[CustomerEmployee] 
			INNER JOIN [dbo].[AspNetUsers]
				ON [dbo].[CustomerEmployee].[CustomerId] = [dbo].[AspNetUsers].[Id]
		WHERE [dbo].[CustomerEmployee].[Id] = @CustomerEmployeeId)
		= (SELECT DISTINCT [dbo].[CustomerTypes].[Id]
			FROM [dbo].[CustomerTypes]
			WHERE [dbo].[CustomerTypes].[Title] = 'business')
		AND (SELECT DISTINCT [dbo].[CarTypes].[Id]
			 FROM [dbo].[Cars]
				INNER JOIN [dbo].[CarTypes]
					ON [dbo].[Cars].[CarTypeId] = [dbo].[CarTypes].[Id]
			 WHERE [dbo].[Cars].[Id] = @CarId)
		= (SELECT DISTINCT [dbo].[CarTypes].[Id]
			FROM [dbo].[CarTypes]
			WHERE [dbo].[CarTypes].[Title] = 'commercial')
       SET @DiscountId = (
			SELECT [dbo].[Discounts].[Id]
			FROM [dbo].[Discounts]
			WHERE [dbo].[Discounts].[Value] = 10)
	ELSE IF (SELECT DISTINCT [dbo].[AspNetUsers].[CustomerTypeId]
		FROM [dbo].[CustomerEmployee] 
			INNER JOIN [dbo].[AspNetUsers]
				ON [dbo].[CustomerEmployee].[CustomerId] = [dbo].[AspNetUsers].[Id]
		WHERE [dbo].[CustomerEmployee].[Id] = @CustomerEmployeeId)
		= (SELECT DISTINCT [dbo].[CustomerTypes].[Id]
			FROM [dbo].[CustomerTypes]
			WHERE [dbo].[CustomerTypes].[Title] = 'business')
		AND (SELECT DISTINCT [dbo].[CarTypes].[Id]
			 FROM [dbo].[Cars]
				INNER JOIN [dbo].[CarTypes]
					ON [dbo].[Cars].[CarTypeId] = [dbo].[CarTypes].[Id]
			 WHERE [dbo].[Cars].[Id] = @CarId)
		= (SELECT DISTINCT [dbo].[CarTypes].[Id]
			FROM [dbo].[CarTypes]
			WHERE [dbo].[CarTypes].[Title] = 'passenger')
       SET @DiscountId = (
			SELECT [dbo].[Discounts].[Id]
			FROM [dbo].[Discounts]
			WHERE [dbo].[Discounts].[Value] = 5)
	ELSE 
       SET @DiscountId = (
			SELECT [dbo].[Discounts].[Id]
			FROM [dbo].[Discounts]
			WHERE [dbo].[Discounts].[Value] = 0)
	INSERT INTO [dbo].[Orders]
	(CustomerEmployeeId, DiscountId, CarId, Date)
	VALUES(@CustomerEmployeeId, @DiscountId, @CarId, GETDATE());
END