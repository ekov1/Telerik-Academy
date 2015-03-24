using System;

namespace _03.RangeExceptions
{
    class ExceptionsTest
    {
        static void Main()
        {

            try
            {
                throw new InvalidRangeException<int>("Incompatible range!", 1, 100);
            }
            catch (InvalidRangeException<int> e)
            {
                Console.WriteLine(e.Message + "\n");
            }

            try
            {
                throw new InvalidRangeException<DateTime>("Invalid date!", new DateTime(1980, 5, 6), new DateTime(2013, 12, 31));
            }
            catch (InvalidRangeException<DateTime> e)
            {
                Console.WriteLine(e.Message +  "\n");
            }

        }
    }
}
