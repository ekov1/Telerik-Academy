using System;
using System.Collections.Generic;
using System.Linq;

//You are given a sequence of positive integer values written into a string, separated by spaces.
//Write a function that reads these values from given string and calculates their sum.
//Example:

//input	output
//"43 68 9 23 318"	461

    class Program
    {
        static void Main()
        {
            Console.Write("Enter a sequence of positive integer values, separated by spaces: ");
            string input = Console.ReadLine();

            int[] intInput = input.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                                  .Select(x => int.Parse(x))
                                  .ToArray();
            int sum = 0;

            for (int i = 0; i < intInput.Length; i++)
            {
                sum += intInput[i];
            }
            Console.WriteLine("The sum of all input numbers is: {0}", sum);
        }
    }
