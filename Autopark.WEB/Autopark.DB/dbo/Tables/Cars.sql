CREATE TABLE [dbo].[Cars] (
    [Id]            INT             IDENTITY (1, 1) NOT NULL,
    [CarTypeId]     INT             NOT NULL,
    [CarShowroomId] INT             NULL,
    [GenerationId]  INT             NOT NULL,
    [Price]         FLOAT (53)      NULL,
    [Vin]           NVARCHAR (17)   DEFAULT (N'') NOT NULL,
    [Image]         VARBINARY (MAX) NULL,
    [YearOfRelease] DATETIME2 (7)   NULL,
    CONSTRAINT [PK_Cars_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK ([Price]>(0.0)),
    CONSTRAINT [FK_Cars_CarShowrooms_CarShowroomId] FOREIGN KEY ([CarShowroomId]) REFERENCES [dbo].[CarShowrooms] ([Id]) ON DELETE SET NULL ON UPDATE CASCADE,
    CONSTRAINT [FK_Cars_CarTypes_CarTypeId] FOREIGN KEY ([CarTypeId]) REFERENCES [dbo].[CarTypes] ([Id]) ON UPDATE CASCADE,
    CONSTRAINT [FK_Cars_Generations_GenerationId] FOREIGN KEY ([GenerationId]) REFERENCES [dbo].[Generations] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);




