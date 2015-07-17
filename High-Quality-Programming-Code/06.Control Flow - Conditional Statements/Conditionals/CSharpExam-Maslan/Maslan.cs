namespace CSharpExam_Maslan
{
    using System;
    using System.Numerics;
    using System.Linq;

    public class Maslan
    {
        public static void Main()
        {
            BigInteger input = BigInteger.Parse(Console.ReadLine());
            int transformations = 0;
            int sum = 0;
            BigInteger product = 1;

            while (true)
            {
                int numDigits = input.ToString().Length;
                for (int i = 0; i < numDigits - 1; i++)
                {
                    input /= 10;

                    int[] digits = input.ToString().ToCharArray().Select(x => (int)Char.GetNumericValue(x)).ToArray();

                    for (int j = 0; j < digits.Length; j++)
                    {
                        if (j % 2 == 1)
                        {
                            if (digits[j] != 0)
                            {
                                sum += digits[j];
                            }
                        }
                    }

                    if (sum != 0)
                    {
                        product *= sum;
                    }

                    sum = 0;
                }

                ++transformations;

                numDigits = product.ToString().Length;
                if (numDigits <= 1 || transformations > 9)
                {
                    if (transformations >= 10)
                    {
                        Console.WriteLine(product);
                    }
                    else
                    {
                        Console.WriteLine(transformations);
                        Console.WriteLine(product);
                    }
                    break;
                }

                input = product;
                product = 1;
            }
        }
    }
}
