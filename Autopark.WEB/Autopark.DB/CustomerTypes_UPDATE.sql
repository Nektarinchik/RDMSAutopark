CREATE TRIGGER [CustomerTypes_UPDATE]
ON [dbo].[CustomerTypes]
FOR UPDATE
AS
BEGIN
	INSERT INTO [dbo].[Logs]
	(UserId, LogTime, LogMessage)
	VALUES(
		(SELECT CAST ((SELECT SESSION_CONTEXT(N'user_id')) AS INT)),
		GETDATE(),
		CONCAT(
			'CustomerTypes_UPDATE: Customer Type was changed FROM @Title = ',
			(SELECT Title FROM DELETED),
			' TO @Title = ',
			(SELECT Title FROM INSERTED)
		)
	);
END
