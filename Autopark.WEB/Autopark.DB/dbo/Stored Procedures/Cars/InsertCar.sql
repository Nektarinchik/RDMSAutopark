CREATE PROCEDURE [dbo].[InsertCar]
	@CarTypeId     INT,
	@CarShowroomId INT,
	@GenerationId  INT,
	@Price         FLOAT,
	@Vin           NVARCHAR(17),
	@Image         VARBINARY(MAX) = NULL
AS
BEGIN
	INSERT INTO [dbo].[Cars]
	(CarTypeId, CarShowroomid, GenerationId, Price, Vin, Image)
	VALUES(@CarTypeId, @CarShowroomId, @GenerationId, @Price, @Vin, CONVERT(varbinary(max), @Image));
END