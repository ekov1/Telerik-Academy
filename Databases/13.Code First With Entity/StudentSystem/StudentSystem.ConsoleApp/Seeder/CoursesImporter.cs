namespace StudentSystem.ConsoleApp.Seeder
{
    using System;
    using System.Linq;
    using Data;
    using Models;

    public class CoursesImporter
    {
        public static void Seed(StudentSystemDbContext data, int amount = 30)
        {
            var amountOfMaterials = RandomGenerator.GetNumber(2, 4);
            var materials = data.Materials.OrderBy(x => Guid.NewGuid());
            var materialsCount = materials.Count();

            Console.WriteLine("Importing courses...");
            for (int i = 0; i < amount; i++)
            {
                var course = new Course
                {
                    Description = RandomGenerator.GetString(10, 100),
                    Name = RandomGenerator.GetString(5, 25),
                };

                for (int j = 0; j < amountOfMaterials; j++)
                {
                    var toSkip = RandomGenerator.GetNumber(0, materialsCount - 1);
                    course.Materials.Add(materials.Skip(toSkip).Take(1).First());
                }

                data.Courses.Add(course);
            }

            data.SaveChanges();
        }
    }
}
