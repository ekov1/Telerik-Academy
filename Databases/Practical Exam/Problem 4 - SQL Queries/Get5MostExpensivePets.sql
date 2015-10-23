USE PetStore

SELECT TOP 5 Breed, Price, DateOfBirth AS [Birth Year]
FROM Pets
WHERE DateOfBirth >= '2012-01-01'
ORDER BY Price DESC