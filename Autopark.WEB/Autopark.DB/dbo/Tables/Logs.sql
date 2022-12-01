CREATE TABLE [dbo].[Logs] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [UserId]     INT            NULL,
    [LogTime]    DATETIME       NOT NULL,
    [LogMessage] NVARCHAR (256) NOT NULL,
    CONSTRAINT [PK_Logs_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT FK_Logs_AspNetUsers_UserId FOREIGN KEY (UserId) REFERENCES AspNetUsers (Id)
		ON DELETE SET NULL
		ON UPDATE CASCADE,
    CHECK ([LogTime]<=getdate())
);


