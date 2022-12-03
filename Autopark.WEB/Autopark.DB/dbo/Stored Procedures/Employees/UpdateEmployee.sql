CREATE PROCEDURE [dbo].[UpdateEmployee]
	@Id        INT,
	@StartDate DATE,
	@EndDate   DATE
AS
BEGIN
	UPDATE [dbo].[Employees]
	SET StartDate = @StartDate,
		EndDate   = @EndDate
	WHERE Id = @Id;
END