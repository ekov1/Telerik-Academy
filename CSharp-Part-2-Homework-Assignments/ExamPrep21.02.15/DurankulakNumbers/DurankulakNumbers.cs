using System;


namespace DurankulakNumbers
{
    class DurankulakNumbers
    {
        static void Main(string[] args)
        {
            ulong numBase = 168;
            //read input
            string input = Console.ReadLine();

            //calculations
            ulong number = 0;

            for (int i = 0; i < input.Length; i++) //can be extracted into a method
            {
                char letter = input[i];
                string currentNumber = string.Empty;

                if ('a' <= letter && letter <= 'z')
                {
                    currentNumber = string.Format("{0}{1}", input[i], input[i+1]);
                    i++;
                }
                else
                {
                    currentNumber = string.Format("{0}", letter);
                } //up to this point

                //currentNum
                number *= numBase;

                if (currentNumber.Length == 1)
                {
                    number += (ulong)currentNumber[0] - 'A';
                }
                else //if length > 1
                {
                    number += (ulong)(currentNumber[0] - 'a' + 1) * 26;
                    number += (ulong)(currentNumber[1] - 'A');
                }
            }

            //print output
            Console.WriteLine(number);
            
        }
    }
}
