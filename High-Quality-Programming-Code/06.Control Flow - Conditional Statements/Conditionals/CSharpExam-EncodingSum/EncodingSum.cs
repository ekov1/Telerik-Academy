namespace CSharpExam_EncodingSum
{
    using System;

    /// <summary>
    /// @ means end of input and printing result
    /// digits 0-9 multiply the result by the value of the digit
    /// letters - index is added to the result (note. alphabet starts with a 0 and ends in 25)
    /// a "default" symbol means "moduling" the result (%)
    /// </summary>
    public class EncodingSum
    {
        private const int MinTextLength = 1;
        private const int MaxTextLength = 100000;

        public static void Main()
        {
            double module = double.Parse(Console.ReadLine());
            string text = Console.ReadLine();
            double result = 0;

            if (text.Length < MinTextLength || text.Length > MaxTextLength)
            {
                throw new ArgumentOutOfRangeException(text, "The input text is not of appropriate length!");
            }

            foreach (char symbol in text)
            {
                if ((symbol >= 'A' && symbol <= 'Z') || (symbol >= 'a' && symbol <= 'z'))
                {
                    if (symbol >= 'A' && symbol <= 'Z')
                    {
                        result += symbol - 65;
                    }

                    if (symbol >= 'a' && symbol <= 'z')
                    {
                        result += symbol - 97;
                    }
                }
                else if (symbol >= '0' && symbol <= '9')
                {
                    int currentNumber = symbol - '0';
                    result *= currentNumber;
                }
                else if ((symbol >= 0 && symbol <= 47) || (symbol >= 58 && symbol <= 63) || (symbol >= 91 && symbol <= 96) || (symbol >= 123 && symbol <= 255))
                {
                    result = result % module;
                }
                else if (symbol == '@')
                {
                    Console.WriteLine(result);
                }
            }
        }
    }
}
