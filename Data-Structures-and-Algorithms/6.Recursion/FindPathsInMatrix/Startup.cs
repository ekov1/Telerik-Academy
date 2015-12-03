namespace FindPathsInMatrix
{
    using System;

    public static class Startup
    {
        private static int[,] matrix = new[,]
       {
           {1, 0, 0, 1, 0, 1, 0, 0, 1},
           {1, 0, 0, 0, 0, 1, 0, 0, 1},
           {0, 0, 1, 0, 1, 1, 0, 0, 0},
           {1, 1, 0, 0, 0, 0, 0, 1, 1},
           {1, 0, 0, 1, 0, 1, 0, 0, 0}
       };

        private static int[,] matrixD = new[,]
        {
            {0, 0, 1, 0},
            {0, 0, 0, 1},
            {0, 0, 1, 0},
            {1, 0, 0, 0}
        };

        public static void Main()
        {
            Traverse(2, 0, 4, 4, matrix);

            Console.WriteLine();

            Traverse(0, 0, 3, 3, matrixD);
        }

        private static void Traverse(int row, int col, int tarRow, int tarCol, int[,] matrix)
        {
            if (row == tarRow && col == tarCol)
            {
                Console.WriteLine("Target destination was found!");
                return;
            }

            if (!IsValid(row, col, matrix))
            {
                return;
            }

            if (!IsInPath(row, col, matrix))
            {
                return;
            }

            matrix[row, col] = -1;

            Traverse(row, col + 1, tarRow, tarCol, matrix);
            Traverse(row, col - 1, tarRow, tarCol, matrix);
            Traverse(row + 1, col, tarRow, tarCol, matrix);
            Traverse(row - 1, col, tarRow, tarCol, matrix);

            matrix[row, col] = 0;
        }

        private static bool IsValid(int row, int col, int[,] matrix)
        {
            if ((row >= 0 && row < matrix.GetLength(0)) && (col >= 0 && col < matrix.GetLength(1)))
            {
                return true;
            }

            return false;
        }

        private static bool IsInPath(int row, int col, int[,] matrix)
        {
            if (matrix[row, col] == 0)
            {
                return true;
            }

            return false;
        }
    }
}
