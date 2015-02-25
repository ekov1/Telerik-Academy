using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Globalization;

//Write a program that extracts from a given text all dates that match the format DD.MM.YYYY.
//Display them in the standard date format for Canada.

class Program
{
    static void Main()
    {
        string format = "dd.MM.yyyy";

        string sample = "This is a date 23.12.2012, and so is this 3.4.2015, but this one appears to be one too - 31.10.2015. LOOoOoOk! Another date appears 04.05.2013. This date will not parse: 6.9.2016, but this will: 06.09.2016";
        Console.WriteLine(sample);
        Console.WriteLine();
        string pattern = @"[0-9]{2}" + @"\.[01]{1}[0-9]{1}" + @"\.[0-9]{4}";

        Console.WriteLine("Parsed dates:");

        foreach (Match item in Regex.Matches(sample, pattern))
        {
            DateTime date = (DateTime)ParseDate(item, format);
            Console.WriteLine(date.ToString("dd/MM/yyyy ddddd", CultureInfo.CreateSpecificCulture("en-CA")));
        }
    }


    private static object ParseDate(Match item, string format)
    {
        try
        {
            DateTime parsedDate = DateTime.ParseExact(item.ToString(), format, null);
            return parsedDate;
        }
        catch (Exception)
        {

            return "Cannot parse";
        }

    }


}
