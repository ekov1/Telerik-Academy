using System;
using System.Collections.Generic;
using System.Numerics;

//Write a method that adds two positive integer numbers represented as arrays of digits 
//(each array element arr[i] contains a digit; the last digit is kept in arr[0]).
//Each of the numbers that will be added could have up to 10 000 digits.

class Program
{
    static void Main()
    {
        Console.Write("Please enter a positive integer: ");
        BigInteger inputNumOne = BigInteger.Parse(Console.ReadLine());
        Console.Write("Please enter a positive integer: ");
        BigInteger inputNumTwo = BigInteger.Parse(Console.ReadLine());

        DigitsToArray(inputNumOne, inputNumTwo);
    }

    private static void DigitsToArray(BigInteger inputNumOne, BigInteger inputNumTwo)
    {
        int[] numOne = InputToArray(inputNumOne);
        int[] numTwo = InputToArray(inputNumTwo);
        BigInteger sum = inputNumOne + inputNumTwo;


        Console.WriteLine(string.Join("", numOne));
        Console.WriteLine();
        Console.WriteLine(string.Join("", numTwo));
        Console.WriteLine();
        Console.WriteLine("The sum of the above is " + sum);
    }

    private static int[] InputToArray(BigInteger input)
    {
        int[] arr = new int[input.ToString().Length];
        BigInteger number = input;
        int len = number.ToString().Length;
        for (int i = 0; i < len; i++)
        {
            arr[i] = (int)number % 10;
            number /= 10;
        }
        Array.Reverse(arr);
        return arr;
    }
}

