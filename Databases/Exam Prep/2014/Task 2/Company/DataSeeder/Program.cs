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

            var employees = EmployeesImporter.GenerateEmployees(500, 5);

            for (int i = 0; i < employees.Count; i++)
            {
                db.Employees.Add(employees[i]);

                if (i % 100 == 0)
                {
                    Console.Write(i + ". ");
                }
            }

            Console.WriteLine("Now saving departments, employees and their reports to the Db, please be patient...");
            Console.WriteLine(@"This normally takes between 3 and 5 minutes, leave it to work in background, or set" +
                              "The second parameter of the GenerateEmployees method to a lower number (5) to make it quick!" +
                              "Thank you :)");

            db.SaveChanges();
        }
    }
}
