using System;

namespace _07.Timer
{
    class TimerTest
    {
        static void Main()
        {
            var timer = new Timer(9);

            timer.Methods = Tick;
            timer.Methods += Tock;

            timer.ExecuteMethods();
        }

        private static void Tick()
        {
            Console.WriteLine("Tick");
        }

        private static void Tock()
        {
            Console.WriteLine("Tock");
        }

    }
}
