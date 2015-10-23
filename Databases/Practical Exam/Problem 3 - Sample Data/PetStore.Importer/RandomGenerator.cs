namespace PetStore.Importer
{
    using System;
    using System.Text;

    public class RandomGenerator
    {
        private const string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890abcdefghijklmnopqrstuvwxyz";

        private static readonly int len = Alphabet.Length;

        private static Random rng = new Random();

        public static string GetString(int minLen, int maxLen)
        {
            var sb = new StringBuilder();

            for (int j = 0; j < rng.Next(minLen, maxLen + 1); j++)
            {
                sb.Append(Alphabet[rng.Next() % len]);
            }

            return sb.ToString();
        }

        public static DateTime GetDate(DateTime from, DateTime to)
        {
            var range = to - from;

            var randTimeSpan = new TimeSpan((long)(rng.NextDouble() * range.Ticks));

            return from + randTimeSpan;
        }

        public static decimal GetDecimal(int min = 0, int max = 1)
        {
            return (decimal)rng.Next(min, max);
        }

        public static int GetNumber(int min = Int32.MinValue, int max = Int32.MaxValue-1)
        {
            return rng.Next(min, max + 1);
        }
    }
}
