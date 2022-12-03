CREATE TRIGGER [Customers_INSERT]
ON [dbo].[Customers]
AFTER INSERT
AS
BEGIN
	INSERT INTO [dbo].[Logs]
	(UserId, LogTime, LogMessage)
	VALUES(
		(SELECT CAST ((SELECT SESSION_CONTEXT(N'user_id')) AS INT)),
		GETDATE(),
		CONCAT(
			'Customers_INSERT: Customer was added with: @CustomerTypeId = ',
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
