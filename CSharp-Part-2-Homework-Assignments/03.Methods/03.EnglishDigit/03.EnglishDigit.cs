using System;
using System.Collections.Generic;

//Write a method that returns the last digit of given integer as an English word

class Program
{
    static void Main()
    {
        Console.Write("Please enter an integer: ");
        int input = int.Parse(Console.ReadLine());
        Console.WriteLine("Last digit of the input number read as a word is: " + LastDigit(input));
    }

    private static string LastDigit(int input)
    {
        string numberAsWord = null;
        switch(input%10)
        {
            case 1: numberAsWord = "one"; break;
            case 2: numberAsWord = "two"; break;
            case 3: numberAsWord = "three"; break;
            case 4: numberAsWord = "four"; break;
            case 5: numberAsWord = "five"; break;
            case 6: numberAsWord = "six"; break;
            case 7: numberAsWord = "seven"; break;
            case 8: numberAsWord = "eight"; break;
            case 9: numberAsWord = "nine"; break;
        }
        return numberAsWord;
    }
}

