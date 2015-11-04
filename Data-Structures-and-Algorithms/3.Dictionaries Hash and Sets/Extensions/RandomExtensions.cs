namespace Extensions
{
    using System;
    using System.Text;

    public static class RandomExtensions
    {
        private static string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVXYZabcdefghijklmnopqrstuvwxyz1234567890";
        private static int AlphabetLen = Alphabet.Length;

        public static string NextString(this Random rng, int minLen, int maxLen)
        {
            var sb = new StringBuilder();

            var length = rng.Next(minLen, maxLen + 1);

            for (int i = 0; i < length; i++)
            {
                sb.Append(Alphabet[rng.Next(0, AlphabetLen - 1)]);
            }

            return sb.ToString();
        }
    }
}
