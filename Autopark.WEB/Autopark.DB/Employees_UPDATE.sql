CREATE TRIGGER [Employees_UPDATE]
ON [dbo].[Employees]
AFTER UPDATE
AS
BEGIN
	INSERT INTO [dbo].[Logs]
	(UserId, LogTime, LogMessage)
	VALUES(
		(SELECT CAST ((SELECT SESSION_CONTEXT(N'user_id')) AS INT)),
		GETDATE(),
		CONCAT(
			'Employees_UPDATE: Employee was changed FROM @StartDate = ',
			'"',
			(SELECT StartDate FROM DELETED),
			'"',
			' @Id = ',
			'"',
			(SELECT Id FROM DELETED),
			'"',
			' @EndDate = ',
			'"',
			(SELECT EndDate FROM DELETED),
			'"',
			' @UserName = ',
			'"',
			(SELECT [dbo].[AspNetUsers].[UserName]
			 FROM DELETED 
				INNER JOIN [dbo].[AspNetUsers] ON DELETED.Id = [dbo].[AspNetUsers].[Id]
			),
			'"',
			' TO @StartDate = ',
			'"',
			(SELECT StartDate FROM INSERTED),
			'"',
			' @Id = ',
			'"',
			(SELECT Id FROM INSERTED),
			'"',
			' @EndDate = ',
			'"',
			(SELECT EndDate FROM INSERTED),
			'"',
			' @UserName = ',
			'"',
			(SELECT [dbo].[AspNetUsers].[UserName]
			 FROM INSERTED 
				INNER JOIN [dbo].[AspNetUsers] ON INSERTED.Id = [dbo].[AspNetUsers].[Id]
			),
			'"'
		)
	);
END
