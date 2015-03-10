
    //Write a program that reads a text file containing a square matrix of numbers.
    //Find an area of size 2 x 2 in the matrix, with a maximal sum of its elements.
    //    The first line in the input file contains the size of matrix N.
    //    Each of the next N lines contain N numbers separated by space.
    //    The output should be a single number in a separate text file.

using System;
using System.IO;
using System.Linq;
class MaxAreaSum
{
    public static int size = 0;
    static void Main(string[] args)
    {
        GenerateMatrix();
        int[,] matrix;
        using (StreamReader reader = new StreamReader("matrix.txt"))
        {
            size = int.Parse(reader.ReadLine());
            matrix = new int[size, size];
            for (int i = 0; i < size; i++)
            {
                string number = reader.ReadLine();
                int[] temp = number.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
            .Select(x => int.Parse(x)).ToArray();
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = temp[j];
                }
            }
        }
        CalculateMaxPlatform(matrix);
    }

    private static void CalculateMaxPlatform(int[,] matrix)
    {
        int bestSum = int.MinValue;
        int bestRow = 0;
        int bestCol = 0;
        for (int row = 0; row < matrix.GetLength(0) - 1; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 1; col++)
            {
                int sum = 0;
                for (int platformRow = row; platformRow < row + 2; platformRow++)
                {
                    for (int platformCol = col; platformCol < col + 2; platformCol++)
                    {
                        sum += matrix[platformRow, platformCol];
                    }
                }
                if (sum > bestSum)
                {
                    bestSum = sum;
                    bestRow = row;
                    bestCol = col;
                }
            }
        }
        using (StreamWriter writer = new StreamWriter("output.txt"))
        {
            writer.WriteLine(bestSum);
        }
    }

    private static void GenerateMatrix()
    {
        using (StreamWriter writer = new StreamWriter("matrix.txt"))
        {
            writer.WriteLine("4");
            writer.WriteLine("2 2 4 0");
            writer.WriteLine("7 0 9 3");
            writer.WriteLine("1 9 9 9");
            writer.WriteLine("4 6 9 9");
        }
    }
}
