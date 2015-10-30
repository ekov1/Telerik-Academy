namespace LabyrinthTraversal
{
    using System;

    public static class Startup
    {
        const string unreachableCell = "u";
        const string wallCell = "x";
        const string startingCell = "*";
        const string unfilledCell = "0";

        static readonly int[] rowsDeltas = { -1, 0, 1, 0 };

        static readonly int[] colsDeltas = { 0, 1, 0, -1 };

        public static void Main()
        {
            string[,] labyrinth = 
            {
                {"0", "0", "0", "x", "0", "x"},
                {"0", "x", "0", "x", "0", "x"},
                {"0", "*", "x", "0", "x", "0"},
                {"0", "x", "0", "0", "0", "0"},
                {"0", "0", "0", "x", "x", "0"},
                {"0", "0", "0", "x", "0", "x"}
            };

            PrintMatrix(labyrinth);

            var currentRow = 2;
            var currentCol = 1;

            TraverseLabyrinth(currentRow, currentCol, labyrinth, 0);

            PrintMatrix(labyrinth);
        }

        private static void TraverseLabyrinth(int currentRow, int currentCol, string[,] labyrinth, int step)
        {
            if (!IsValidMove(currentRow, currentCol, labyrinth))
            {
                return;
            }

            if (labyrinth[currentRow, currentCol] == wallCell)
            {
                return;
            }

            if (labyrinth[currentRow, currentCol] != startingCell && labyrinth[currentRow, currentCol] != unfilledCell && step > int.Parse(labyrinth[currentRow, currentCol]))
            {
                return;
            }

            labyrinth[currentRow, currentCol] = step.ToString();


            for (int i = 0; i < rowsDeltas.Length; i++)
            {
                TraverseLabyrinth(currentRow + rowsDeltas[i], currentCol + colsDeltas[i], labyrinth, step + 1);
            }

        }

        private static void PrintMatrix(object[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write("{0,3} ", matrix[i, j]);
                }

                Console.WriteLine();
            }

            Console.WriteLine();
        }

        private static bool IsValidMove(int row, int col, string[,] labyrinth)
        {
            return (row >= 0 && row < labyrinth.GetLength(0))
                && (col >= 0 && col < labyrinth.GetLength(1));
        }
    }
}
