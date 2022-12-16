CREATE VIEW [dbo].[vCustomers]
	AS SELECT
		[dbo].[AspNetUsers].[Id],
		[dbo].[AspNetUsers].[UserName] AS CustomerName
	FROM [dbo].[AspNetUsers]
		INNER JOIN [dbo].[AspNetUserRoles]
			ON [dbo].[AspNetUsers].[Id] = [dbo].[AspNetUserRoles].[UserId]
		INNER JOIN [dbo].[AspNetRoles]
			ON [AspNetUserRoles].[RoleId] = [dbo].[AspNetRoles].[Id]
	WHERE [dbo].[AspNetRoles].[Name] = 'customer';
