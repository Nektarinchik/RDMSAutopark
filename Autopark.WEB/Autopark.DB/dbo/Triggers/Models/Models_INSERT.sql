CREATE TRIGGER [Models_INSERT]
ON [dbo].[Models]
AFTER INSERT
AS
BEGIN
	INSERT INTO [dbo].[Logs]
	(UserId, LogTime, LogMessage)
	VALUES(
		(SELECT CAST ((SELECT SESSION_CONTEXT(N'user_id')) AS INT)),
		GETDATE(),
		CONCAT(
			'Models_INSERT: Model was added with: @Title = ',
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
	)
END
