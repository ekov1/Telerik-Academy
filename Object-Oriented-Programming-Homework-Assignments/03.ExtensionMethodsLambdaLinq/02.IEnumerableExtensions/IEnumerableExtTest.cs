using System;

namespace _02.IEnumerableExtensions
{
    class IEnumerableExtTest
    {
        static void Main()
        {
            int[] intList = {2, 5, 7, 12, 7, 19, 123, 63, 35, 22};

            Console.WriteLine(intList.Average());
            Console.WriteLine(intList.Sum());
            Console.WriteLine(intList.MaxValue());
            Console.WriteLine(intList.MinValue());
            Console.WriteLine(intList.Product());


        }
    }
}
