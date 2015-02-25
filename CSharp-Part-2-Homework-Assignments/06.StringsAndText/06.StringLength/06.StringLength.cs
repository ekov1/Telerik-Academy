using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Write a program that reads from the console a string of maximum 20 characters. 
//If the length of the string is less than 20, the rest of the characters should be filled with *.
//Print the result string into the console.

class Program
{
    static void Main()
    {
        Console.Write("Enter text that contains no more than 20 characters!: ");
        string input = Console.ReadLine();
        int filler = 20 - input.Length; //returns the amount of asterisks that need to be appended

        if (input.Length > 20)
        {
            Console.WriteLine("Input is longer than the limit (20)!");
            Console.WriteLine();
        }

        else
        {
            var sb = new StringBuilder(input);
            sb.Append('*', filler);
            Console.WriteLine(sb);
            Console.WriteLine();
        }



    }
}
