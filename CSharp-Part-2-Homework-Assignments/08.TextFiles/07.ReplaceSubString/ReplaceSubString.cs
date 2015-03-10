
    //Write a program that replaces all occurrences of the sub-string start with the sub-string finish in a text file.
    //Ensure it will work with large files (e.g. 100 MB).

using System;
using System.IO;
class ReplaceSubString
{
    static void Main()
    {
        GenerateText();
        using (StreamReader reader = new StreamReader("text.txt"))
        {
            using (StreamWriter writer = new StreamWriter("edit.txt"))
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    if (line.Contains("start"))
                    {
                        int index = line.IndexOf("start");
                        line = line.Remove(index, 5).Insert(index, "finish");
                        writer.WriteLine(line);
                    }
                    else
                    {
                        writer.WriteLine(line);
                    }
                    line = reader.ReadLine();
                }
            }
        }
    }
    private static void GenerateText()
    {
        using (StreamWriter writer = new StreamWriter("text.txt"))
        {
            for (int i = 0; i < 1000000; i++) 
//Adding more zeroes is possible, but unneeded. 
//Notepad takes longer to open the file than the program - to generate it :D A LOT longer.
            {
                writer.WriteLine("Ivan");
            writer.WriteLine("Peter");
            writer.WriteLine("start");
            writer.WriteLine("Gosho");
            }
        }
    }
}