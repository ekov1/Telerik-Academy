using System;
using System.Collections.Generic;
using System.Linq;

//Write a program to convert hexadecimal numbers to their decimal representation.

class Program
{
    static void Main()
    {
        Console.Write("Please enter a hexadecimal number which you'd like to convert into decimal: ");
        string hexInput = Console.ReadLine();
        // string hexInput = "1AE3"; //DECOMMENT LINE TO RUN THE PROGRAM WITH THE VALUE 1AE3, OUTPUT: 6883
        char[] array = hexInput.ToCharArray();
        Array.Reverse(array); //reverses the order of the array so that we start reading them backwards, 
        //as in the classical manual method of converting hex to decimal
        int power = 0;
        long decResult = 0;

        for (int i = 0; i < array.Length; i++)
        {
            switch (array[i])
            {
                case 'a':
                case 'A': decResult = (long)(10 * Math.Pow(16, power)) + decResult; break;
                case 'b':
                case 'B': decResult = (long)(11 * Math.Pow(16, power)) + decResult; break;
                case 'c':
                case 'C': decResult = (long)(12 * Math.Pow(16, power)) + decResult; break;
                case 'd':
                case 'D': decResult = (long)(13 * Math.Pow(16, power)) + decResult; break;
                case 'e':
                case 'E': decResult = (long)(14 * Math.Pow(16, power)) + decResult; break;
                case 'f':
                case 'F': decResult = (long)(15 * Math.Pow(16, power)) + decResult; break;
                default: int temporary = (int)Char.GetNumericValue(array[i]); decResult = (long)(temporary * Math.Pow(16, power)) + decResult; break;
            }
            power++;
        }
        Console.WriteLine("Decimal representation of the input hex number ({0}) is: {1}.\n", hexInput, decResult);

    }
}

