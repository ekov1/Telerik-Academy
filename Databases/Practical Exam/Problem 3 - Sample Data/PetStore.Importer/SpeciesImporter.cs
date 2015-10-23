namespace PetStore.Importer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Data;

    public class SpeciesImporter
    {
        public static void GenerateSpecies(PetStoreEntities data, int amount = 100)
        {
            var countries = data.Countries.OrderBy(e => Guid.NewGuid());

            var hash = new HashSet<string>();

            Console.WriteLine("Importing species for each country...");
            foreach (var country in countries)
            {
                // Average of 5, as per Ivaylo's video... or as per Basic Maths
                var numberOfSpecies = RandomGenerator.GetNumber(2, 8);

                for (int i = 0; i < numberOfSpecies; i++)
                {
                    var speciesName = RandomGenerator.GetString(5, 50);

                    if (hash.Contains(speciesName.ToLower()))
                    {
                        i--;
                        continue;
                    }

                    hash.Add(speciesName.ToLower());

                    var species = new Species
                    {
                        Name = speciesName
                    };

                    country.Species.Add(species);
                }
            }

            data.SaveChanges();
        }
    }
}
