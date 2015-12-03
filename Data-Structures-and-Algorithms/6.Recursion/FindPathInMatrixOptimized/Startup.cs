namespace FindPathInMatrixOptimized
{
    using System;

    public static class Startup
    {
        public static void Main()
        {
            var matrix = new string[100, 100];

            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 100; j++)
                {
                    matrix[i, j] = "0";
                }
            }

            var start = new Position(3, 12);
            var end = new Position(66, 99);

            if (!Pathfinder.Find(start, end, matrix))
            {
                Console.WriteLine("Target destination was not reached!");
            }           
        }
    }
}
