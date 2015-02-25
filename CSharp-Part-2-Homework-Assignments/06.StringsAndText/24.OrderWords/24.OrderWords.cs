using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that reads a list of words separated by spaces and prints the list in an alphabetical order.

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter words separated by space: ");
        string sample = "civic deified deleveled devoved dewed Hannah kayak level madam racecar radar redder refer repaper reviver rotator rotor sagas solos sexes stats tenet";
        //string sample = Console.ReadLine();
        string[] words = sample.Split(" ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        Array.Sort(words);

        Console.WriteLine("Words in alphabetical order: ");
        for (int i = 0; i < words.Length; i++)
        {
            Console.WriteLine(words[i]);
        }
        Console.WriteLine();


    }
}
