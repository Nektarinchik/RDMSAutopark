CREATE TABLE [dbo].[Logs] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [UserId]     INT            NULL,
    [LogTime]    DATETIME       NOT NULL,
    [LogMessage] NVARCHAR (MAX) NOT NULL,
    CONSTRAINT [PK_Logs_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK ([LogTime]<=getdate()),
    CONSTRAINT [FK_Logs_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE SET NULL ON UPDATE CASCADE
);





GO
CREATE NONCLUSTERED INDEX [IX_Logs_UserId]
    ON [dbo].[Logs]([UserId] ASC);

