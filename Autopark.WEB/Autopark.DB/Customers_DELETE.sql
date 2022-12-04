CREATE TRIGGER [Customers_DELETE]
ON [dbo].[Customers]
AFTER DELETE
AS
BEGIN
	INSERT INTO [dbo].[Logs]
	(UserId, LogTime, LogMessage)
	VALUES(
		(SELECT CAST ((SELECT SESSION_CONTEXT(N'user_id')) AS INT)),
		GETDATE(),
		CONCAT(
			'Customers_DELETE: Customer was deleted with: @CustomerTypeId = ',
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
			'"'
		)
	);
END
