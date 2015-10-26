namespace SortIntegers
{
    using System;
    using System.Collections.Generic;
    using Extensions;

    public static class Startup
    {
        [STAThread]
        public static void Main()
        {
            new[] { 15, 2, 6, 3, 7, 12, 4, -6, -11, 8, -2, 0, 9 }.CopyToClipboard();

            Console.WriteLine("A template sequence of integers has been copied to your clipboard!");

            var intList = new List<int>();

            while (true)
            {
                var input = Console.ReadLine();
                int currentNumber;

                if (string.IsNullOrWhiteSpace(input))
                {
                    break;
                }

                if (int.TryParse(input, out currentNumber))
                {
                    intList.Add(currentNumber);
                }
            }

            intList.Sort();

            Console.WriteLine(String.Join(" ", intList));
        }
    }
}
