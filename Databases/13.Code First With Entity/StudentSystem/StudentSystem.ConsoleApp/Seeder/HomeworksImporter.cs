namespace StudentSystem.ConsoleApp.Seeder
{
    using System;
    using System.Linq;
    using Data;
    using Models;

    public class HomeworksImporter
    {
        public static void Seed(StudentSystemDbContext data, int amount = 15)
        {
            var students = data.Students;
            var courseIds = data.Courses.Select(x => x.Id).ToList();

            Console.WriteLine("Importing homeworks for each student...");
            foreach (var student in students)
            {
                for (int i = 0; i < 15; i++)
                {
                    student.Homeworks.Add(new Homework
                    {
                        Content = RandomGenerator.GetString(10, 100),
                        CourseId = courseIds[RandomGenerator.GetNumber(1, courseIds.Count-1)],
                        Deadline = RandomGenerator.GetDate(DateTime.Now.AddDays(-10), DateTime.Now.AddDays(14))
                    });
                }
            }

            data.SaveChanges();
        }
    }
}
