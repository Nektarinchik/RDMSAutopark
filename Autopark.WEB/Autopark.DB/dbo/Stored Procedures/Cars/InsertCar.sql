CREATE PROCEDURE [dbo].[InsertCar]
	@CarTypeId     INT,
	@CarShowroomId INT,
	@GenerationId  INT,
	@Price         FLOAT
AS
BEGIN
	INSERT INTO [dbo].[Cars]
	(CarTypeId, CarShowroomid, GenerationId, Price)
	VALUES(@CarTypeId, @CarShowroomId, @GenerationId, @Price);
END