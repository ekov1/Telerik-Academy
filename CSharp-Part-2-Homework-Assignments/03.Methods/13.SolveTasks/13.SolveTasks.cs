using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.Write("This program solves simple tasks like evaluating a linear equation, reversing numbers, finding the average in a sequence of integers.\nEnter '1' to reverse the digits of a number;\nEnter '2' to evaluate a linear equation a*x + b = 0;\nEnter '3' to find the average in a sequence of integers;\nEnter '4' to exit program.\nChoice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": ReverseANumber(); break;
                case "2": LinearEquation(); break;
                case "3": FindAverage(); break;
                case "4": break;
                default: Console.WriteLine("Invalid input!"); break;
            }
            Console.Write("\nPress a key to continue...");
            Console.ReadLine();
            if (choice == "4")
            {
                break;
            }
            Console.Clear();
        }
    }

    private static void FindAverage()
    {
        Console.WriteLine("Enter number of elements that we will be finding the average of: ");
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
            int sum = arr.Sum();
            double average = (double)sum / n;
            Console.WriteLine("The average of all input numbers is: " + average);   
        }
    }

    private static void LinearEquation()
    {
        Console.Write("Please enter the a coefficient a of the linear equation: ");
        double a = double.Parse(Console.ReadLine());
        if (a == 0)
        {
            Console.WriteLine("'a' cannot be a zero (0)!");
        }
        Console.Write("Please enter the b coefficient a of the linear equation: ");
        double b = double.Parse(Console.ReadLine());
        double x = -b / a;
        Console.WriteLine("x = " + x);
    }

    private static void ReverseANumber()
    {


        Console.Write("Please input the number that you wish to see reversed: ");
        string input = Console.ReadLine();
        if (input[0] != '-' && input[0] != ' ' && input != null)
        {
            char[] inputAsString = input.ToCharArray();
            Array.Reverse(inputAsString);
            int i = 0;
            while (inputAsString[i] == '0')
            {
                inputAsString[i] = '\0';
                i++;
            }
            string reversedInput = string.Join("", inputAsString);
            Console.WriteLine("\nReversed your initial number " + input + " looks like this: " + reversedInput + "\n");
        }
        else Console.WriteLine("Invalid input, number must not be a negative!");
    }


}
