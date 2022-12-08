CREATE PROCEDURE [dbo].[UpdateCar]
	@Id            INT,
	@CarTypeId     INT,
	@CarShowroomId INT,
	@GenerationId  INT,
	@Price         FLOAT,
	@Vin           NVARCHAR(17)
AS
BEGIN
	UPDATE [dbo].[Cars]
	SET CarTypeId     = @CarTypeId,
		CarShowroomId = @CarShowroomId,
		GenerationId  = @GenerationId,
		Price         = @Price,
		Vin           = @Vin
	WHERE Id = @Id;
END