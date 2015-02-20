using System;
using System.Collections.Generic;
using System.Linq;

//Write a program that reads a year from the console and checks whether it is a leap one.
//Use System.DateTime.

class Program
{
    static void Main()
    {
        Console.Write("Enter the year that you'd like to check whether it's leap or not: ");
        int inputYear = int.Parse(Console.ReadLine());

        if (DateTime.IsLeapYear(inputYear))
        {
            Console.WriteLine("Year is leap!");
        }
        else
        {
            Console.WriteLine("Year is NOT leap!");
        }
    }
}

