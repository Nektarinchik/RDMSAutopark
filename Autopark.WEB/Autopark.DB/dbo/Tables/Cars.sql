CREATE TABLE [dbo].[Cars] (
    [Id]            INT        IDENTITY (1, 1) NOT NULL,
    [CarTypeId]     INT        NOT NULL,
    [CarShowroomId] INT        NULL,
    [GenerationId]  INT        NOT NULL,
    [Price]         FLOAT (53) NULL,
    CONSTRAINT [PK_Cars_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK ([Price]>(0.0)),
    CONSTRAINT [FK_Cars_CarShowrooms_CarShowroomId] FOREIGN KEY ([CarShowroomId]) REFERENCES [dbo].[CarShowrooms] ([Id]) ON DELETE SET NULL ON UPDATE CASCADE,
    CONSTRAINT [FK_Cars_CarTypes_CarTypeId] FOREIGN KEY ([CarTypeId]) REFERENCES [dbo].[CarTypes] ([Id]) ON UPDATE CASCADE,
    CONSTRAINT [FK_Cars_Generations_GenerationId] FOREIGN KEY ([GenerationId]) REFERENCES [dbo].[Generations] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);



GO
CREATE TRIGGER [Cars_INSERT]
ON [dbo].[Cars]
AFTER INSERT
AS
BEGIN
	INSERT INTO [dbo].[Logs]
	(UserId, LogTime, LogMessage)
	VALUES(
		(SELECT CAST ((SELECT SESSION_CONTEXT(N'user_id')) AS INT)),
		GETDATE(),
		CONCAT(
			'Cars_INSERT: Car was added with: @Id = ',
			'"',
			(SELECT Id FROM INSERTED),
			'"',
			' @CarTypeId = ',
			'"',
			(SELECT CarTypeId FROM INSERTED),
			'"',
			' @CarShowroomId = ',
			'"',
			(SELECT CarShowroomId FROM INSERTED),
			'"',
			' @GenerationId = ',
			'"',
			(SELECT GenerationId FROM INSERTED),
			'"'
		)
	);
END