using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Write a program that finds how many times a sub-string is contained in a given text (perform case insensitive search).
//Example:

//The target sub-string is in

//The text is as follows: We are living in an yellow submarine. We don't have anything else. inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.

//The result is: 9

class Program
{
    static void Main()
    {
        Console.Write("String that will be analyzed.\nInput: ");
        string input = Console.ReadLine().ToLowerInvariant();
        Console.Write("Subset: ");
        string subset = Console.ReadLine().ToLowerInvariant();

        int count = 0;
        for (int i = 0; i < input.Length-subset.Length; i++)
        {
            if (subset == input.Substring(0+i, subset.Length))
            {
                count++;
            }
        }

        Console.WriteLine("Amount of times the substring has been found: " + count);

    }
}
