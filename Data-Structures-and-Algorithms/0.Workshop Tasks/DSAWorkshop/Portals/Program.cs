using System;
using System.Collections.Generic;
using System.Linq;

namespace Portals
{
    class Program
    {
        private static int[,] matrix;
        private static bool[,] visited;
        private static int sum = 0;

        static void Main(string[] args)
        {
            var startingPoint = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var dimensions = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            matrix = new int[dimensions[0], dimensions[1]];
            visited = new bool[dimensions[0], dimensions[1]];

            for (int i = 0; i < dimensions[0]; i++)
            {
                var rowDesription =
                    Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int j = 0; j < dimensions[1]; j++)
                {
                    int number;

                    if (int.TryParse(rowDesription[j], out number))
                    {
                        matrix[i, j] = number;
                    }
                    else
                    {
                        matrix[i, j] = -1;
                    }
                }
            }

            TraverseLabyrinth(startingPoint[0], startingPoint[1], 0);
            Console.WriteLine(sum);
        }

        private static void TraverseLabyrinth(int row, int col, int currentSum)
        {
            visited[row, col] = true;

            if (CanTeleportWIthinMatrix(row + matrix[row, col], col)
                || CanTeleportWIthinMatrix(row - matrix[row, col], col)
                || CanTeleportWIthinMatrix(row, col + matrix[row, col])
                || CanTeleportWIthinMatrix(row, col - matrix[row, col]))
            {
                currentSum += matrix[row, col];
            }

            if (IsValidMove(row + matrix[row, col], col))
            {
                TraverseLabyrinth(row + matrix[row, col], col, currentSum);
            }

            if (IsValidMove(row - matrix[row, col], col))
            {
                TraverseLabyrinth(row - matrix[row, col], col, currentSum);
            }

            if (IsValidMove(row, col + matrix[row, col]))
            {
                TraverseLabyrinth(row, col + matrix[row, col], currentSum);
            }

            if (IsValidMove(row, col - matrix[row, col]))
            {
                TraverseLabyrinth(row, col - matrix[row, col], currentSum);
            }

            if (sum < currentSum)
            {
                sum = currentSum;
            }

            visited[row, col] = false;
        }

        private static bool IsValidMove(int row, int col)
        {
            return CanTeleportWIthinMatrix(row, col)
                   && !visited[row, col];
        }

        private static bool CanTeleportWIthinMatrix(int row, int col)
        {
            return row >= 0 && col >= 0
                && row < matrix.GetLength(0) && col < matrix.GetLength(1)
                && matrix[row, col] != -1 ;
        }
    }
}