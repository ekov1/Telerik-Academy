
    //Write a program that reads a text file and inserts line numbers in front of each of its lines.
    //The result should be written to another text file.

using System;
using System.IO;
class LineNumbers
{
    static void Main()
    {
        GeneratingText();
        using (StreamReader reader = new StreamReader("text.txt"))
        {
            string line = reader.ReadLine();
            int count = 1;
            using (StreamWriter writer = new StreamWriter("final.txt"))
            {
                while (line != null)
                {
                    writer.WriteLine("{0:D2}. {1}", count, line);
                    count++;
                    line = reader.ReadLine();
                }
            }
        }
    }

    private static void GeneratingText()
    {
        using (StreamWriter writer = new StreamWriter("text.txt"))
        {
            for (int i = 1; i < 20; i++)
            {
                writer.WriteLine(i);
            }
        }
    }
}