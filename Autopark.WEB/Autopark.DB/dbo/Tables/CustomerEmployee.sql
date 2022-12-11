CREATE TABLE [dbo].[CustomerEmployee] (
    [Id]         INT IDENTITY (1, 1) NOT NULL,
    [EmployeeId] INT NULL,
    [CustomerId] INT NULL,
    CONSTRAINT [PK_CustomerEmployee_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_CustomerEmployee_Customer_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[AspNetUsers] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_CustomerEmployee_Employee_EmployeeId] FOREIGN KEY ([EmployeeId]) REFERENCES [dbo].[AspNetUsers] ([Id])
);





GO
CREATE UNIQUE NONCLUSTERED INDEX [UQ_EmployeeId_CustomerId]
    ON [dbo].[CustomerEmployee]([EmployeeId] ASC, [CustomerId] ASC);



