CREATE TRIGGER [Generations_DELETE]
ON [dbo].[Generations]
AFTER DELETE
AS
BEGIN
	INSERT INTO [dbo].[Logs]
	(UserId, LogTime, LogMessage)
	VALUES(
		(SELECT CAST ((SELECT SESSION_CONTEXT(N'user_id')) AS INT)),
		GETDATE(),
		CONCAT(
			'Generations_DELETE: Generation was deleted with: @Title = ',
			'"',
			(SELECT Title FROM DELETED),
			'"',
			' @Id = ',
			'"',
			(SELECT Id FROM DELETED),
			'"',
			' @ModelId = ',
			'"',
			(SELECT ModelId FROM DELETED),
			'"'
		)
	);
END
