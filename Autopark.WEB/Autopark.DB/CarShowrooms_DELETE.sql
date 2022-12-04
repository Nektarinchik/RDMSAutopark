CREATE TRIGGER [CarShowrooms_DELETE]
ON [dbo].[CarShowrooms]
AFTER DELETE
AS
BEGIN
	INSERT INTO [dbo].[Logs]
	(UserId, LogTime, LogMessage)
	VALUES(
		(SELECT CAST ((SELECT SESSION_CONTEXT(N'user_id')) AS INT)),
		GETDATE(),
		CONCAT(
			'CarShowrooms_DELETE: Car Showroom was deleted with: @Title = ',
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
			'"'
		)
	);
END
