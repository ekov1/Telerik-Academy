using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Write a program that converts a string to a sequence of C# Unicode character literals.
//Use format strings.
//Example:

//input	output
//Hi!	\u0048\u0069\u0021

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter text:");
            string input = Console.ReadLine();
            int currentchar = 0;

            foreach (char c in input)
            {
                currentchar = (int)c;
                Console.Write(string.Format("\\u{0:x4}", currentchar));
            }
            Console.WriteLine();
        }
    }
