CREATE TRIGGER [Employees_INSERT]
ON [dbo].[Employees]
AFTER INSERT
AS
BEGIN
	INSERT INTO [dbo].[Logs]
	(UserId, LogTime, LogMessage)
	VALUES(
		(SELECT CAST ((SELECT SESSION_CONTEXT(N'user_id')) AS INT)),
		GETDATE(),
		CONCAT(
			'Employees_INSERT: Employee was added with: @StartDate = ',
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
