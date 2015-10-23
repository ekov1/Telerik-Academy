namespace StudentSystem.ConsoleApp
{
    using Data;
    using Seeder;

    public class Startup
    {
        public static void Main()
        {
            var data = new StudentSystemDbContext();

            MaterialsImporter.Seed(data, 40);

            CoursesImporter.Seed(data, 40);

            StudentsImporter.Seed(data);

            HomeworksImporter.Seed(data);
        }
    }
}
