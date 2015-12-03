using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessagesInABottle
{
    class Program
    {
        static SortedSet<string> validCombos = new SortedSet<string>();
        private static string message;
        private static string[] codes;
        private static char[] currentMessage;

        static void Main(string[] args)
        {
            codes = new string[26];

            currentMessage = new char[100];

            message = Console.ReadLine();

            var cipher = Console.ReadLine();

            int currentLetter = 0;

            for (int i = 0; i < cipher.Length; i++)
            {
                if (cipher[i] - 65 >= 0)
                {
                    currentLetter = cipher[i] - 65;
                }
                else
                {
                    codes[currentLetter] += cipher[i];
                }
            }

            Decode(0, 0);
            Console.WriteLine(validCombos.Count);
            Console.WriteLine(string.Join(Environment.NewLine, validCombos));
        }

        private static void AddSolution(char[] currentMessageOrig)
        {
            StringBuilder originalMessage = new StringBuilder();
            foreach (char c in currentMessageOrig)
            {
                if (c < 'A' || c > 'Z')
                {
                    break;
                }

                originalMessage.Append(c);
            }
            validCombos.Add(originalMessage.ToString());
        }

        private static void Decode(int index, int wordIndex)
        {
            if (index == message.Length)
            {
                AddSolution(currentMessage);
                return;
            }

            if (index > message.Length)
            {
                return;
            }

            var i = 0;
            foreach (var code in codes)
            {
                if (code != null)
                {
                    if (message.Length >= index + code.Length &&
                        message.Substring(index, code.Length) == code)
                    {
                        currentMessage[wordIndex] = (char)(i + 65);
                        Decode(index + code.Length, wordIndex + 1);
                        currentMessage[wordIndex] = '\0';
                    }
                }

                i++;
            }
        }
    }
}
