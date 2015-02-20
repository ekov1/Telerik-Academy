using System;
using System.Collections.Generic;
using System.Linq;

//Write a program that generates and prints to the console 10 random values in the range [100, 200].

class Program
{
    static void Main()
    {
        var RNG = new Random();
        for (int i = 1; i <= 10; i++)
        {
            Console.WriteLine(i + ":\t" + RNG.Next(100, 201));
        }
    }
}
