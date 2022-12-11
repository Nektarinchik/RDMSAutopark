CREATE TABLE [dbo].[AspNetRoles] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [Name]             NVARCHAR (256) NULL,
    [NormalizedName]   NVARCHAR (256) NULL,
    [ConcurrencyStamp] NVARCHAR (MAX) NULL,
    [EndDate]          DATETIME2 (7)  NULL,
    [StartDate]        DATETIME2 (7)  NULL,
    CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED ([Id] ASC)
);




GO
CREATE UNIQUE NONCLUSTERED INDEX [RoleNameIndex]
    ON [dbo].[AspNetRoles]([NormalizedName] ASC) WHERE ([NormalizedName] IS NOT NULL);

