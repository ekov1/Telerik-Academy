using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

//Write a program that concatenates two text files into another text file.

class Program
{
    static void Main()
    {
        try
        {
            string concatFile = File.ReadAllText("..\\..\\test1.txt") + File.ReadAllText("..\\..\\test2.txt");
            File.WriteAllText("..\\..\\concattedFile.txt", concatFile);
            Console.WriteLine("The new file has been created!");
        }
        catch
        {
            Console.WriteLine("There was an error while reading or writing the files!");
        }
    }
}
