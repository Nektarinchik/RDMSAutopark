CREATE TRIGGER [Discounts_INSERT]
ON [dbo].[Discounts]
AFTER INSERT
AS
BEGIN
	INSERT INTO [dbo].[Logs]
	(UserId, LogTime, LogMessage)
	VALUES(
		(SELECT CAST ((SELECT SESSION_CONTEXT(N'user_id')) AS INT)),
		GETDATE(),
		CONCAT(
			'Discounts_INSERT: Discount was added with: @Title = ',
			'"',
			(SELECT Title FROM INSERTED),
			'"',
			' @Id = ',
			'"',
			(SELECT Id FROM INSERTED),
			'"',
			' @Value = ',
			'"',
			(SELECT Value FROM INSERTED),
			'"'
		)
	);
END