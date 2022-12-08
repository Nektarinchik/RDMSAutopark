CREATE TRIGGER [Cars_UPDATE]
ON [dbo].[Cars]
AFTER UPDATE
AS
BEGIN
	INSERT INTO [dbo].[Logs]
	(UserId, LogTime, LogMessage)
	VALUES(
		(SELECT CAST ((SELECT SESSION_CONTEXT(N'user_id')) AS INT)),
		GETDATE(),
		CONCAT(
			'Cars_UPDATE: Car was changed FROM @CarTypeId = ',
			'"',
			(SELECT CarTypeId FROM DELETED),
			'"',
			' @CarTypeTitle = ',
			'"',
			(SELECT [dbo].[CarTypes].[Title] FROM DELETED 
				INNER JOIN [dbo].[CarTypes] ON [dbo].[CarTypes].[Id] = DELETED.CarTypeId
				),
			'"',
			' @Id = ',
			'"',
			(SELECT Id FROM DELETED),
			'"',
			' @CarShowroomId = ',
			'"',
			(SELECT CarShowroomId FROM DELETED),
			'"',
			' @CarShowroomTitle = ',
			'"',
			(SELECT [dbo].[CarShowrooms].[Title] FROM DELETED 
				INNER JOIN [dbo].[CarShowrooms] ON DELETED.CarShowroomId = [dbo].[CarShowrooms].[Id]
				),
			'"',
			' @GenerationId = ',
			'"',
			(SELECT GenerationId FROM DELETED),
			'"',
			' @GenerationTitle = ',
			'"',
			(SELECT [dbo].[Generations].[Title] FROM DELETED 
				INNER JOIN [dbo].[Generations] ON DELETED.GenerationId = [dbo].[Generations].[Id]
				),
			'"',
			' @Price = ',
			'"',
			(SELECT Price FROM DELETED),
			'"',
			' @Vin = ',
			'"',
			(SELECT Vin FROM DELETED),
			'"',
			' TO @CarTypeId = ',
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
			'"',
			' @Vin = ',
			'"',
			(SELECT Vin FROM INSERTED),
			'"'
		)
	);
END
