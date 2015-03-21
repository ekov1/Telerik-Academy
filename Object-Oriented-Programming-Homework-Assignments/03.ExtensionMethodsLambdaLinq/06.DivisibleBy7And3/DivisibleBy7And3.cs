using System;
using System.Linq;

namespace _06.DivisibleBy7And3
{
    class DivisibleBy7And3
    {
        static void Main(string[] args)
        {
            int[] arr = {2, 15, 3, 7, 33, 63, 34, 436, 93, 189, 1323, 7, 2, 3, 73, 75, 45, 21};

            Console.WriteLine("All numbers in the array");
            foreach (var x in arr)
            {
                Console.Write(x + " ");
            }

            var resultLambda = arr.Where(x => x%3 == 0 && x % 7 == 0);

            var resultLINQ = from x in arr
                where x%3 == 0
                where x%7 == 0
                select x;

            Console.WriteLine("\nNumbers divisible by 3 and 7, using LINQ");
            foreach (var x in resultLINQ)
            {
                Console.Write(x + " ");
            }

            Console.WriteLine("\nNumbers divisible by 3 and 7, using Lambda");
            foreach (var x in resultLambda)
            {
                Console.Write(x + " ");
            }

            Console.WriteLine();
        }
    }
}
