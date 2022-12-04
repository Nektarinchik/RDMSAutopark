CREATE PROCEDURE [dbo].[UpdateCar]
	@Id            INT,
	@CarTypeId     INT,
	@CarShowroomId INT,
	@GenerationId  INT,
	@Price         FLOAT
AS
BEGIN
	UPDATE [dbo].[Cars]
	SET CarTypeId     = @CarTypeId,
		CarShowroomId = @CarShowroomId,
		GenerationId  = @GenerationId,
		Price         = @Price
	WHERE Id = @Id;
END