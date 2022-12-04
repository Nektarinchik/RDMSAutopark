CREATE TRIGGER [CarShowrooms_UPDATE]
ON [dbo].[CarShowrooms]
AFTER UPDATE
AS
BEGIN
	INSERT INTO [dbo].[Logs]
	(UserId, LogTime, LogMessage)
	VALUES(
		(SELECT CAST ((SELECT SESSION_CONTEXT(N'user_id')) AS INT)),
		GETDATE(),
		CONCAT(
			'CarShowrooms_UPDATE: Car Showroom was changed FROM @Title = ',
			'"',
			(SELECT Title FROM DELETED),
			'"',
			' @Id = ',
			'"',
			(SELECT Id FROM DELETED),
			'"',
			' @Rating = ',
			'"',
			(SELECT Rating FROM DELETED),
			'"',
			' @Phone = ',
			'"',
			(SELECT Phone FROM DELETED),
			'"',
			' TO @Title = ',
			'"',
			(SELECT Title FROM INSERTED),
			'"',
			' @Id = ',
			'"',
			(SELECT Id FROM INSERTED),
			'"',
			' @Rating = ',
			'"',
			(SELECT Rating FROM INSERTED),
			'"',
			' @Phone = ',
			'"',
			(SELECT Phone FROM INSERTED),
			'"'
		)
	);
END
