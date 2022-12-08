CREATE PROCEDURE [dbo].[InsertCar]
	@CarTypeId     INT,
	@CarShowroomId INT,
	@GenerationId  INT,
	@Price         FLOAT,
	@Vin           NVARCHAR(17)
AS
BEGIN
	INSERT INTO [dbo].[Cars]
	(CarTypeId, CarShowroomid, GenerationId, Price, Vin)
	VALUES(@CarTypeId, @CarShowroomId, @GenerationId, @Price, @Vin);
END