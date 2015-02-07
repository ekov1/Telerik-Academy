using System;
using System.Collections.Generic;

//Write a program that finds the sequence of maximal sum in given array.
//                            Example:

//           input	                    result
//2, 3, -6, -1, 2, -1, 6, 4, -8, 8	  2, -1, 6, 4 = 11
//Can you do it with only one loop (with single scan through the elements of the array)?

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

        int[] arr = { 2, 3, -6, -1, 2, -1, 6, 4, -8, 8 };
        int currentSum = 0;
        int maxSum = 0;


        for (int i = 0; i < arr.Length; i++)
        {
            currentSum = arr[i] + currentSum;
            
            if (currentSum > maxSum)
            {
                maxSum = currentSum;
            }
            if (currentSum < 0)
            {
                currentSum = 0;
            }
        }
        Console.WriteLine();
        Console.WriteLine("The maximal sum of a subarray is: {0}", maxSum);
        Console.WriteLine();
        

    }
}


