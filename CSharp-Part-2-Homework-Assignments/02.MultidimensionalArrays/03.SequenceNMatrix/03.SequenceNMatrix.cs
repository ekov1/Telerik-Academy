using System;
using System.Collections.Generic;

//We are given a matrix of strings of size N x M. Sequences in the matrix we define as sets 
//of several neighbour elements located on the same line, column or diagonal.
//Write a program that finds the longest sequence of equal strings in the matrix.


class Program
{
    static void Main()
    {

        string[,] matrix = {
                           {"ha",	"fifi", "ha",	"hi"},
                           {"fo",	"ha",	"ho",	"ha"},
                           {"ho",	"hi",	"ha", 	"xx"}}; //supposed output - 3x"ha"


        
        string currentElement = null;
        int currentCount = 1;
        int bestCount = 1;
        // string currentElement = matrix[0, 0];
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 1; col++)
            {
                currentCount = 1;

                if (matrix[row, col] == matrix[row, col + 1])
                {
                    currentCount++;
                }
                else
                {
                    currentCount = 1;
                }

                if (currentCount > bestCount)
                {
                    bestCount = currentCount;
                    currentElement = matrix[row, col];
                }
            }
            currentCount = 1;
        }
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                if (matrix[row, col] == matrix[row + 1, col])
                {
                    currentCount++;
                }
                else
                {
                    currentCount = 1;
                }

                if (currentCount > bestCount)
                {
                    bestCount = currentCount;
                    currentElement = matrix[row, col];
                }
            }

            currentCount = 1;
        }
        for (int row = 0, col = 0; row < matrix.GetLength(0) - 1 && col < matrix.GetLength(1) - 1; row++, col++)
        {
            if (matrix[row, col] == matrix[row + 1, col + 1])
            {
                currentCount++;
            }
            else
            {
                currentCount = 1;
            }

            if (currentCount > bestCount)
            {
                bestCount = currentCount;
                currentElement = matrix[row, col];
            }
        }

        Console.WriteLine("Longest sequence:\n" + new string('-', 40));
        for (int i = 0; i < bestCount; i++)
        {
            Console.Write(i < bestCount - 1 ? "{0}, " : "{0}", currentElement);
        }
        Console.WriteLine("\nBest element is '{0}' with {1} occurences!\n", currentElement, bestCount);

    }
}
