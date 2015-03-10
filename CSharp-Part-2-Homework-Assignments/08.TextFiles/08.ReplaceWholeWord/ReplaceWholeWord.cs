
    //Modify the solution of the previous problem to replace only whole words (not strings).

using System;
using System.IO;
class ReplaceWholeWord
{
    public static readonly string[] punctuation = new string[] { ".", ",", "!", "-", ":", "?" };
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
                    line = line.Insert(0, " ") + " ";
                    foreach (var symbol in punctuation)
                    {
                        line = line.Replace(symbol, (" " + symbol + " "));
                    }
                    if (line.ToLower().Contains(" start "))
                    {

                        int index = line.IndexOf(" start ");
                        line = line.Remove(index, 7).Insert(index, " finish ");
                        foreach (var symbol in punctuation)
                        {
                            line = line.Replace((" " + symbol + " "), symbol);
                        }
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
                writer.WriteLine("start.");
                writer.WriteLine("tostart or not to start");
                writer.WriteLine("startnao?");
                writer.WriteLine("start");
                writer.WriteLine("Gosho");
            }

        }
    }
}