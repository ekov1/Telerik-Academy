using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Write a program to convert binary numbers to hexadecimal numbers (directly).

class Program
{
    static void Main()
    {
        Console.Write("Please enter a binary number which you'd like to convert into hexadecimal: ");
        string binInput = Console.ReadLine(); //10001011101011 = 22EB
        Console.WriteLine("\nThe hexadecimal representation of the input number is: " + ConvertToHex(binInput));
        Console.WriteLine();
    }

    public static StringBuilder ConvertToHex(string binInput)
    {
        var sb = new StringBuilder(binInput);
        int remainder = 0;

        if (binInput.Length % 4 != 0) //pads with zeroes so that we have even sections of 4 elements each
        {
            remainder = binInput.Length % 4;

            for (int i = 0; i <  4 - remainder; i++)
            {
                sb.Insert(0, 0);
            }
        }
        Console.WriteLine(sb);

        char[] section = new char[4]; //here we store temporarily each section so that we can review its hex value
        var hex = new StringBuilder(); //this is where we store the final number in hex

        while (sb.Length >= 4) 
        {
            for (int i = 0; i < 4; i++)
            {
                section[i] = sb[0];
                sb.Remove(0, 1);
            }
            string sectionString = new string(section);
            
            switch (sectionString)
            {
                #region
                case "0000": hex.Append("0"); break;
                case "0001": hex.Append("1"); break;
                case "0010": hex.Append("2"); break;
                case "0011": hex.Append("3"); break;
                case "0100": hex.Append("4"); break;
                case "0101": hex.Append("5"); break;
                case "0110": hex.Append("6"); break;
                case "0111": hex.Append("7"); break;
                case "1000": hex.Append("8"); break;
                case "1001": hex.Append("9"); break;
                case "1010": hex.Append("A"); break;
                case "1011": hex.Append("B"); break;
                case "1100": hex.Append("C"); break;
                case "1101": hex.Append("D"); break;
                case "1110": hex.Append("E"); break;
                case "1111": hex.Append("F"); break;
                #endregion
            }
        }
        return hex;
    }
}
