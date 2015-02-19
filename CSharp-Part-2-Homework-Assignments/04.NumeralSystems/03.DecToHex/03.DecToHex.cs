using System;
using System.Collections.Generic;
using System.Linq;

//Write a program to convert decimal numbers to their hexadecimal representation.

class Program
{
    static void Main()
    {
        Console.Write("Please enter a decimal number which you'd like to convert into hexadecimal: ");
        long decInput = long.Parse(Console.ReadLine());
        // long decInput = 6883; //DECOMMENT LINE TO RUN THE PROGRAM WITH THE VALUE 6883, OUTPUT: 1AE3
        long remainder = 0;
        int i = 0;
        string[] hexRemainder = new string[32];

        do
        {
            remainder = decInput % 16;
            switch (remainder)
            {
                case 10: hexRemainder[i] = "A"; break;
                case 11: hexRemainder[i] = "B"; break;
                case 12: hexRemainder[i] = "C"; break;
                case 13: hexRemainder[i] = "D"; break;
                case 14: hexRemainder[i] = "E"; break;
                case 15: hexRemainder[i] = "F"; break;
                default: string temporary = remainder.ToString(); hexRemainder[i] = temporary; break;
            }
            decInput = decInput / 16;
            i++;
        }
        while (decInput > 0);

        Array.Reverse(hexRemainder);
        string s = string.Join("", hexRemainder);
        Console.WriteLine("\nHexadecimal representation of the input decimal number is: {0}.\n", s);
    }
}

