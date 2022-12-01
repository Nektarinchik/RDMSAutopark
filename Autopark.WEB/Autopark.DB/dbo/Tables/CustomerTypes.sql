CREATE TABLE [dbo].[CustomerTypes] (
    [Id]    INT           IDENTITY (1, 1) NOT NULL,
    [Title] NVARCHAR (40) NOT NULL,
    CONSTRAINT [PK_CustomerTypes_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);



GO
CREATE TRIGGER [CutomerTypes_INSERT]
ON CustomerTypes 
AFTER INSERT
AS
BEGIN
	INSERT INTO [dbo].[Logs]
	(UserId, LogTime, LogMessage)
	VALUES(
		(SELECT CAST ((SELECT SESSION_CONTEXT(N'user_id')) AS INT)),
		GETDATE(),
		CONCAT(
			'CustomerTypes_INSERT: New customer type was added with: @Title = ',
			'"',
			(SELECT Title FROM INSERTED),
			'"',
			' @Id = ',
			'"',
			(SELECT Id FROM INSERTED),
			'"'
		)
	)
END
GO
CREATE TRIGGER [CustomerTypes_UPDATE]
ON [dbo].[CustomerTypes]
AFTER UPDATE
AS
BEGIN
	INSERT INTO [dbo].[Logs]
	(UserId, LogTime, LogMessage)
	VALUES(
		(SELECT CAST ((SELECT SESSION_CONTEXT(N'user_id')) AS INT)),
		GETDATE(),
		CONCAT(
			'CustomerTypes_UPDATE: Customer Type was changed FROM @Title = ',
			'"',
			(SELECT Title FROM DELETED),
			'"',
			' @Id = ',
			'"',
			(SELECT Id FROM DELETED),
			'"',
			' TO @Title = ',
			'"',
			(SELECT Title FROM INSERTED),
			'"',
			' @Id = ',
			'"',
			(SELECT Id FROM INSERTED),
			'"'
		)
	);
END
GO
CREATE TRIGGER [CustomerTypes_DELETE]
ON [dbo].[CustomerTypes]
AFTER DELETE
AS
BEGIN
	INSERT INTO [dbo].[Logs]
	(UserId, LogTime, LogMessage)
	VALUES(
		(SELECT CAST ((SELECT SESSION_CONTEXT(N'user_id')) AS INT)),
		GETDATE(),
		CONCAT(
			'CustomerTypes_DELETE: Customer type was deleted with: @Title = ',
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