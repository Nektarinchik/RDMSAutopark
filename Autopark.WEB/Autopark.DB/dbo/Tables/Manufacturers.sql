CREATE TABLE [dbo].[Manufacturers] (
    [Id]    INT           IDENTITY (1, 1) NOT NULL,
    [Title] NVARCHAR (40) NOT NULL,
    CONSTRAINT [PK_Manufacturers_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);



GO
CREATE TRIGGER [Manufacturers_UPDATE]
ON Manufacturers
AFTER UPDATE
AS
BEGIN
	INSERT INTO [dbo].[Logs]
	(UserId, LogTime, LogMessage)
	VALUES(
		(SELECT CAST ((SELECT SESSION_CONTEXT(N'user_id')) AS INT)),
		GETDATE(),
		CONCAT(
			'Manufacturers_UPDATE: Manufacturer was changed FROM @Title = ',
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
CREATE TRIGGER [Manufacturers_INSERT]
ON [dbo].[Manufacturers]
AFTER INSERT
AS
BEGIN
	INSERT INTO [dbo].[Logs]
	(UserId, LogTime, LogMessage)
	VALUES(
		(SELECT CAST ((SELECT SESSION_CONTEXT(N'user_id')) AS INT)),
		GETDATE(),
		CONCAT(
			'Manufacturers_INSERT: Manufacturer was added with: @Title = ',
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