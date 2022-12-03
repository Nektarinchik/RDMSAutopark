CREATE TRIGGER [CarTypes_DELETE]
ON [dbo].[CarTypes]
AFTER DELETE
AS
BEGIN
	INSERT INTO [dbo].[Logs]
	(UserId, LogTime, LogMessage)
	VALUES(
		(SELECT CAST ((SELECT SESSION_CONTEXT(N'user_id')) AS INT)),
		GETDATE(),
		CONCAT(
			'CarTypes_DELETE: Car Type was deleted with: @Title = ',
			'"',
			(SELECT Title FROM DELETED),
			'"',
			' @Id = ',
			'"',
			(SELECT Id FROM DELETED),
			'"'
		)
	);
END