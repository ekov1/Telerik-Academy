using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that reverses the words in given sentence.
//Example:

//input	output
//C# is not C++, not PHP and not Delphi!
//Delphi not and PHP, not C++ not is C#!

class Program
{
    static void Main()
    {
        Console.Write("Enter text that you wish to see in reverse order: ");
        string input = Console.ReadLine();
        string sign = input[input.Length - 1].ToString();
        string[] reworked = input.Split(".,!? ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        Array.Reverse(reworked);
        Console.WriteLine(string.Join(" ", reworked)+sign);
    }
}
