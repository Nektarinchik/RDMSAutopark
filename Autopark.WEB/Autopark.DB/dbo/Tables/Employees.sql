CREATE TABLE [dbo].[Employees] (
    [Id]        INT  NOT NULL,
    [StartDate] DATE NOT NULL,
    [EndDate]   DATE NULL,
    CONSTRAINT [PK_Employees_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK ([EndDate]>=[StartDate] AND [EndDate]<=getdate()),
    CHECK ([StartDate]<=getdate())
);


