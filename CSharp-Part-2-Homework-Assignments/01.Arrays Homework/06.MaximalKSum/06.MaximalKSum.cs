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

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write("Please input a number for arr[i]: ");
                arr[i] = int.Parse(Console.ReadLine());
            }
            Array.Sort(arr);
            long maxSum = arr[arr.Length - 1] + arr[arr.Length - 2];
            Console.WriteLine("The maximal possible sum of the number of elements (K = {0}) is {1}.", K, maxSum);


        }
    }

