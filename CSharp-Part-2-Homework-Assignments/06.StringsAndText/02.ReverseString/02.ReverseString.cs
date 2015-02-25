using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Write a program that reads a string, reverses it and prints the result at the console.
//Example:

//input	output
//sample	elpmas

class Program
{
    static void Main()
    {
        Console.Write("Enter the text that you wish to see reversed: ");
        string input = Console.ReadLine();
        char[] reversedInput = input.ToCharArray();

        Array.Reverse(reversedInput);

        Console.WriteLine("Reversed: " + string.Join("", reversedInput));

    }
}
