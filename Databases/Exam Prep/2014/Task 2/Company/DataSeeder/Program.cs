namespace DataSeeder
{
    using System;
    using Company.Data;

    public class Program
    {
        public static void Main()
        {
            var db = new CompanyEntities();

            db.Configuration.AutoDetectChangesEnabled = false;
            db.Configuration.ValidateOnSaveEnabled = false;

            var start = DateTime.Now;

            var employees = EmployeesImporter.GenerateEmployees();

            for (int i = 0; i < employees.Count; i++)
            {
                db.Employees.Add(employees[i]);

                if (i % 100 == 0)
                {
                    Console.Write(i + ". ");
                }
            }

            Console.WriteLine("Now saving departments, employees and their reports to the Db, please be patient...");
            Console.WriteLine("This normally takes between 3 and 5 minutes, leave it to work in background, or set" +
                              "\nThe second parameter of the GenerateEmployees method to a lower number (5) to make it quicker!" +
                              "\nThank you :)");

            db.SaveChanges();

            var projects = ProjectsImporter.GenerateProjects();

            for (int i = 0; i < projects.Count; i++)
            {
                db.Projects.Add(projects[i]);
            }

            Console.WriteLine(@"Now saving projects with already created employees from the db, this should be quicker :)" +
                              "\nThank you for being patient!");

            db.SaveChanges();

            var end = DateTime.Now;

            Console.WriteLine("It's all over now :D !1!1!!");

            Console.WriteLine(end-start);
        }
    }
}
