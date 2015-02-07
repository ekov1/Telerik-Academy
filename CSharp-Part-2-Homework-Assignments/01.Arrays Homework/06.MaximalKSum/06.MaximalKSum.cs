using System;

//Write a program that reads two integer numbers N and K and an array of N elements from the console.
//Find in the array those K elements that have maximal sum.

    class Program
    {
        static void Main()
        {
            Console.Write("Enter the N parameter: ");
            int N = int.Parse(Console.ReadLine());
            Console.WriteLine("\nYou are looking for the K(number of elements) that sum up to the max possible sum of K numbers in the array");
            Console.Write("Enter the K parameter: ");
            int K = int.Parse(Console.ReadLine());
            Console.WriteLine();
            int[] arr = new int[N];
            long maxSum = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("Please input a number for arr[i]: ");
                arr[i] = int.Parse(Console.ReadLine());
            }
            Array.Sort(arr);
            for (int i = 1; i <= K; i++)
            {
                maxSum = arr[arr.Length - i] + maxSum;
            }
            Console.WriteLine("The maximal possible sum of the number of elements (K = {0}) is {1}.", K, maxSum);


        }
    }

 