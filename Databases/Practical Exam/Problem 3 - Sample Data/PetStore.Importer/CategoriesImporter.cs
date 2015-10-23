namespace PetStore.Importer
{
    using System;
    using Data;

    public class CategoriesImporter
    {
        public static void GenerateCategories(PetStoreEntities data, int amount = 50)
        {
            Console.WriteLine("Importing categories...");

            for (int i = 0; i < amount; i++)
            {
                data.Categories.Add(new Category
                {
                    Name = RandomGenerator.GetString(5, 20)
                });
            }

            data.SaveChanges();
        }
    }
}
