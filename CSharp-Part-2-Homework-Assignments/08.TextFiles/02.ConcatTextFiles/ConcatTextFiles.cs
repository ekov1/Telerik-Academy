
    //Write a program that concatenates two text files into another text file.

using System;
using System.IO;

namespace _02.ConcatTextFiles
{
    class ConcatTextFiles
    {
        public static string textOne = string.Empty;
        public static string textTwo = string.Empty;

        static void Main(string[] args)
        {
            GeneratingText();
            ReadingText();
            using (StreamWriter writer = new StreamWriter("final.txt"))
            {
                writer.Write(textOne);
                writer.Write(textTwo);
            }
        }

        private static void ReadingText()
        {
            using (StreamReader reader = new StreamReader("text1.txt"))
            {
                textOne = reader.ReadToEnd();
            }
            using (StreamReader reader = new StreamReader("text2.txt"))
            {
                textTwo = reader.ReadToEnd();
            }
        }

        private static void GeneratingText()
        {
            using (StreamWriter writer = new StreamWriter("text1.txt"))
            {
                for (int i = 1; i < 20; i++)
                {
                    writer.WriteLine(i);
                }
            }
            using (StreamWriter writer = new StreamWriter("text2.txt"))
            {
                for (int i = 20; i < 40; i++)
                {
                    writer.WriteLine(i);
                }
            }
        }

    }
}
