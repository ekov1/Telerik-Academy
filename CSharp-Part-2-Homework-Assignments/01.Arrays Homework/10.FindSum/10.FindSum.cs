using System;
using System.Collections.Generic;

//Write a program that finds in given array of integers a sequence of given sum S (if present).

class Program
{
    static void Main()
    {
        int[] arr = { 4, 3, 1, -6, 4, 2, 5, 8 }; //supposed output with input S = 11 is 4, 2, 5; S = 6, output: 4, 3, 1, -6, 4
        Console.Write("Please enter the desired sum of a subset of the array: ");
        int S = int.Parse(Console.ReadLine());
        int currentSum = 0;
        bool subSetFound = false;

        for (int i = 0; i < arr.Length && !subSetFound; i++)
        {
            currentSum = arr[i];
            string currentSequence = arr[i] + ", ";

            for (int j = i + 1; j < arr.Length && !subSetFound; j++)
            {
                // update sum and sequence
                currentSum += arr[j];
                currentSequence += arr[j] + ", ";

                if (currentSum == S)
                {
                    Console.WriteLine("Subset of S = {0} of subsequent numbers found!", S);
                    Console.WriteLine("Subset sequence: " + currentSequence.TrimEnd(','));
                    subSetFound = true;
                }

            }

        }


        if (!subSetFound)
        {
            Console.WriteLine("No subset of S = {0} of subsequent numbers exists in the array\nLo siento, señor!\n", S);
        }


    }
}

