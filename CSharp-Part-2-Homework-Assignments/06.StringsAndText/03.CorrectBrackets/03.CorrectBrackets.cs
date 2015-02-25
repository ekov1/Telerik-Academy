using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Write a program to check if in a given expression the brackets are put correctly.
//Example of correct expression: ((a+b)/5-d). Example of incorrect expression: )(a+b)).

class Program
{
    static void Main()
    {
        Console.Write("Enter the expression for which you wish to check the correct placing of brackets...\nInput: ");
        string input = Console.ReadLine();
        int count = 0;

        foreach (var c in input)
        {
            if (c == ')')
            {
                count--;
            }
            if (c == '(')
            {
                count++;
            }
        }

        if (count != 0)
        {
            Console.WriteLine("Incorrect use of brackets!");
        }
        else
        {
            if (input.IndexOf('(') < input.IndexOf(')'))
            {
                Console.WriteLine("Correct use of brackets!");
            }
            else
            {
                Console.WriteLine("Incorrect use of brackets!");
            }
        }

    }
}
