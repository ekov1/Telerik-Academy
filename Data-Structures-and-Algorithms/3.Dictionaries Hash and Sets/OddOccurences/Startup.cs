namespace OddOccurences
{
    using Extensions;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public static class Startup
    {
        [STAThread]
        public static void Main()
        {
            new string[] { "C#", "SQL", "Python", "PHP", "PHP", "SQL", "SQL", "Javascript", "NodeJs", "Clojure", "NodeJs", "Python", "Python" }
            .CopyToClipboard(" ", "");

            Console.WriteLine("Test input has been copied to the clipboard. Right-click to paste!");

            var input = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var languagesDictionary = new Dictionary<string, int>();

            foreach (var item in input)
            {
                if (!languagesDictionary.ContainsKey(item))
                {
                    languagesDictionary.Add(item, 0);
                }

                languagesDictionary[item]++;
            }

            var sbResult = new StringBuilder();

            foreach (var entry in languagesDictionary)
            {
                if (entry.Value % 2 != 0)
                {
                    sbResult.AppendLine(entry.Key);
                }
            }

            Console.WriteLine(sbResult.ToString() + " occured odd number of times...");
        }
    }
}
