using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Write a program to convert hexadecimal numbers to binary numbers (directly).

class Program
{
    static void Main()
    {
        Console.Write("Please enter a hexadecimal number which you'd like to convert into binary: ");
        string hexInput = Console.ReadLine(); //22EB
        Console.WriteLine("\nThe binary representation of the input number is: " + String.Join("", ConvertToBin(hexInput)));
        Console.WriteLine();
    }

    public static char[] ConvertToBin(string hexInput)
    {
        Array.Reverse(hexInput.ToCharArray());

        var sb = new StringBuilder();

        for (int i = 0; i < hexInput.Length; i++)
        {
            switch (hexInput[i])
            {
                #region
                case '0': sb.Append("0000"); break;
                case '1': sb.Append("0001"); break;
                case '2': sb.Append("0010"); break;
                case '3': sb.Append("0011"); break;
                case '4': sb.Append("0100"); break;
                case '5': sb.Append("0101"); break;
                case '6': sb.Append("0110"); break;
                case '7': sb.Append("0111"); break;
                case '8': sb.Append("1000"); break;
                case '9': sb.Append("1001"); break;
                case 'A': sb.Append("1010"); break;
                case 'B': sb.Append("1011"); break;
                case 'C': sb.Append("1100"); break;
                case 'D': sb.Append("1101"); break;
                case 'E': sb.Append("1110"); break;
                case 'F': sb.Append("1111"); break;
                #endregion
            }
        }
        char[] binary = sb.ToString().ToCharArray();
        if (binary[0] == '0')
        {
            binary = RemoveExtraZeroes(binary);
        }

        return binary;

    }

    private static char[] RemoveExtraZeroes(char[] binary)
    {
        int i = 0;
        while(binary[i] == '0')
        {
            binary[i] = '\0';
            i++;
        }
        return binary;
    }
}
