using System;
using System.Collections.Generic;

//Write a program that finds the most frequent number in an array.

class Program
{
    static void Main()
    {
        /*Console.Write("Enter the number of elements your array will contain: "); //<----------  Decomment these lines to enter your own array
        int N = int.Parse(Console.ReadLine());
        int[] arr = new int[N];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = int.Parse(Console.ReadLine());
        } */

        int[] arr = { 4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3 }; // Supposed output 4 (5 times)
        int currentFrequency = 0;
        int largestFrequency = 0;
        int num = 0;
        int mostPopNumber = 0;

        Array.Sort(arr);
        for (int i = 0; i < arr.Length-1; i++)
        {
            if (num == arr[i] || i == 0)
            {
                num = arr[i];
                ++currentFrequency;
            }

            if (currentFrequency > largestFrequency)
            {
                largestFrequency = currentFrequency;
                mostPopNumber = arr[i];
            }
            if (arr.Length-1 > i && arr[i + 1] != num)
            {
                num = arr[i + 1];
                currentFrequency = 0;
            }
        }

        Console.WriteLine("The most popular number in the integer array is {0}, with {1} occurences.", mostPopNumber, largestFrequency);
    }
}
