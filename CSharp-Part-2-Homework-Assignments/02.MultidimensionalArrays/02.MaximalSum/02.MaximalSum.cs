using System;
using System.Collections.Generic;

//Write a program that reads a rectangular matrix of size N x M and finds in it the square 3 x 3 that has maximal sum of its elements.

class Program
{
    static void Main()
        {
            int[,] arr = {
                {1, -2, 4, 1, -3, 5, 6, -3},
                {4, 1, 2, -6, 7, 2, -5, 1},
                {3, 1, -4, 3, 6, 1, 2, -2}, 
                {-3, 4, -2, 1, 1, 0, 2, 1},
                {-4, 5, 2, 1, 3, -2, 1, 3},
                {5, 2, 1, 3, -4, 5, 1, 3},
                {2, -3, 4, 2, 1, 2, -1, 5}};

            int bestSum = int.MinValue;
            for (int row = 0; row < arr.GetLength(0) - 2; row++)
                for (int col = 0; col < arr.GetLength(1) - 2; col++)
                {
                    int sum = arr[row, col] + arr[row, col + 1] + arr[row + 1, col] + arr[row + 1, col + 1] + arr[row + 2, col] + arr[row + 2, col+1] + arr[row + 2, col + 2] + arr[row, col+2] + arr[row+1, col+2];
                    if (sum > bestSum)
                        bestSum = sum;
                }
    
            Console.WriteLine(bestSum);
        }
}
