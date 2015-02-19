using System;
using System.Collections.Generic;
using System.Linq;

//Write a program to convert binary numbers to their decimal representation.

class Program
{
    static void Main()
    {
        Console.Write("Please input a number as binary to see its decimal value: ");
        string binaryInput = Console.ReadLine();
        // string binaryInput = "1010101010101011"; //DECOMMENT THIS LINE TO CHECK WITHOUT HAVING TO INPUT ANYTHING
        char[] arr = binaryInput.ToCharArray();
        long result = 0;

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == '\u0030') //alternative to this is (char)48 - checks whether the array element holds a 0 or not
            {
                result = (result * 2) + 0;
            }
            else // if it holds \u0031 - which is a one, do:
            {
                result = (result * 2) + 1;
            }
        }
        Console.WriteLine(result);
    }
}
