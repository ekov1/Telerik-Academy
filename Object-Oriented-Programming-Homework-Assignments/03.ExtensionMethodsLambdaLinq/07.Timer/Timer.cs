using System.Threading;

namespace _07.Timer
{
    public class Timer
    {

        private int frequency;

        public Timer(int interval)
        {
            this.Frequency = interval;
        }

        public TimerDelegate Methods { get; set; }

        public int Frequency { get; set; }

        public delegate void TimerDelegate();

        public void ExecuteMethods()
        {
            while (true)
            {
                this.Methods();
                Thread.Sleep(this.Frequency);
            }
        }
    }
}
