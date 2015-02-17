using System;
using System.Collections.Generic;
using System.Linq;

//Write methods to calculate minimum, maximum, average, sum and product of given set of integer numbers.
//Use variable number of arguments.

class Program
{
    static void Main()
    {
        Console.Write("This program solves simple tasks like finding the min/max/average/sum or product of a sequence of numbers.\n");
        int[] numbers = EnterSequence();
        while (true)
        {
            Console.Write("Enter 'max' to find the biggest value in the number sequence;\nEnter 'min' to find the lowest value in the number sequence;\nEnter 'average' to find the average in the number sequence;\nEnter 'sum' to find the sum of all numbers in the sequence;\nEnter 'product' to find the product of all numbers in the sequence.\nEnter 'quit' to exit program.\nChoice: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "max": Console.WriteLine("Max value in the number sequence is: " + FindMax(numbers)); break;
                case "min": Console.WriteLine("Min value in the number sequence is: " + FindMin(numbers)); break;
                case "average": Console.WriteLine("Average value from the number sequence is: " + FindAverage(numbers)); break;
                case "sum": Console.WriteLine("The sum of all numbers in the sequence is: " + FindSum(numbers)); break;
                case "product": Console.WriteLine("The product of all numbers in the sequence is: " + FindProduct(numbers)); break;
                case "quit": break;
                default: Console.WriteLine("Invalid input!"); break;
            }
            Console.Write("\nPress a key to continue...");
            Console.ReadLine();
            if (choice == "quit")
            {
                break;
            }
            Console.Clear();
        }
    }

    private static int FindSum(int[] numbers)
    {
        int Sum = 0;
        for (int i = 0; i < numbers.Length; i++)
        {
            Sum += numbers[i];
        }
        return Sum;
    }

    private static int FindProduct(int[] numbers)
    {
        int Product = 1;
        for (int i = 0; i < numbers.Length; i++)
        {
            Product *= numbers[i];
        }
        return Product;
    }

    private static double FindAverage(int[] numbers)
    {
        int len = numbers.Length;
        double average = (double)FindSum(numbers) / len;
        return average;
    }

    private static int FindMin(int[] numbers)
    {
        int Min = int.MaxValue;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (Min > numbers[i])
            {   
                Min = numbers[i];
            }
        }
        return Min; 
    }

    private static int FindMax(int[] numbers)
    {
        int Max = int.MinValue;
        for (int i = 0; i < numbers.Length; i++)
        {
            if (Max < numbers[i])
            {
                Max = numbers[i];
            }
        }
        return Max; 
    }

    private static int[] EnterSequence()
    {
        Console.Write("Enter number of elements that we will be reviewing: ");
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];

        if (n <= 0)
        {
            Console.WriteLine("You must input at least one integer...");
        }
        else
        {
            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter an integer {0}: ", i + 1);
                arr[i] = int.Parse(Console.ReadLine());
            }
        }
        return arr;
    }
}
