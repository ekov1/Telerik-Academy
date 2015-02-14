using System;
using System.Collections.Generic;

//Write a method that reverses the digits of given decimal number.

class Program
{
    static void Main()
    {
        Console.Write("Please input the number that you wish to see reversed: ");
        string input = (Console.ReadLine());

        Console.WriteLine("\nReversed your initial number " + input +" looks like this: " +  ReverseANumber(input));
        Console.WriteLine();
    }

    private static string ReverseANumber(string input)
    {
        char[] inputAsString = input.ToCharArray();
        Array.Reverse(inputAsString);
        string reversedInput = string.Join("", inputAsString);

        return reversedInput;
    }
}
