using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that reads a string from the console and lists all different words in the string along with information how many times each word is found.

class Program
{
    static void Main()
    {
        Console.BufferHeight = 300;

        string sample = "People are stupid. They will believe a lie because they want to believe it's true, or because they are afraid it might be true." +
            "Sometimes, making the wrong choice is better than making no choice. You have the courage to go forward, that is rare. A person who stands at the fork, unable to pick, will never get anywhere." +
            "Everything is valuable under the right conditions. To a man dying of thirst, water be more precious than gold. To a drowning man, water be of little worth and great trouble.\n\n";

        Console.WriteLine(sample);
        string[] words = sample.ToLower().Split(",.!?\r\n\r\n ".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
        var uqWords = new List<string>();

        for (int i = 0; i < words.Length; i++) //finds all unique words
        {
            if (!uqWords.Contains(words[i]))
            {
                uqWords.Add(words[i]);
            }

        }
        int[] count = new int[uqWords.Count];


        for (int i = 0; i < words.Length; i++) //goes through all words and counts occurences
        {
            for (int j = 0; j < uqWords.Count; j++)
            {
                if (uqWords[j] == words[i])
                {
                    count[j]++;
                }
            }
        }

        for (int i = 0; i < uqWords.Count; i++) //print results
        {
            Console.WriteLine("{0} - {1} occurence(s)", uqWords[i], count[i]);
        }
    }
}
