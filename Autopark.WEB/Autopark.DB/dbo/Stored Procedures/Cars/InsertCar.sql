CREATE PROCEDURE [dbo].[InsertCar]
	@CarTypeId     INT,
	@CarShowroomId INT,
	@GenerationId  INT,
	@Price         FLOAT,
	@Vin           NVARCHAR(17),
	@Image         VARBINARY(MAX) = NULL,
	@YearOfRelease DATETIME2(7) = NULL
AS
BEGIN
	INSERT INTO [dbo].[Cars]
	(CarTypeId, CarShowroomid, GenerationId, Price, Vin, Image, YearOfRelease)
	VALUES(@CarTypeId, @CarShowroomId, @GenerationId, @Price, @Vin, CONVERT(varbinary(max), @Image), @YearOfRelease);
END