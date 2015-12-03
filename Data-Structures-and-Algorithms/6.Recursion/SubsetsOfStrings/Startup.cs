namespace SubsetsOfStrings
{
    using System;
    using System.Text;

    public static class Startup
    {
        private static StringBuilder sb;

        public static void Main()
        {
            var set = new[] { "test", "rock", "fun" };
            Console.Write("Define the length of the variations (n = 2, 3, 6, 10?): ");

            var n = int.Parse(Console.ReadLine());
            var arr = new string[n];

            sb = new StringBuilder();

            GenerateStringSubset(0, set.Length, 0, arr, set);

            Console.WriteLine(sb.ToString());
        }

        private static void GenerateStringSubset(int min, int max, int index, string[] arr, string[] set)
        {
            if (index >= arr.Length)
            {
                sb.AppendLine(string.Format("({0})", string.Join(" ", arr)));

                return;
            }

            for (int i = min; i < max; i++)
            {
                arr[index] = set[i];

                GenerateStringSubset(i + 1, max, index + 1, arr, set);
            }
        }
    }
}