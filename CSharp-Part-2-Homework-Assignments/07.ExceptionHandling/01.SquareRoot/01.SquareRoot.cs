using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that reads an integer number and calculates and prints its square root.
//If the number is invalid or negative, print Invalid number.
//In all cases finally print Good bye.
//Use try-catch-finally block.

class Program
{
    static void Main()
    {
        Console.Write("Enter a number that you wish to see the square root of: ");
        int input = int.Parse(Console.ReadLine());

        try
        {
            double root = (double)Math.Sqrt(input);
            Console.WriteLine("The square root is: {0:F3}", root);
        }
        catch (FormatException)
        {
            Console.WriteLine("Invalid number!");
        }
        finally
        {
            Console.WriteLine("Good bye!");
        }
    }
}
