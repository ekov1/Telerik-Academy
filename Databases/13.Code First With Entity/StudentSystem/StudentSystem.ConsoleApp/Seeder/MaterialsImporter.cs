namespace StudentSystem.ConsoleApp.Seeder
{
    using System;
    using Data;
    using Models;

    public class MaterialsImporter
    {
        public static void Seed(StudentSystemDbContext data, int amount = 20)
        {
            Console.WriteLine("Importing course materials...");
            for (int i = 0; i < amount; i++)
            {
                data.Materials.Add(new Material
                {
                    Description = RandomGenerator.GetString(10, 100),
                    Type = (MaterialType) RandomGenerator.GetNumber(1, 3)
                });
            }

            data.SaveChanges();
        }
    }
}
