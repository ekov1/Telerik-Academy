
//    Write a program that reads a text file containing a list of strings, sorts them and saves them to another text file.

//Example:
//input.txt 	output.txt
//Ivan
//Peter
//Maria
//George 	    George
//Ivan
//Maria
//Peter
using System;
using System.Collections.Generic;
using System.IO;
class SaveSortedNames
{
    static void Main()
    {
        GenerateText();
        List<string> listOfNames = new List<string>();
        using (StreamReader reader = new StreamReader("text.txt"))
        {
            string line = reader.ReadLine();
            while (line != null)
            {
                listOfNames.Add(line);
                line = reader.ReadLine();
            }
        }
        listOfNames.Sort();
        using (StreamWriter writer = new StreamWriter("sorted.txt"))
        {
            foreach (string name in listOfNames)
            {
                writer.WriteLine(name);
            }
        }
    }
    private static void GenerateText()
    {
        using (StreamWriter writer = new StreamWriter("text.txt"))
        {
            writer.WriteLine("Ivan");
            writer.WriteLine("Peter");
            writer.WriteLine("Maria");
            writer.WriteLine("Gosho");
        }
    }
}