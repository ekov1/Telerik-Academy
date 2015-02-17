using System;
using System.Collections.Generic;

//Write a method that adds two polynomials.
//Represent them as arrays of their coefficients.
//Example:

//x2 + 5 = 1x2 + 0x + 5 => {5, 0, 1}

class Program
{

    static void Main()
    {
        Console.WriteLine("Input desired size of polynomials: ");
        int n = int.Parse(Console.ReadLine());

        int[] arr1 = new int[n];
        int[] arr2 = new int[n];

        Console.Write("What operation would you like to perform with polynomials? \nEnter '1' for Adding;\nEnter '2' for Substracting;\nChoice: ");
        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                {
                    for (int i = 0; i < n; i++)
                    {
                        Console.Write("Enter parameter for x^{0} on the left side of the equation: ", i);
                        arr1[i] = int.Parse(Console.ReadLine());
                        Console.Write("Enter parameter for x^{0} on the right side of the equation: ", i);
                        arr2[i] = int.Parse(Console.ReadLine());
                    }

                    int[] arrSum = SumPolynomial(arr1, arr2);

                    for (int i = 0; i < arrSum.Length; i++)
                    {
                        if (i != arrSum.Length - 1)
                        {
                            Console.Write("{0}x^{1} + ", arrSum[i], i);
                        }
                        else
                        {
                            Console.Write("{0}x^{1}", arrSum[i], i);
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                    break;
                }
            case 2:
                {
                    for (int i = 0; i < n; i++)
                    {
                        Console.Write("Enter parameter for x^{0} on the left side of the equation: ", i);
                        arr1[i] = int.Parse(Console.ReadLine());
                        Console.Write("Enter parameter for x^{0} on the right side of the equation: ", i);
                        arr2[i] = int.Parse(Console.ReadLine());
                    }

                    int[] arrSum = SubstractPolynomials(arr1, arr2);

                    for (int i = 0; i < arrSum.Length; i++)
                    {
                        if (i != arrSum.Length - 1)
                        {
                            Console.Write("{0}x^{1} + ", arrSum[i], i);
                        }
                        else
                        {
                            Console.Write("{0}x^{1}", arrSum[i], i);
                        }
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                    break;
                }
            default: Console.WriteLine("Invalid input!"); break;
            
        }
        
    }

    static int[] SumPolynomial(int[] arr1, int[] arr2)
    {
        int[] arrSum = new int[arr1.Length];

        for (int i = 0; i < arr1.Length; i++)
        {
            arrSum[i] = arr1[i] + arr2[i];
        }
        return arrSum;
    }

    static int[] SubstractPolynomials(int[] arr1, int[] arr2)
    {
        int[] arrSum = new int[arr1.Length];

        for (int i = 0; i < arr1.Length; i++)
        {
            arrSum[i] = arr1[i] - arr2[i];
        }
        return arrSum;
    }
}

