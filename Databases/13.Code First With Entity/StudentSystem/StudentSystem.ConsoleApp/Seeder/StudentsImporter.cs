namespace StudentSystem.ConsoleApp.Seeder
{
    using System;
    using System.Linq;
    using Data;
    using Models;

    public class StudentsImporter
    {
        public static void Seed(StudentSystemDbContext data, int amount = 50)
        {
            var courses = data.Courses.OrderBy(x => Guid.NewGuid());
            var coursesCount = courses.Count();

            Console.WriteLine("Importing students...");
            for (int i = 0; i < amount; i++)
            {
                var student = new Student
                {
                    Name = RandomGenerator.GetString(2, 50),
                    Number = RandomGenerator.GetNumber(1, 50)
                };

                var coursesPerStudent = RandomGenerator.GetNumber(2, 4);

                for (int j = 0; j < coursesPerStudent; j++)
                {
                    var toSkip = RandomGenerator.GetNumber(0, coursesCount - 1);
                    student.Courses.Add(courses.Skip(toSkip).Take(1).First());
                }

                data.Students.Add(student);
            }

            data.SaveChanges();
        }
    }
}
