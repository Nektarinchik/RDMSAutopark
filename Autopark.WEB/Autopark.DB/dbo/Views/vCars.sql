CREATE VIEW [dbo].[vCars]
	AS SELECT CONCAT(
		[dbo].[Manufacturers].[Title],
		' ',
		[dbo].[Models].[Title],
		' ',
		[dbo].[Generations].[Title]
		) AS Title,
		[dbo].[Cars].[Id]
	FROM [dbo].[Cars] 
		INNER JOIN [dbo].[Generations] 
			ON [dbo].[Cars].[GenerationId] = [dbo].[Generations].[Id]
		INNER JOIN [dbo].[Models] 
			ON [dbo].[Generations].[ModelId] = [dbo].[Models].[Id]
		INNER JOIN [dbo].[Manufacturers] 
			ON [dbo].[Models].[ManufacturerId] = [dbo].[Manufacturers].[Id];