namespace RefactorLoop
{
    using System;

    public class LoopTest
    {
        private const int ExpectedValue = 42;

        public static void Main()
        {
            int[] arr = GenerateIntsArray(102);

            for (int i = 0; i < 100; i++)
            {
                if (i % 10 == 0)
                {
                    Console.WriteLine(arr[i]);
                }

                if (i == ExpectedValue)
                {
                    Console.WriteLine("Value Found - {0}", ExpectedValue);
                    break;
                }
            }
        }

        public static int[] GenerateIntsArray(int count)
        {
            var arr = new int[count];
            for (int i = 0; i < count; i++)
            {
                arr[i] = i;
            }

            return arr;
        }
    }
}
