CREATE PROCEDURE [dbo].[UpdateCar]
	@Id            INT,
	@CarTypeId     INT,
	@CarShowroomId INT,
	@GenerationId  INT,
	@Price         FLOAT,
	@Vin           NVARCHAR(17),
	@Image         VARBINARY(MAX) = NULL,
	@YearOfRelease DATETIME2(7) = NULL
AS
BEGIN
	UPDATE [dbo].[Cars]
	SET CarTypeId     = @CarTypeId,
		CarShowroomId = @CarShowroomId,
		GenerationId  = @GenerationId,
		Price         = @Price,
		Vin           = @Vin,
		Image         = CONVERT(varbinary(max), @Image),
		YearOfRelease = @YearOfRelease
	WHERE Id = @Id;
END