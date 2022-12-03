CREATE TRIGGER [Generations_INSERT]
ON Generations
AFTER INSERT
AS
BEGIN
	INSERT INTO [dbo].[Logs]
	(UserId, LogTime, LogMessage)
	VALUES(
		(SELECT CAST ((SELECT SESSION_CONTEXT(N'user_id')) AS INT)),
		GETDATE(),
		CONCAT(
			'Generations_INSERT: Generation was added with: @Title = ',
			'"',
			(SELECT Title FROM INSERTED),
			'"',
			' @Id = ',
			'"',
			(SELECT Id FROM INSERTED),
			'"',
			' @ModelId = ',
			'"',
			(SELECT ModelId FROM INSERTED),
			'"'
		)
	);
END
