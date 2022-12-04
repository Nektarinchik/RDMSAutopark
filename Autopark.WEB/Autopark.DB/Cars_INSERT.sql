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
			'Cars_INSERT: Car was added with: @CarTypeId = ',
			'"',
			(SELECT CarTypeId FROM INSERTED),
			'"',
			' @CarTypeTitle = ',
			'"',
			(SELECT [dbo].[CarTypes].[Title] FROM INSERTED 
				INNER JOIN [dbo].[CarTypes] ON [dbo].[CarTypes].[Id] = INSERTED.CarTypeId
				),
			'"',
			' @Id = ',
			'"',
			(SELECT Id FROM INSERTED),
			'"',
			' @CarShowroomId = ',
			'"',
			(SELECT CarShowroomId FROM INSERTED),
			'"',
			' @CarShowroomTitle = ',
			'"',
			(SELECT [dbo].[CarShowrooms].[Title] FROM INSERTED 
				INNER JOIN [dbo].[CarShowrooms] ON INSERTED.CarShowroomId = [dbo].[CarShowrooms].[Id]
				),
			'"',
			' @GenerationId = ',
			'"',
			(SELECT GenerationId FROM INSERTED),
			'"',
			' @GenerationTitle = ',
			'"',
			(SELECT [dbo].[Generations].[Title] FROM INSERTED 
				INNER JOIN [dbo].[Generations] ON INSERTED.GenerationId = [dbo].[Generations].[Id]
				),
			'"',
			' @Price = ',
			'"',
			(SELECT Price FROM INSERTED),
			'"'
		)
	);
END
