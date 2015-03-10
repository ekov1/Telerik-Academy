
//Write a program that compares two text files line by line and prints the number of lines that are the same and the number of lines that are different.
//Assume the files have equal number of lines.

//They are pseudo random, so you'll see the difference after 4-5 tests :)
using System;
using System.IO;
namespace _04.CompareTextFiles
{
    class CompareTextFiles
    {
        public static int index = 10;
        public static Random rand = new Random();
        static void Main(string[] args)
        {
            GeneratingText();
            int counterSame = 0;
            int counterDifferent = 0;
            using (StreamReader reader = new StreamReader("text1.txt"))
            {
                using (StreamReader readerTwo = new StreamReader("text2.txt"))
                {
                    for (int i = 0; i < index; i++)
                    {
                        string lineOne = reader.ReadLine();
                        string lineTwo = readerTwo.ReadLine();
                        if (lineOne == lineTwo)
                        {
                            counterSame++;
                        }
                        else
                        {
                            counterDifferent++;
                        }
                    }
                }
            }
            Console.WriteLine("The number of same lines is: {0}\nAnd the number of different is: {1}", counterSame, counterDifferent);
        }

        private static void GeneratingText()
        {
            using (StreamWriter writer = new StreamWriter("text1.txt"))
            {
                for (int i = 0; i < index; i++)
                {
                    writer.WriteLine(new string('a', rand.Next(index)));
                }
            }
            using (StreamWriter writer = new StreamWriter("text2.txt"))
            {
                for (int i = 0; i < index; i++)
                {
                    writer.WriteLine(new string('a', rand.Next(index)));
                }
            }
        }
    }
}
