CREATE TABLE [dbo].[Employees] (
    [Id]        INT  NOT NULL,
    [StartDate] DATE NOT NULL,
    [EndDate]   DATE NULL,
    CONSTRAINT [PK_Employees_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT FK_Employees_AspNetUsers_Id FOREIGN KEY (Id) REFERENCES AspNetUsers (Id)
		ON DELETE NO ACTION
		ON UPDATE NO ACTION,
    CHECK ([EndDate]>=[StartDate] AND [EndDate]<=getdate()),
    CHECK ([StartDate]<=getdate())
);


