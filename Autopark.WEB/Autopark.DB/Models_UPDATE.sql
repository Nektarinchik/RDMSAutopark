CREATE TRIGGER [Models_UPDATE]
ON [dbo].[Models]
AFTER UPDATE
AS
BEGIN
	INSERT INTO [dbo].[Logs]
	(UserId, LogTime, LogMessage)
	VALUES(
		(SELECT CAST ((SELECT SESSION_CONTEXT(N'user_id')) AS INT)),
		GETDATE(),
		CONCAT(
			'Models_UPDATE: Model was changed FROM @Title = ',
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
			'"',
			' TO @Title = ',
			'"',
			(SELECT Title FROM INSERTED),
			'"',
			' @Id = ',
			'"',
			(SELECT Id FROM INSERTED),
			'"',
			' @ManufacturerId = ',
			'"',
			(SELECT ManufacturerId FROM INSERTED),
			'"'
		)
	);
END
