namespace ReverseIntegers
{
    using System;
    using System.Collections.Generic;
    using Extensions;

    public static class Startup
    {
        [STAThread]
        public static void Main()
        {
            new[] { 15, 2, 6, 3, 7, 12, 4 }.CopyToClipboard(Environment.NewLine, "");

            Console.WriteLine("A template sequence of integers has been copied to your clipboard!");

            var numberOfInts = 5;

            var intStack = new Stack<int>();

            for (int i = 0; i < numberOfInts; i++)
            {
                var input = Console.ReadLine();
                int currentNumber;

                if (int.TryParse(input, out currentNumber))
                {
                    intStack.Push(currentNumber);
                }
            }

            for (int i = 0; i < numberOfInts; i++)
            {
                Console.Write(intStack.Pop() + " ");
            }

            Console.WriteLine();
        }
    }
}
