using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

//Write a program for extracting all email addresses from given text.
//All sub-strings that match the format <identifier>@<host>…<domain> should be recognized as emails.

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter text: ");
        string input = Console.ReadLine(); //sample : tomissocoollike13@hotmail.com, I also have one at google mail - tom06@go.mail, my mom made me my first mail for my 8th birthday which is my-son-tom-2006@sons.tom. Write me!
        string pattern = @"[\w-]+@[a-zA-z0-9]+\.[a-zA-z]+";

        Console.WriteLine();
        foreach (var item in Regex.Matches(input, pattern))
        {
            Console.WriteLine("Valid email: " + item);
        }
        Console.WriteLine();
    }
}
