namespace FindLargestEmptyArea
{
    using System;

    public static class Startup
    {
        public static void Main()
        {
            string[,] matrix = new string[6, 6]
                {
                    { "0", "0", "0", "x", "0", "x"},
                    { "0", "x", "0", "x", "0", "x"},
                    { "0", "0", "x", "0", "x", "0"},
                    { "0", "x", "0", "0", "0", "0"},
                    { "0", "0", "0", "x", "x", "0"},
                    { "0", "0", "0", "x", "0", "x"},
                };

            var AreaFinder = new AreaFinder();
            var area = AreaFinder.FindLargestArea(matrix);

            Console.WriteLine("The cells from the largest area are:");
            Console.WriteLine("{0}", string.Join(" ", area));
        }
    }
}
