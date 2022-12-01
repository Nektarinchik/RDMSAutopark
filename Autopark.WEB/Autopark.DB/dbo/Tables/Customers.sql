CREATE TABLE [dbo].[Customers] (
    [Id]              INT        NOT NULL,
    [CustomerTypeId]  INT        NOT NULL,
    [SpendingBalance] FLOAT (53) NULL,
    CONSTRAINT [PK_Customers_Id] PRIMARY KEY CLUSTERED ([Id] ASC),
    CHECK ([SpendingBalance]>=(0)),
    CONSTRAINT [FK_Customers_CustomerTypes_CustomerTypeId] FOREIGN KEY ([CustomerTypeId]) REFERENCES [dbo].[CustomerTypes] ([Id]),
    CONSTRAINT FK_Customers_AspNetUsers_Id FOREIGN KEY (Id) REFERENCES AspNetUsers (Id)
		ON DELETE NO ACTION
		ON UPDATE CASCADE,
);


