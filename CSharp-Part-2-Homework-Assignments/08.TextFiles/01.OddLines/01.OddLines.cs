using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Write a program that reads a text file and prints on the console its odd lines.

class Program
{
    static void Main()
    {
        Console.Write("The following text makes no sense because only every other line is displayed!\n\n");
        //string path = Console.ReadLine();

        StreamReader reader = new StreamReader("..\\..\\test.txt");
        string[] fileContents = reader.ReadToEnd().Split('\n');

        var result = new StringBuilder();

        for (int line = 0; line < fileContents.Length; line += 2)
        {
            result.AppendLine(fileContents[line]);
        }

        Console.WriteLine(result);
        reader.Close();
    }
}

