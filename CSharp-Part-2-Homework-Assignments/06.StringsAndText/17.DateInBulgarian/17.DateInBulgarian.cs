using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Globalization;

//Write a program that reads a date and time given in the format: day.month.year hour:minute:second 
//and prints the date and time after 6 hours and 30 minutes (in the same format) along with the day of week in Bulgarian.

class Program
{
    static void Main()
    {
        //Thread.CurrentThread.CurrentCulture = new CultureInfo("bg-BG");
        Console.Write("Enter a date in the format {day.month.year hour:minute:second}: ");
        string format = "d.M.yyyy H:m:s";
        string date = Console.ReadLine();

        DateTime parsedDate = DateTime.ParseExact(date, format, null);
        DateTime result = parsedDate.AddHours(6).AddMinutes(30);
        Console.WriteLine("Input date: " + parsedDate);
        Console.WriteLine("Date 6 hours and 30 minutes later: " + result + " " + result.ToString("dddd", CultureInfo.CreateSpecificCulture("bg-BG")));
    }
}
