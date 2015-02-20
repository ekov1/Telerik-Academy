using System;
using System.Collections.Generic;
using System.Linq;

//Write a program that prints to the console which day of the week is today.
//Use System.DateTime.

class Program
{
    static void Main()
    {
        string dayOfTheWeek = System.DateTime.Now.DayOfWeek.ToString();
        Console.WriteLine(dayOfTheWeek);
    }
}
