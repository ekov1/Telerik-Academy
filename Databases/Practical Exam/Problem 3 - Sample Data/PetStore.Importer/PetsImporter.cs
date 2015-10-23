namespace PetStore.Importer
{
    using System;
    using System.Linq;
    using Data;

    public class PetsImporter
    {
        public static void GeneratePets(PetStoreEntities data)
        {
            var species = data.Species.OrderBy(e => Guid.NewGuid());
            var colors = data.Colors.Select(c => c.Id).ToList();
            var colorsLen = colors.Count;

            Console.WriteLine("Importing pets for each species...");
            foreach (var entry in species)
            {
                // Average of 50
                var numberOfPets = RandomGenerator.GetNumber(20, 80);

                for (int i = 0; i < numberOfPets; i++)
                {
                    var pet = new Pet
                    {
                        Price = RandomGenerator.GetDecimal(5, 2500),
                        ColorId = colors[RandomGenerator.GetNumber(0) % colorsLen],
                        DateOfBirth = RandomGenerator.GetDate(DateTime.Now.AddYears(-5), DateTime.Now.AddDays(-60)),
                        Breed = RandomGenerator.GetString(5, 15)
                    };

                    entry.Pets.Add(pet);
                }

                Console.Write(".");
            }

            Console.WriteLine();

            data.SaveChanges();
        }
    }
}
