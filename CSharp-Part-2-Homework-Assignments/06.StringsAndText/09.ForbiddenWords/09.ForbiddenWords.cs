using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//We are given a string containing a list of forbidden words and a text containing some of these words.
//Write a program that replaces the forbidden words with asterisks.
//Example text:  Microsoft announced its next generation PHP compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in CLR.

//Forbidden words: PHP, CLR, Microsoft

//The expected result: ********* announced its next generation *** compiler today. It is based on .NET Framework 4.0 and is implemented as a dynamic language in ***.

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter text:");
        string input = Console.ReadLine();
        Console.WriteLine("Enter 3 words that need to be 'censored', separated by comma");
        string words = Console.ReadLine();
        string[] forbiddenWords = words.Split(",. ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries); //{ "PHP", "CLR", "Microsoft" };
        string output = string.Empty;


        //for (int i = 0; i < forbiddenWords.Length; i++)
        //{
        output = input.Replace(forbiddenWords[0], new string('*', forbiddenWords[0].Length)).
            Replace(forbiddenWords[1], new string('*', forbiddenWords[1].Length)).
            Replace(forbiddenWords[2], new string('*', forbiddenWords[2].Length));
        //}

        Console.WriteLine(output);

    }
}
