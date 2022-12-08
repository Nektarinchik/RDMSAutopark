CREATE TRIGGER [Cars_DELETE]
ON [dbo].[Cars]
AFTER DELETE
AS
BEGIN
	INSERT INTO [dbo].[Logs]
	(UserId, LogTime, LogMessage)
	VALUES(
		(SELECT CAST ((SELECT SESSION_CONTEXT(N'user_id')) AS INT)),
		GETDATE(),
		CONCAT(
			'Cars_DELETE: Car was deleted with: @CarTypeId = ',
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
			'"'
		)
	);
END