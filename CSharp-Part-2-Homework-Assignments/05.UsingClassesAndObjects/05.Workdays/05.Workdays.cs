using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Globalization;

//Write a method that calculates the number of workdays between today and given date, passed as parameter.
//Consider that workdays are all days from Monday to Friday except a fixed list of public holidays specified preliminary as array.

class Program
{
    static void Main()
    {
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        DateTime[] officialHolidays = { 
                                new DateTime(2015, 01, 01), new DateTime(2015, 03, 03), new DateTime(2015, 05, 06), new DateTime(2015, 05, 24),
                                new DateTime(2015, 09, 06), new DateTime(2015, 09, 22), new DateTime(2015, 11, 01), new DateTime(2015, 12, 24), 
                                new DateTime(2015, 12, 25), new DateTime(2015, 12, 26)};
        DateTime now = DateTime.Now;

        Console.Write("Enter the date up to which you wish to check for the amount of work days(excluding official holidays) MM/DD/YYYY: ");
        string input = Console.ReadLine();
        DateTime endDate = DateTime.Parse(input);
        Console.WriteLine(WorkDays(officialHolidays, now, endDate) + " work days from today to " + endDate);
        Console.WriteLine();
    }

    private static int WorkDays(DateTime[] officialHolidays, DateTime now, DateTime endDate)
    {
        var currentDay = now;
        var numOfDays = endDate - now;
        int intNumOfDays = numOfDays.Days;
        int result = 0;

        for (int i = 0; i < intNumOfDays; i++)
        {
            int holCounter = 0;
            if (currentDay != officialHolidays[holCounter] && currentDay.DayOfWeek.ToString() != "Saturday" && currentDay.DayOfWeek.ToString() != "Sunday")
            {
                result++;
            }
            if (currentDay == officialHolidays[holCounter])
            {
                holCounter++;
            }
                
            currentDay = currentDay.AddDays(1);
        }
        
        return result;
    }
}