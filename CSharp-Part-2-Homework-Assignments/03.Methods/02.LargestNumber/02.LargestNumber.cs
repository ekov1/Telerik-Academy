using System;
using System.Collections.Generic;

//Write a method GetMax() with two parameters that returns the larger of two integers.
//Write a program that reads 3 integers from the console and prints the largest of them using the method GetMax().

class Program
{
    static void Main()
    {
        Console.Write("Please enter 3 integers, each one on a new line: ");
        int num1 = int.Parse(Console.ReadLine());
        int num2 = int.Parse(Console.ReadLine());
        int num3 = int.Parse(Console.ReadLine());


        Console.Write(GetMax(GetMax(num1, num2), GetMax(num2, num3)));
    }

    private static int GetMax(int num1, int num2)
    {
        return Math.Max(num1, num2);
    }
}