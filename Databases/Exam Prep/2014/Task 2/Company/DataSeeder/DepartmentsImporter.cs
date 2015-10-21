namespace DataSeeder
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Company.Data;

    public class DepartmentsImporter
    {
        private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890abcdefghijklmnopqrstuvwxyz";

        private static readonly int len = Alphabet.Length;

        private static Random rng = new Random();

        public static IList<Department> GenerateDepartments(int amount = 100)
        {
            var list = new List<Department>();

            var hashset = new HashSet<string>();

            for (int i = 0; i < amount; i++)
            {
                var name = new StringBuilder();

                for (int j = 0; j < rng.Next(10, 51); j++)
                {
                    name.Append(Alphabet[rng.Next()%len]);
                }

                var nameToString = name.ToString();

                if (hashset.Contains(nameToString))
                {
                    i--;
                    continue;
                }

                hashset.Add(nameToString);
                list.Add(new Department
                {
                    Name = nameToString
                });
            }

            return list;
        }
    }
}
