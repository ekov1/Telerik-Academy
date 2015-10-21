namespace DataSeeder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Company.Data;

    public class EmployeesImporter
    {
        private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890abcdefghijklmnopqrstuvwxyz";

        private static readonly int len = Alphabet.Length;

        private static Random rng = new Random();

        public static IList<Employee> GenerateEmployees(int amount = 5000, int reportsEach = 50)
        {
            var departments = DepartmentsImporter.GenerateDepartments();

            var listOfManagers = new List<Employee>();

            for (int i = 0; i < amount * 0.05; i++)
            {
                var employee = new Employee
                {
                    FirstName = GetShlyokaShlyoka(10, 20),
                    LastName = GetShlyokaShlyoka(10, 20),
                    Salary = rng.Next(50000, 200001),
                    Department = departments[rng.Next(1, 100)]
                };

                for (int j = 0; j < reportsEach; j++)
                {
                    employee.Reports.Add(GetReport());
                }

                listOfManagers.Add(employee);
            }

            var employeeList = new List<Employee>();

            for (int i = 0; i < amount * 0.95; i++)
            {
                var employee = new Employee
                {
                    FirstName = GetShlyokaShlyoka(10, 20),
                    LastName = GetShlyokaShlyoka(10, 20),
                    Salary = rng.Next(50000, 200001),
                    Department = departments[rng.Next(1, 100)],
                    Employee1 = listOfManagers[rng.Next(1, listOfManagers.Count)]
                };

                employeeList.Add(employee);

                for (int j = 0; j < reportsEach; j++)
                {
                    employee.Reports.Add(GetReport());
                }
            }

            return listOfManagers.Union(employeeList).ToList();
        }

        private static string GetShlyokaShlyoka(int minLen, int maxLen)
        {
            var sb = new StringBuilder();

            for (int j = 0; j < rng.Next(minLen, maxLen+1); j++)
            {
                sb.Append(Alphabet[rng.Next() % len]);
            }

            return sb.ToString();
        }

        private static Report GetReport()
        {
            var r = new Report
            {
                Time = GetRandomDate(DateTime.Now.AddYears(-4), DateTime.Now.AddYears(4))
            };

            return r;
        }

        private static DateTime GetRandomDate(DateTime from, DateTime to)
        {
            var range = to - from;

            var randTimeSpan = new TimeSpan((long)(rng.NextDouble() * range.Ticks));

            return from + randTimeSpan;
        }
    }
}
