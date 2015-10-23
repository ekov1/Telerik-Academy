namespace PetStore.ConsoleClient
{
    using System;
    using Data;
    using Importer;

    public class Startup
    {
        public static void Main()
        {
            var data = new PetStoreEntities();

            CountriesImporter.GenerateCountries(data);

            SpeciesImporter.GenerateSpecies(data);

            PetsImporter.GeneratePets(data);

            CategoriesImporter.GenerateCategories(data);

            Console.WriteLine("Products generation is slow and may take a while depending on your hardware...");
            Console.WriteLine("Set the GenerateProducts method's second parameter to a lower number if you wish!");

            ProductsImporter.GenerateProducts(data, 200);
        }
    }
}
