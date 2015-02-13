using System;
using System.Collections.Generic;

//Write a method that asks the user for his name and prints “Hello, <name>”
//Write a program to test this method.

class Program
{
    static void Main()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        PrintMyName(name);    
    
    }

    private static void PrintMyName(string myName)
    {
        Console.WriteLine("\nHello, " + myName);
        Console.WriteLine();
    }

}
