namespace DataSeeder
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Company.Data;

    public class ProjectsImporter
    {
        private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890abcdefghijklmnopqrstuvwxyz";

        private static readonly int len = Alphabet.Length;

        private static Random rng = new Random();

        public static IList<Project> GenerateProjects(int amount = 1000)
        {
            var listOfProjects = new List<Project>();

            var db = new CompanyEntities();

            var listOfEmployees = db.Employees.ToList();

            for (int i = 0; i < amount; i++)
            {
                var p = new Project
                {
                    Name = GetShlyokaShlyoka(10, 50),
                };

                var hash = new HashSet<int>();

                for (int j = 0; j < rng.Next(2, 9); j++)
                {
                    var empId = listOfEmployees[rng.Next(0, listOfEmployees.Count)].Id;

                    // This ensures that we wont get the same employee in one project twice!
                    if (!hash.Contains(empId))
                    {
                        hash.Add(empId);
                    }
                    else
                    {
                        i--;
                        continue;
                    }

                    var pe = new ProjectsEmployee
                    {
                        EmployeeId = empId,
                        StartDate = GetRandomDate(DateTime.Now.AddDays(-200), DateTime.Now),
                        EndDate = GetRandomDate(DateTime.Now.AddDays(1), DateTime.Now.AddYears(1))
                    };

                    p.ProjectsEmployees.Add(pe);
                }

                listOfProjects.Add(p);
            }

            return listOfProjects;
        }

        private static string GetShlyokaShlyoka(int minLen, int maxLen)
        {
            var sb = new StringBuilder();

            for (int j = 0; j < rng.Next(minLen, maxLen + 1); j++)
            {
                sb.Append(Alphabet[rng.Next() % len]);
            }

            return sb.ToString();
        }

        private static DateTime GetRandomDate(DateTime from, DateTime to)
        {
            var range = to - from;

            var randTimeSpan = new TimeSpan((long)(rng.NextDouble() * range.Ticks));

            return from + randTimeSpan;
        }
    }
}
