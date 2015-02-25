using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Threading;

//Write a program that reads two dates in the format: day.month.year and calculates the number of days between them.
//Example:

//Enter the first date: 27.02.2006
//Enter the second date: 3.03.2006
//Distance: 4 days

class Program
{
    static void Main()
    {

        string format = "d.M.yyyy";

        Console.Write("Enter the first date in the format day.month.year: ");
        string date1 = Console.ReadLine();
        Console.Write("Enter the second date in the format day.month.year: ");
        string date2 = Console.ReadLine();

        //DateTime time;
        //if(DateTime.TryParseExact(date1, format, null, DateTimeStyles.None, out time)) 
        //{
        //    Console.WriteLine(time);
        //}

        DateTime parsedDate1 = DateTime.ParseExact(date1, format, null);
        DateTime parsedDate2 = DateTime.ParseExact(date2, format, null);

        Console.WriteLine();
        int result = (parsedDate2 - parsedDate1).Days;
        Console.WriteLine("Days between date1 and date2: " + result);
    }
}
