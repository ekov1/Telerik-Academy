namespace BinaryTreesBalls
{
    using System;
    using System.Numerics;

    public class Startup
    {
        public static void Main()
        {
            var input = Console.ReadLine();

            var colors = new int[26];

            foreach (var color in input)
            {
                colors[color - 'A']++;
            }

            var n = input.Length;

            var factorials = new BigInteger[2 * n + 1];
            factorials[0] = 1;

            for (int i = 0; i < 2 * n; i++)
            {
                factorials[i + 1] = factorials[i] * (i + 1);
            }

            var result = factorials[2 * n] / factorials[n + 1];

            foreach (var color in colors)
            {
                result /= factorials[color];
            }

            Console.WriteLine(result);
        }
    }
}
