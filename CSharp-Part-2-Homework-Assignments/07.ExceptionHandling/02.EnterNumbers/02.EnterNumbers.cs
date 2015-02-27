using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a method ReadNumber(int start, int end) that enters an integer number in a given range [start…end].
//If an invalid number or non-number text is entered, the method should throw an exception.
//Using this method write a program that enters 10 numbers: a1, a2, … a10, such that 1 < a1 < … < a10 < 100

class Program
{
    static void Main()
    {
        Console.WriteLine("Enter 10 numbers in the range [0;100] on separate lines, where Nk > Nk-1:");
        int start = 0;

        for (int i = 0; i < 10; i++)
        {
            try
            {
                start = ReadNumber(start, 100);
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
        }

    }

    static int ReadNumber(int start, int end)
    {
        int number = int.Parse(Console.ReadLine());
        if (number <= start || number >= end)
        {
            throw new ArgumentOutOfRangeException();
        }
        return number;
    }
}
