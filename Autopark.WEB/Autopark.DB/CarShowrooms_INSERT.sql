CREATE TRIGGER [CarShowrooms_INSERT]
ON [dbo].[CarShowrooms]
AFTER INSERT
AS
BEGIN
	INSERT INTO [dbo].[Logs]
	(UserId, LogTime, LogMessage)
	VALUES(
		(SELECT CAST ((SELECT SESSION_CONTEXT(N'user_id')) AS INT)),
		GETDATE(),
		CONCAT(
			'CarShowrooms_INSERT: Car Showroom was added with: @Title = ',
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
