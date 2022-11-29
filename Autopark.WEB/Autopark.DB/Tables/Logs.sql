CREATE TABLE [dbo].[Logs]
(
	[Id]         INT           NOT NULL IDENTITY (1, 1),
	[UserId]     INT           NULL,
	[LogTime]    DATETIME      NOT NULL CHECK (LogTime <= GETDATE()),
	[LogMessage] NVARCHAR(256) NOT NULL,

	CONSTRAINT PK_Logs_Id PRIMARY KEY (Id),
	CONSTRAINT FK_Logs_AspNetUsers_UserId FOREIGN KEY (UserId) REFERENCES AspNetUsers (Id)
		ON DELETE SET NULL
		ON UPDATE CASCADE
)
