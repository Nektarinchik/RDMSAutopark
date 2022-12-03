CREATE TRIGGER [Models_DELETE]
ON [dbo].[Models]
AFTER DELETE
AS
BEGIN
	INSERT INTO [dbo].[Logs]
	(UserId, LogTime, LogMessage)
	VALUES(
		(SELECT CAST ((SELECT SESSION_CONTEXT(N'user_id')) AS INT)),
		GETDATE(),
		CONCAT(
			'Models_DELETE: Model was deleted with: @Title = ',
			'"',
			(SELECT Title FROM DELETED),
			'"',
			' @Id = ',
			'"',
			(SELECT Id FROM DELETED),
			'"',
			' @ManufacturerId = ',
			'"',
			(SELECT ManufacturerId FROM DELETED),
			'"'
		)
	);
END
