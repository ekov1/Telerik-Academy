using System;
using System.Collections.Generic;

//Write a program that creates an array containing all letters from the alphabet (A-Z).
//Read a word from the console and print the index of each of its letters in the array.

class Program
{
    static void Main()
    {
        char[] alphabet = new char[26];
        for (int i = 0; i < alphabet.Length; i++) //adds each letter of the alphabet to the array;
        {
            alphabet[i] = (char)(65 + i);
        }

        Console.Write("Please input words whose letters you will be reviewing: ");
        string input = Console.ReadLine();
        string INPUT = input.ToUpper();
        Console.WriteLine();

        foreach (char c in INPUT)
        {
            if (c < 'A' && c > 'Z') continue;
            for (int i = 0; i < alphabet.Length; i++)
            {
                if (c == alphabet[i])
                {
                    Console.WriteLine("Letter {0} corresponds to index {1} of the array.", c, i);
                }
            }
        }
     
    }
}
