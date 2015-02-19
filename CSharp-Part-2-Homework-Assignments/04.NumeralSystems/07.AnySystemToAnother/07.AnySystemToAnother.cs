using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Program
{
    static void Main()
    {
        Console.Write("Please enter the numeral system from which you will be converting a number (must be between 2 and 10): ");
        int system1 = int.Parse(Console.ReadLine());
        Console.Write("Please enter the numeral system from which you will be converting a number (must be between 2 and 16): ");
        int system2 = int.Parse(Console.ReadLine());

        Console.Write("Please enter the number that you wish to convert: ");
        string numeral = Console.ReadLine();

        Console.WriteLine("Result: " + ToSystem2(ToDecimal(numeral, system1), system2));
    }

    private static long ToDecimal(string numeral, int system1)
    {
        long result = 0;
        char[] arr = numeral.ToCharArray();
        Array.Reverse(arr);
        for (int i = 0; i < arr.Length; i++)
        {
            result += (arr[i] - '0') * (long)Math.Pow(system1, i);
        }
        return result;
    }

    private static string ToSystem2(long decimalResult, int system2)
    {
        string result = String.Empty;
        int digit = 0;
        char[] letters = { 'A', 'B', 'C', 'D', 'E', 'F' };
        while (decimalResult > 0)
        {
            digit = (int)decimalResult % system2;
            if (digit >= 10)
            {
                result = letters[digit - 10] + result;
            }
            else
            {
                result = digit + result;
            }
            decimalResult /= system2;
        }

        return result;
    }
}

