namespace CombinationsWithoutDuplicates
{
    using System;
    using System.Text;

    public static class Startup
    {
        private static StringBuilder sb;

        public static void Main()
        {
            Console.Write("Define how many elements the set will contain (2, 3, 4... 10?): ");
            var n = int.Parse(Console.ReadLine());
            Console.Write("Define the size of each combination (2 -> x:x; 3 -> x:x:x...): ");
            var k = int.Parse(Console.ReadLine());

            sb = new StringBuilder();

            Combine(1, n, 0, new int[k]);

            Console.WriteLine(sb.ToString());
        }

        private static void Combine(int firstNum, int lastNum, int index, int[] arr)
        {
            if (index >= arr.Length)
            {
                sb.AppendLine(string.Format("({0})", string.Join(" ", arr)));

                return;
            }

            for (int i = firstNum; i <= lastNum; i++)
            {
                arr[index] = i;

                Combine(i + 1, lastNum, index + 1, arr);
            }
        }
    }
}
