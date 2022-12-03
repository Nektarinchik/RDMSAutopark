CREATE TRIGGER [Customers_UPDATE]
ON [dbo].[Customers]
AFTER UPDATE
AS
BEGIN
	INSERT INTO [dbo].[Logs]
	(UserId, LogTime, LogMessage)
	VALUES(
		(SELECT CAST ((SELECT SESSION_CONTEXT(N'user_id')) AS INT)),
		GETDATE(),
		CONCAT(
			'Customers_UPDATE: Customer was changed FROM @CustomerTypeId = ',
			'"',
			(SELECT CustomerTypeId FROM DELETED),
			'"',
			' @Id = ',
			'"',
			(SELECT Id FROM DELETED),
			'"',
			' @SpendingBalance = ',
			'"',
			(SELECT SpendingBalance FROM DELETED),
			'"',
			' @UserName = ',
			'"',
			(SELECT [dbo].[AspNetUsers].[UserName]
			 FROM DELETED 
				INNER JOIN [dbo].[AspNetUsers] ON DELETED.Id = [dbo].[AspNetUsers].[Id]
			),
			'"',
			' TO @CustomerTypeId = ',
			'"',
			(SELECT CustomerTypeId FROM INSERTED),
			'"',
			' @Id = ',
			'"',
			(SELECT Id FROM INSERTED),
			'"',
			' @SpendingBalance = ',
			'"',
			(SELECT SpendingBalance FROM INSERTED),
			'"',
			' @UserName = ',
			'"',
			(SELECT [dbo].[AspNetUsers].[UserName]
			 FROM INSERTED 
				INNER JOIN [dbo].[AspNetUsers] ON INSERTED.Id = [dbo].[AspNetUsers].[Id]
			),
			'"'
		)
	);
END
