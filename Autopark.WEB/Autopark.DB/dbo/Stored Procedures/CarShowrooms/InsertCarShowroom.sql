CREATE PROCEDURE [dbo].[InsertCarShowroom]
	@Title  NVARCHAR(40),
	@Rating INT,
	@Phone  NVARCHAR(40)
AS
BEGIN
	INSERT INTO [dbo].[CarShowrooms]
	(Title, Rating, Phone)
	VALUES(@Title, @Rating, @Phone);
END