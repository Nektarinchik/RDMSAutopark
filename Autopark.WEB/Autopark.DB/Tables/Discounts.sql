CREATE TABLE [dbo].[Discounts]
(
	[Id]    INT          NOT NULL IDENTITY (1, 1),
	[Title] NVARCHAR(40) NOT NULL,
	[Value] INT          NOT NULL CHECK ([Value] >= 0 AND [Value] <= 100),

	CONSTRAINT PK_Discounts_Id PRIMARY KEY (Id)
)
