CREATE PROCEDURE [dbo].[InsertEmployee]
	@CustomerId INT
AS
BEGIN 
	INSERT INTO [dbo].[AspNetUserRoles]
	(UserId, RoleId)
	VALUES(@CustomerId,
		(SELECT DISTINCT Id
		 FROM [dbo].[AspNetRoles]
		 WHERE Name = 'EMPLOYEE')
	)
END
