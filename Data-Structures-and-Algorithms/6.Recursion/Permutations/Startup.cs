namespace Permutations
{
    using System;
    using System.Linq;
    using System.Text;

    public static class Startup
    {
        private static StringBuilder sb;

        public static void Main()
        {
            Console.Write("Define the length of the permutations (n = 3, 6, 10?): ");
            var n = int.Parse(Console.ReadLine());
            var arr = new int[n];

            sb = new StringBuilder();

            Permute(1, n, 0, arr);
            
            Console.WriteLine(sb.ToString());
        }

        private static void Permute(int min, int max, int index, int[] arr)
        {
            if (index >= arr.Length)
            {
                sb.AppendLine(string.Format("{{ {0} }}", string.Join(" ", arr)));
                return;
            }

            for (int i = min; i <= max; i++)
            {
                if (!arr.Contains(i))
                {
                    arr[index] = i;
                    Permute(min, max, index + 1, arr);
                    arr[index] = 0;
                }
            }
        }
    }
}
