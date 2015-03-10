//I'm generating the text for each problem in a method to make my homework.rar as small as possible. You can always just
//swap the input paths to a test file of your choosing :)

//Write a program that reads a text file and prints on the console its odd lines.
using System;
using System.IO;
class OddLines
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
        using (StreamReader reader = new StreamReader("text.txt"))
        {
            for (int i = 1; i < 20; i++)
            {
                string line = reader.ReadLine();
                if (i % 2 == 1)
                {
                    Console.WriteLine(line);
                }
                
            }
        }

    }
}