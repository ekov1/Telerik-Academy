namespace DoublesCount
{
    using Extensions;
    using System;
    using System.Collections.Generic;

    public static class Startup
    {
        [STAThread]
        public static void Main()
        {
            new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5, 4, 1, 5, 0, 9, -1, 6 }.CopyToClipboard(" ", "");

            Console.WriteLine("Test input has been copied to the clipboard. Right-click to paste!");

            var doublesCount = new Dictionary<double, int>();

            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var item in input)
            {
                var parsedDouble = double.Parse(item);

                if (!doublesCount.ContainsKey(parsedDouble))
                {
                    doublesCount.Add(parsedDouble, 0);
                }

                doublesCount[parsedDouble]++;
            }

            Console.WriteLine(string.Join(Environment.NewLine, doublesCount));
        }
    }
}
