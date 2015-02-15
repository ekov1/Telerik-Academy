using System;
using System.Collections.Generic;
using System.Numerics;

//Write a program to calculate n! for each n in the range [1..100].
//Hint: Implement first a method that multiplies a number represented as array of digits by given integer number.

class Program
{
    static void Main()
    {
        Console.Write("Enter an integer whose factorial you'd like to see: ");
        int input = int.Parse(Console.ReadLine());
        Console.WriteLine();
        Console.WriteLine("Factorial of {0} is {1}.\n", input, NFactorial(input));
    }

    private static BigInteger NFactorial(int input)
    {
        BigInteger Factorial = 1;

        for (int i = 1; i <= input; i++)
        {
            Factorial *= i;    
        }

        return Factorial;
    }
}
