
    //Write a program that deletes from a text file all words that start with the prefix test.
    //Words contain only the symbols 0…9, a…z, A…Z, _.

using System;
using System.Collections.Generic;
using System.IO;
class PrefixTest
{
    static void Main()
    {
        GeneratingText();
        Replace();
    }

    private static void Replace()
    {
        List<string> lines = new List<string>();
        using (StreamReader reader = new StreamReader("text.txt"))
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                lines.Add(line);
                line = reader.ReadLine();
            }
        }
        using (StreamWriter writer = new StreamWriter("text.txt"))
        {

            for (int i = 0; i < lines.Count; i++)
            {
                string line = lines[i] + " ";
                while (line.ToLower().Contains(" test") || line.IndexOf("test") == 0)
                {
                    int index = line.IndexOf("test");
                    line = line.Remove(index, (line.IndexOf(" ", index) - index));
                }
                writer.WriteLine(line.Trim());
            }
        }
    }
    private static void GeneratingText()
    {
        using (StreamWriter writer = new StreamWriter("text.txt"))
        {
            writer.WriteLine("stuff withtest, but not as a prefix");
            writer.WriteLine("stuff with testas a prefix");
            writer.WriteLine("stuff with test as a single word");
            writer.WriteLine("teststuff with test at the start");
            writer.WriteLine("test with test andtest testand test, just to (test all the test)");
        }
    }
}
