using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        Console.Write("Please enter a short(up to 32767) integer which you'd like to see as a binary: ");
        short input = short.Parse(Console.ReadLine());
        string binary = Convert.ToString(input, 2);
        Console.WriteLine("Result: " + binary);
    }
}

