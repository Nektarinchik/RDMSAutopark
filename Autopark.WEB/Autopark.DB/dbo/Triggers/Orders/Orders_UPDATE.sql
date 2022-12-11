CREATE TRIGGER [Orders_UPDATE]
ON [dbo].[Orders]
AFTER UPDATE
AS
BEGIN
	INSERT INTO [dbo].[Logs]
	(UserId, LogTime, LogMessage)
	VALUES(
		(SELECT CAST ((SELECT SESSION_CONTEXT(N'user_id')) AS INT)),
		GETDATE(),
		CONCAT(
			'Orders_UPDATE: Order was changed FROM @EmployeeId = ',
			'"',
			(SELECT [dbo].[CustomerEmployee].[EmployeeId] 
			FROM DELETED
				INNER JOIN [dbo].[CustomerEmployee] ON DELETED.CustomerEmployeeId = [dbo].[CustomerEmployee].[Id]),
			'"',
			' @EmployeeName = ',
			'"',
			(SELECT [dbo].[AspNetUsers].[UserName]
			FROM DELETED
				INNER JOIN [dbo].[CustomerEmployee] ON DELETED.CustomerEmployeeId  = [dbo].[CustomerEmployee].[Id]
				INNER JOIN [dbo].[AspNetUsers]      ON [dbo].[AspNetUsers].[Id]    = [dbo].[CustomerEmployee].[EmployeeId]),
			'"',
			' @CustomerId = ',
			'"',
			(SELECT [dbo].[CustomerEmployee].[CustomerId] 
			FROM DELETED
				INNER JOIN [dbo].[CustomerEmployee] ON DELETED.CustomerEmployeeId = [dbo].[CustomerEmployee].[Id]),
			'"',
			' @CustomerName = ',
			'"',
			(SELECT [dbo].[AspNetUsers].[UserName]
			FROM DELETED
				INNER JOIN [dbo].[CustomerEmployee] ON DELETED.CustomerEmployeeId  = [dbo].[CustomerEmployee].[Id]
				INNER JOIN [dbo].[AspNetUsers]      ON [dbo].[AspNetUsers].[Id]    = [dbo].[CustomerEmployee].[CustomerId]),
			'"',
			' @DiscountId = ',
			'"',
			(SELECT DiscountId FROM DELETED),
			'"',
			' @DiscountTitle = ',
			'"',
			(SELECT [dbo].[Discounts].[Title] 
			FROM DELETED
				INNER JOIN [dbo].[Discounts] ON DELETED.DiscountId = [dbo].[Discounts].[Id]),
			'"',
			' @CarId = ',
			'"',
			(SELECT CarId FROM DELETED),
			'"',
			' @Date = ',
			'"',
			(SELECT Date FROM DELETED),
			'"',
			' TO @EmployeeId = ',
			'"',
			(SELECT [dbo].[CustomerEmployee].[EmployeeId] 
			FROM INSERTED
				INNER JOIN [dbo].[CustomerEmployee] ON INSERTED.CustomerEmployeeId = [dbo].[CustomerEmployee].[Id]),
			'"',
			' @EmployeeName = ',
			'"',
			(SELECT [dbo].[AspNetUsers].[UserName]
			FROM INSERTED
				INNER JOIN [dbo].[CustomerEmployee] ON INSERTED.CustomerEmployeeId = [dbo].[CustomerEmployee].[Id]
				INNER JOIN [dbo].[AspNetUsers]      ON [dbo].[AspNetUsers].[Id]    = [dbo].[CustomerEmployee].[EmployeeId]),
			'"',
			' @CustomerId = ',
			'"',
			(SELECT [dbo].[CustomerEmployee].[CustomerId] 
			FROM INSERTED
				INNER JOIN [dbo].[CustomerEmployee] ON INSERTED.CustomerEmployeeId = [dbo].[CustomerEmployee].[Id]),
			'"',
			' @CustomerName = ',
			'"',
			(SELECT [dbo].[AspNetUsers].[UserName]
			FROM INSERTED
				INNER JOIN [dbo].[CustomerEmployee] ON INSERTED.CustomerEmployeeId = [dbo].[CustomerEmployee].[Id]
				INNER JOIN [dbo].[AspNetUsers]      ON [dbo].[AspNetUsers].[Id]    = [dbo].[CustomerEmployee].[CustomerId]),
			'"',
			' @Id = ',
			'"',
			(SELECT Id FROM INSERTED),
			'"',
			' @DiscountId = ',
			'"',
			(SELECT DiscountId FROM INSERTED),
			'"',
			' @DiscountTitle = ',
			'"',
			(SELECT [dbo].[Discounts].[Title] 
			FROM INSERTED
				INNER JOIN [dbo].[Discounts] ON INSERTED.DiscountId = [dbo].[Discounts].[Id]),
			'"',
			' @CarId = ',
			'"',
			(SELECT CarId FROM INSERTED),
			'"',
			' @Date = ',
			'"',
			(SELECT Date FROM INSERTED),
			'"'
		)
	);
END