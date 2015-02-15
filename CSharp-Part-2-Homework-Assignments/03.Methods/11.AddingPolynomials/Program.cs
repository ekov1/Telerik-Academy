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
        Console.Write("Enter the two polynomials that you will be adding:\nExample: (x2 + 5) + (3x - 2)");
        string input = Console.ReadLine();

        ParsePolynomials(input);
    }
                                                        
    private static void ParsePolynomials(string input)
    {

    }
}

