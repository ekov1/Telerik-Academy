
    //Write a program that reads a list of words from the file words.txt and finds how many times each of the words is contained in another file test.txt.
    //The result should be written in the file result.txt and the words should be sorted by the number of their occurrences in descending order.
    //Handle all possible exceptions in your methods.

using System;
using System.Collections.Generic;
using System.IO;
class CountWords
{
    static void Main()
    {
        string text = string.Empty;
        try
        {
            GenerateTest();
            
            using (StreamReader reader = new StreamReader("test.txt"))
            {
                text = reader.ReadToEnd();
            }
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Path must not be empty.");
        }
        catch (ArgumentException)
        {
            Console.WriteLine(@"Invalid path. It must not be empty and must not contain invalid characterss. (ASCII chars 1-31; quote (""), less than (<), greater than (>), pipe (|), backspace (\b), null (\0) and tab (\t))");
        }

        catch (PathTooLongException)
        {
            Console.WriteLine("The path must be less than 248 characters and the file name must be below 260 characters for Windows based platforms.");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("The specified directory does not exist.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("The specified file could not be found.");
        }
        catch (IOException)
        {
            Console.WriteLine("An Input/Output error has occured while trying to open the file. ");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("The specified path is either not a file or you do not have access to it.");
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("The path is in unknown or invalid format.");
        }
        string[] tokens = SplitToTokens(text);
        CountTheWords(tokens);

    }
    public static readonly string[] punctuation = new string[] { ".", ",", "!", "-", ":", "?", ")", "(" };

    private static void CountTheWords(string[] tokens)
    {
        Dictionary<string, int> words = new Dictionary<string, int>();
        foreach (string word in tokens)
        {
            if (!words.ContainsKey(word))
            {
                words.Add(word, 1);
            }
            else
            {
                words[word] += 1;
            }
        }
        if (words.Count > 0)
        {
            foreach (var word in words)
            {
                Console.WriteLine("[{0}] {1}", word.Key, word.Value);
            }
        }
        else
        {
            Console.WriteLine("You didn't enter words :)!");
        }
    }
    private static string[] SplitToTokens(string sentence)
    {
        foreach (var symbol in punctuation)
        {
            sentence = sentence.Replace(symbol, (" "));
        }
        string[] splitSentence = sentence.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        return splitSentence;
    }
    private static void GenerateTest()
    {
        using (StreamWriter writer = new StreamWriter("test.txt"))
        {
            writer.Write("Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris maximus, sem sit amet volutpat pellentesque, nunc quam convallis diam, id dignissim orci est vel lacus.");
        }
    }
}
