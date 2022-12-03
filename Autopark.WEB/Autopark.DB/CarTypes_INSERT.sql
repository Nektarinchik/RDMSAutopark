CREATE TRIGGER [CarTypes_INSERT]
ON [dbo].[CarTypes]
AFTER INSERT
AS
BEGIN
	INSERT INTO [dbo].[Logs]
	(UserId, LogTime, LogMessage)
	VALUES(
		(SELECT CAST ((SELECT SESSION_CONTEXT(N'user_id')) AS INT)),
		GETDATE(),
		CONCAT(
			'CarTypes_INSERT: Car Type was added with: @Title = ',
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
