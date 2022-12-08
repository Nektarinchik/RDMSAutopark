CREATE TABLE [dbo].[Manufacturers] (
    [Id]    INT           IDENTITY (1, 1) NOT NULL,
    [Title] NVARCHAR (40) NOT NULL,
    CONSTRAINT [PK_Manufacturers_Id] PRIMARY KEY CLUSTERED ([Id] ASC)
);