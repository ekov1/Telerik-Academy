namespace PetStore.Importer
{
    using System;
    using System.Linq;
    using Data;

    public class ProductsImporter
    {
        public static void GenerateProducts(PetStoreEntities data, int amountPerCategory = 400)
        {
            var categories = data.Categories.OrderBy(e => Guid.NewGuid()).Select(x => x.Id).ToList();
            var species = data.Species.OrderBy(e => Guid.NewGuid());
            var speciesCount = species.Count();

            data.Configuration.AutoDetectChangesEnabled = false;
            data.Configuration.ValidateOnSaveEnabled = false;

            Console.WriteLine("Importing products in each category.");
            foreach (var category in categories)
            {
                for (int j = 0; j < amountPerCategory; j++)
                {
                    var product = new Product
                    {
                        CategoryId = category,
                        Name = RandomGenerator.GetString(5, 25),
                        Price = RandomGenerator.GetDecimal(10, 1000)
                    };

                    var suitableSpecies = RandomGenerator.GetNumber(2, 10);

                    for (int i = 0; i < suitableSpecies; i++)
                    {
                        var toSkip = RandomGenerator.GetNumber(0, speciesCount-1);
                        product.Species.Add(species.Skip(toSkip).Take(1).First());
                    }

                    data.Products.Add(product);
                }

                Console.Write(".");
                data.SaveChanges();
            }

            Console.WriteLine();

            data.SaveChanges();
        }
    }
}
