using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicWords
{
    class Program
    {
        static void Main(string[] args)
        {
            
            int n = int.Parse(Console.ReadLine());

            var words = new List<string>();

            for (int i = 0; i < n; i++)
            {
                words.Add(Console.ReadLine());
            }

            for (int i = 0; i < n; i++)
            {
                string currentWord = words[i];
                words[i] = null;
                int index = currentWord.Length%(n + 1);
                words.Insert(index, currentWord);
                words.RemoveAt(words.IndexOf(null));
            }

            int max = words.Max(x => x.Length);
            var sb = new StringBuilder();

            for (int i = 0; i < max; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i < words[j].Length)
                    {
                        char currentChar = words[j][i];
                        sb.Append(currentChar);
                    }


                }
            }

            Console.WriteLine(sb);
        }
    }
}
