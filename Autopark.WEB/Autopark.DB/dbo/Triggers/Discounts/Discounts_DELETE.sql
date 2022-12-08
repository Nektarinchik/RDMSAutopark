CREATE TRIGGER [Discounts_DELETE]
ON [dbo].[Discounts]
AFTER DELETE
AS
BEGIN
	INSERT INTO [dbo].[Logs]
	(UserId, LogTime, LogMessage)
	VALUES(
		(SELECT CAST ((SELECT SESSION_CONTEXT(N'user_id')) AS INT)),
		GETDATE(),
		CONCAT(
			'Discounts_DELETE: Discount was deleted with: @Title = ',
			'"',
			(SELECT Title FROM DELETED),
			'"',
			' @Id = ',
			'"',
			(SELECT Id FROM DELETED),
			'"',
			' @Value = ',
			'"',
			(SELECT Value FROM DELETED),
			'"'
		)
	);
END
