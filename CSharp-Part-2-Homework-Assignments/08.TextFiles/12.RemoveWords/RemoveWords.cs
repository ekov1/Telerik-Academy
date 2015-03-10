
    //Write a program that removes from a text file all words listed in given another text file.
    //Handle all possible exceptions in your methods.

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
class RemoveWords
{
    public static readonly string[] punctuation = new string[] { ".", ",", "!", "-", ":", "?", ")", "(" };
    static void Main()
    {
        GenerateWords();
        GenerateTest();
        List<string> censorWords = new List<string>();
        using (StreamReader reader = new StreamReader("words.txt"))
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                censorWords.Add(" " + line + " ");
                line = reader.ReadLine();
            }
        }
        string text;
        using (StreamReader reader = new StreamReader("test.txt"))
        {
            text = reader.ReadToEnd();
        }
        foreach (var symbol in punctuation)
        {
            text = text.Replace(symbol, (" " + symbol + " "));
        }
        using (StreamWriter writer = new StreamWriter("test.txt"))
        {
            foreach (string word in censorWords)
            {
                while (text.Contains(word))
                {
                    text = text.Replace(word, "");
                }
                while (text.Contains(word.TrimStart()))
                {
                    text = text.Replace((word.TrimStart()), "");
                }
            }
            writer.Write(text);
        }


        Console.WriteLine(text);
    }

    private static void GenerateWords()
    {
        using (StreamWriter writer = new StreamWriter("words.txt"))
        {
            writer.WriteLine("stuff");
            writer.WriteLine("a");
        }
    }

    private static void GenerateTest()
    {
        using (StreamWriter writer = new StreamWriter("test.txt"))
        {
            writer.WriteLine("stuff withtest, but not as a prefix");
            writer.WriteLine("stuff with testas a prefix");
            writer.WriteLine("stuff with test as a single word");
            writer.WriteLine("teststuff with test at the start");
            writer.WriteLine("test with stuff andstuff a testand stuff, just to (test all the stuff)");
        }
    }
}