using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        string sample = "These are examples of polindromes: civic, deified, deleveled,devoved, dewed, Hannah, kayak, level, madam, racecar, radar, redder, refer, repaper, reviver, rotator, rotor, sagas, solos, sexes, stats, tenet";
        string sampleCyr = "Palindromes in bulgarian: доход, довод, казак, капак, нежен, потоп, рефер, хляб, това не е палиндром, това също, товва";
        Console.WriteLine(sample);
        Console.WriteLine();
        Console.WriteLine(sampleCyr);
        string[] words = sample.Split(",. ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        string[] wordsCyr = sampleCyr.Split(",. ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        string reversed = string.Empty;

        Console.WriteLine();
        for (int i = 0; i < words.Length; i++) //English words
        {
            reversed = new string(words[i].ToCharArray().Reverse().ToArray());
            bool palindrom = words[i] == reversed;

            if (palindrom)
            {
                Console.WriteLine(words[i] + " is a palindrom!");
            }
        }


        Console.WriteLine();
        for (int i = 0; i < wordsCyr.Length; i++) //Bulgarian words
        {
            reversed = new string(wordsCyr[i].ToCharArray().Reverse().ToArray());
            bool palindrom = wordsCyr[i] == reversed;

            if (palindrom)
            {
                Console.WriteLine(wordsCyr[i] + " е палиндром!");
            }
        }
    }
}
