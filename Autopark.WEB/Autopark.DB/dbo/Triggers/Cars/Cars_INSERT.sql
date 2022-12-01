CREATE TRIGGER [Cars_INSERT]
ON [dbo].[Cars]
AFTER INSERT
AS
BEGIN
	INSERT INTO [dbo].[Logs]
	(UserId, LogTime, LogMessage)
	VALUES(
		(SELECT CAST ((SELECT SESSION_CONTEXT(N'user_id')) AS INT)),
		GETDATE(),
		CONCAT(
			'Cars_INSERT: Car was added with: @Id = ',
			'"',
			(SELECT Id FROM INSERTED),
			'"',
			' @CarTypeId = ',
			'"',
			(SELECT CarTypeId FROM INSERTED),
			'"',
			' @CarShowroomId = ',
			'"',
			(SELECT CarShowroomId FROM INSERTED),
			'"',
			' @GenerationId = ',
			'"',
			(SELECT GenerationId FROM INSERTED),
			'"'
		)
	);
END
