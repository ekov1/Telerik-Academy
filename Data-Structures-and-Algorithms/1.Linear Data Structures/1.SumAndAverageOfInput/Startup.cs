namespace SumAndAverageOfInput
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Extensions;

    public static class Startup
    {
        // The following attribute ensures that the application is single threaded, despite the use of multi-thread specific... stuff
        [STAThread]
        public static void Main()
        {
            new[] { 15, 2, 335, 3, 7, 21 }.CopyToClipboard();

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

            Console.WriteLine("Sum of the sequence " + intList.Sum());
            Console.WriteLine("Average of the sequence " + intList.Average());
        }
    }
}
