CREATE VIEW [dbo].[vOrders]
	AS SELECT  
		[dbo].[Orders].[Id]       AS Id,
		[dbo].[Discounts].[Title] AS DiscountTitle,
		CONCAT(
			[dbo].[Manufacturers].[Title],
			' ',
			[dbo].[Models].[Title],
			' ',
			[dbo].[Generations].[Title]
		) AS CarTitle,
		[dbo].[vCustomers].[CustomerName] AS CustomerTitle,
		[dbo].[vEmployees].[EmployeeName] AS EmployeeTitle,
		[dbo].[Orders].[Date]             AS Date
	FROM [dbo].[Orders]
		INNER JOIN [dbo].[Cars]
			ON [dbo].[Orders].[CarId] = [dbo].[Cars].[Id]
		INNER JOIN [dbo].[Generations]
			ON [dbo].[Cars].[GenerationId] = [dbo].[Generations].[Id]
		INNER JOIN [dbo].[Models] 
			ON [dbo].[Generations].[ModelId] = [dbo].[Models].[Id]
		INNER JOIN [dbo].[Manufacturers]
			ON [dbo].[Models].[ManufacturerId] = [dbo].[Manufacturers].[Id]
		INNER JOIN [dbo].[Discounts]
			ON [dbo].[Orders].[DiscountId] = [dbo].[Discounts].[Id]
		INNER JOIN [dbo].[CustomerEmployee]
			ON [dbo].[Orders].[CustomerEmployeeId] = [dbo].[CustomerEmployee].[Id]
		INNER JOIN [dbo].[vCustomers]
			ON [dbo].[CustomerEmployee].[CustomerId] = [dbo].[vCustomers].[Id]
		INNER JOIN [dbo].[vEmployees]
			ON [dbo].[CustomerEmployee].EmployeeId = [dbo].[vEmployees].[Id]
