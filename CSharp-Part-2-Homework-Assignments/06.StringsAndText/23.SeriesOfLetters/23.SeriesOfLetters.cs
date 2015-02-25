using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that reads a string from the console and replaces all series of consecutive identical letters with a single one.

//Example:

//input	output
//aaaaabbbbbcdddeeeedssaa	abcdedsa

class Program
{
    static void Main()
    {
        Console.Write("Enter text: ");
        string input = Console.ReadLine();
        var sb = new StringBuilder();

        for (int i = 1; i < input.Length; i++)
        {
            if (input[i] != input[i - 1])
            {
                sb.Append(input[i-1]);
            }

            if (i == input.Length-1) //takes care of the last sequence of chars
            {
                sb.Append(input[i]);
            }
        }

        Console.WriteLine("Result without the excess letters: " + sb);
        Console.WriteLine();
    }
}
