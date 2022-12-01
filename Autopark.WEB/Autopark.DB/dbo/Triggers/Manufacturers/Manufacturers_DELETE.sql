CREATE TRIGGER [Manufacturers_DELETE]
ON Manufacturers
AFTER DELETE
AS
BEGIN
	INSERT INTO [dbo].[Logs]
	(UserId, LogTime, LogMessage)
	VALUES(
		(SELECT CAST ((SELECT SESSION_CONTEXT(N'user_id')) AS INT)),
		GETDATE(),
		CONCAT(
			'Manufacturers_DELETE: Manufacturer was deleted with: @Title = ',
			'"',
			(SELECT Title FROM DELETED),
			'"',
			' @Id = ',
			'"',
			(SELECT Id FROM DELETED),
			'"'
		)
	);
END
