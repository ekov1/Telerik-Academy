using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Write a program that reads a number and prints it as a decimal number, hexadecimal number, percentage and in scientific notation.
//Format the output aligned right in 15 symbols.

class Program
{
    static void Main()
    {
        Console.Write("Enter a number:");
        double input = double.Parse(Console.ReadLine());
        Console.WriteLine("decimal:" + string.Format("{0}", input).PadLeft(15));
        Console.WriteLine("hex:" + string.Format("{0:x}", (int)input).PadLeft(15));
        Console.WriteLine("percentage:" + string.Format("{0:P}", input).PadLeft(15));
        Console.WriteLine("scientifical:" + string.Format("{0:e}", input).PadLeft(15));
    }
}
