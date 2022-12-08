CREATE TRIGGER [Employees_DELETE]
ON [dbo].[Employees]
AFTER DELETE
AS
BEGIN
	INSERT INTO [dbo].[Logs]
	(UserId, LogTime, LogMessage)
	VALUES(
		(SELECT CAST ((SELECT SESSION_CONTEXT(N'user_id')) AS INT)),
		GETDATE(),
		CONCAT(
			'Employees_DELETE: Employee was deleted with: @StartDate = ',
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
			'"'
		)
	);
END
