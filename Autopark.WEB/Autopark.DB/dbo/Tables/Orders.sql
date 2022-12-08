CREATE TABLE [dbo].[Orders] (
    [Id]                 INT  IDENTITY (1, 1) NOT NULL,
    [CustomerEmployeeId] INT  NULL,
    [DiscountId]         INT  NULL,
    [CarId]              INT  NULL,
    [Date]               DATE NOT NULL,
    CONSTRAINT [PK_Orders_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK ([Date]<=getdate()),
    CONSTRAINT [FK_Orders_Cars_CarId] FOREIGN KEY ([CarId]) REFERENCES [dbo].[Cars] ([Id]) ON DELETE SET NULL ON UPDATE CASCADE,
    CONSTRAINT [FK_Orders_CustomerEmployee_CustomerEmployeeId] FOREIGN KEY ([CustomerEmployeeId]) REFERENCES [dbo].[CustomerEmployee] ([Id]) ON DELETE SET NULL ON UPDATE CASCADE,
    CONSTRAINT [FK_Orders_Discounts_DiscountId] FOREIGN KEY ([DiscountId]) REFERENCES [dbo].[Discounts] ([Id]) ON DELETE SET NULL ON UPDATE CASCADE
);



GO
CREATE NONCLUSTERED INDEX [IX_Orders_CarId]
    ON [dbo].[Orders]([CarId] ASC);

