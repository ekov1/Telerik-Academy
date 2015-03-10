
    //Write a program that deletes from given text file all odd lines.
    //The result should be in the same file.

using System;
using System.Collections.Generic;
using System.IO;
class DeleteOddLines
{
    static void Main()
    {
        using (StreamWriter writer = new StreamWriter("text.txt"))
        {
            for (int i = 1; i < 20; i++)
            {
                writer.WriteLine(i);
            }
        }
        List<string> lines = new List<string>();
        using (StreamReader reader = new StreamReader("text.txt"))
        {
            int counter = 1;
            string line = reader.ReadLine();
            while (line != null)
            {
                if (counter % 2 == 0)
                {
                    lines.Add(line);
                }
                line = reader.ReadLine();
                counter++;
            }
        }
        using (StreamWriter writer = new StreamWriter("text.txt"))
        {
            foreach (string line in lines)
            {
                writer.WriteLine(line);
            }
        }
    }
}