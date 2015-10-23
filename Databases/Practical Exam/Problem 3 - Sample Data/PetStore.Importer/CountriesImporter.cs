namespace PetStore.Importer
{
    using System;
    using System.Collections.Generic;
    using Data;

    public class CountriesImporter
    {
        public static void GenerateCountries(PetStoreEntities data,int amount = 20)
        {
            var hash = new HashSet<string>();

            Console.WriteLine("Importing countries...");
            for (int i = 0; i < amount; i++)
            {
                var countryName = RandomGenerator.GetString(5, 50);

                if (hash.Contains(countryName.ToLower()))
                {
                    i--;
                    continue;
                }

                hash.Add(countryName.ToLower());

                data.Countries.Add(new Country
                {
                    Name = countryName
                });
            }

            data.SaveChanges();
        }
    }
}
