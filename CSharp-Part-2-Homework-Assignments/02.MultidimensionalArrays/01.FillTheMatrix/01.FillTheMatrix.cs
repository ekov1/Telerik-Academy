using System;
using System.Collections.Generic;

//Write a program that fills and prints a matrix of size (n, n) as shown below:
/*
1	5	9	13
2	6	10	14
3	7	11	15
4	8	12	16

1	8	9	16
2	7	10	15
3	6	11	14
4	5	12	13

7	11	14	16
4	8	12	15
2	5	9	13
1	3	6	10

1	12	11	10
2	13	16	9
3	14	15	8
4	5	6	7
*/

class Program
{
    static void Main()
    {
        Console.Write("Please input the size of the multidimensional array: ");
        int n = int.Parse(Console.ReadLine());
        int[,] arr = new int[n, n];

        //Matrix A
        int k = 1;
        for (int col = 0; col < n; col++)
        {
            for (int row = 0; row < n; row++, k++)
            {
                arr[row, col] = k;
            }
        }
        for (int col = 0; col < n; col++)
        {
            for (int row = 0; row < n; row++)
            {
                Console.Write("{0}  ", arr[col, row]);
            }
            Console.WriteLine();
        }
        Console.WriteLine("\n\n");
        Array.Clear(arr, 0, 2 * n);
        k = 1;

        // Matrix B
        for (int col = 0; col < n; col++)
        {
            if (col % 2 == 0)
            {
                for (int row = 0; row < n; row++, k++)
                {
                    arr[col, row] = k;
                }
            }
            else
            {
                for (int row = n - 1; row >= 0; row--, k++)
                {
                    arr[col, row] = k;
                }
            }
        }
        for (int col = 0; col < arr.GetLength(0); col++)
        {
            for (int row = 0; row < arr.GetLength(1); row++)
            {
                Console.Write("{0}  ", arr[row, col]);
            }
            Console.WriteLine();
        }
        Console.WriteLine("\n\n");
        Array.Clear(arr, 0, 2 * n);
        k = 1;

        for (int row = n - 1; row >= 0; row--)
        {
            int currentRow = row;
            for (int col = 0; col < n-row; col++)
            {
                arr[currentRow++, col] = k++;
            }
        }
        k = n * n;

        for (int row = 0; row < n - 1; row++)
        {
            int currentRow = row;
            for (int col = n - 1; currentRow >= 0; col--)
            {
                arr[currentRow--, col] = k--;
            }
        }
        for (int col = 0; col < arr.GetLength(0); col++)
        {
            for (int row = 0; row < arr.GetLength(1); row++)
            {
                Console.Write("{0}  ", arr[row, col]);
            }
            Console.WriteLine();
        }
        Console.WriteLine("\n\n");
        Array.Clear(arr, 0, 2 * n);
        k = 1;



    }
}

