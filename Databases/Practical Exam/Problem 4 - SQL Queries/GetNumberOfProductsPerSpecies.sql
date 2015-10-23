USE PetStore

SELECT s.Name AS SpeciesName,
(SELECT COUNT(ProductId) 
	FROM SpeciesProducts 
	WHERE s.Id = sp.SpeciesId) AS ProductsPerSpecies
FROM SpeciesProducts sp
INNER JOIN Species s ON s.Id = sp.SpeciesId
INNER JOIN Products p ON p.Id = sp.ProductId
