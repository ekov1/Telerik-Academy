namespace WordsCount
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public static class Startup
    {
        private static string filePath = "../../Files/words.txt";

        public static void Main()
        {
            var fileText = File.ReadAllText(filePath);

            var words = fileText.Split(new char[] { ',', ' ', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            var wordsDictionary = new Dictionary<string, int>();

            foreach (var item in words)
            {
                var wordToLower = item.ToLower();

                if (!wordsDictionary.ContainsKey(wordToLower))
                {
                    wordsDictionary.Add(wordToLower, 0);
                }

                wordsDictionary[wordToLower]++;
            }

            wordsDictionary.OrderBy(x => x.Value)
                .ToList().ForEach(x => { Console.WriteLine(x.Key + " -> " + x.Value + " occurences."); });
        }
    }
}
