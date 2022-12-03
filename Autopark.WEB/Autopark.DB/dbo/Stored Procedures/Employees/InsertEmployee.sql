CREATE PROCEDURE [dbo].[InsertEmployee]
	@Id INT
AS
BEGIN
	INSERT INTO [dbo].[Employees]
	(Id, StartDate, EndDate)
	VALUES(@Id, GETDATE(), NULL);
END