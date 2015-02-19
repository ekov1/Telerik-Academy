using System;
using System.Collections.Generic;
using System.Linq;

//Write a program to convert decimal numbers to their binary representation.

class Program
{
    static void Main()
    {
        Console.Write("Please enter a decimal number which you'd like to convert into binary: ");
        long decimalInput = long.Parse(Console.ReadLine());

        Console.WriteLine(ConvertToBinary(decimalInput));
    }

    private static string ConvertToBinary(long decimalInput)
    {
        string[] binary = new string[32];
        int i = 0;

        do
        {
            if (decimalInput % 2 != 0)
            {
                binary[i] = "1";
            }
            else
            {
                binary[i] = "0";
            }
            decimalInput = decimalInput / 2;

            i++;
        }
        while (decimalInput > 0);

        Array.Reverse(binary);
        string s = string.Join("", binary);

        return s;
    }
}
