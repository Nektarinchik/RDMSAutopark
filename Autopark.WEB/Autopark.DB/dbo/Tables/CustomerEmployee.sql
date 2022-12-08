CREATE TABLE [dbo].[CustomerEmployee] (
    [Id]             INT IDENTITY (1, 1) NOT NULL,
    [EmployeeId]     INT NOT NULL,
    [CustomerUserId] INT NULL,
    CONSTRAINT [PK_CustomerEmployee_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CustomerEmployee_Customer_CustomerId] FOREIGN KEY ([CustomerUserId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_CustomerEmployee_Employee_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[Employees] ([Id]) ON DELETE CASCADE ON UPDATE CASCADE
);



GO
CREATE UNIQUE NONCLUSTERED INDEX [UQ_EmployeeId_CustomerId]
    ON [dbo].[CustomerEmployee]([EmployeeId] ASC, [CustomerUserId] ASC);

