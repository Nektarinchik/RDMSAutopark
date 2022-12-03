CREATE TRIGGER [CarTypes_UPDATE]
ON [dbo].[CarTypes]
AFTER UPDATE
AS
BEGIN
	INSERT INTO [dbo].[Logs]
	(UserId, LogTime, LogMessage)
	VALUES(
		(SELECT CAST ((SELECT SESSION_CONTEXT(N'user_id')) AS INT)),
		GETDATE(),
		CONCAT(
			'CarTypes_UPDATE: Car Type was changed FROM @Title = ',
			'"',
			(SELECT Title FROM DELETED),
			'"',
			' @Id = ',
			'"',
			(SELECT Id FROM DELETED),
			'"',
			' TO @Title = ',
			'"',
			(SELECT Title FROM INSERTED),
			'"',
			' @Id = ',
			'"',
			(SELECT Id FROM INSERTED),
			'"'
		)
	);
END
