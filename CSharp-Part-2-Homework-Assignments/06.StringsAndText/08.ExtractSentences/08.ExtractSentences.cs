using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

//Write a program that extracts from a given text all sentences containing given word.
//Example:

//The word is: in

//The text is: We are living in a yellow submarine. We don't have anything else. Inside the submarine is very tight. So we are drinking all the day. We will move out of it in 5 days.

//The expected result is: We are living in a yellow submarine. We will move out of it in 5 days.

//Consider that the sentences are separated by . and the words – by non-letter symbols.

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter text:");
        string input = Console.ReadLine();
        string[] reworked = input.Split('.', '?', '!');

        Console.Write("Enter a word that we are looking for in the text: ");
        string word = Console.ReadLine();

        var sb = new StringBuilder();

        for (int i = 0; i < reworked.Length; i++)
        {
            if (ContainsWord(reworked, i, word))
            {
                sb.Append(reworked[i]);
                sb.Append('.');
            }
        }
        Console.WriteLine();
        Console.WriteLine(sb);
    }

    private static bool ContainsWord(string[] reworked, int index, string word)
    {
        return Regex.Matches(reworked[index], string.Format(@"\b{0}\b", word), RegexOptions.IgnoreCase).Count != 0;
    }
}
