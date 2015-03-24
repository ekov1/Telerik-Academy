using System;

namespace _03.RangeExceptions
{
    class InvalidRangeException<T> : ApplicationException
    {
        private T start;
        private T end;

        public InvalidRangeException(string msg, T start, T end)
            :base(msg)
        {
            this.Start = start;
            this.End = end;
        }

        public InvalidRangeException(T start, T end)
            : this(null, start, end)
        {
        }

        public T Start
        {
            get { return start; }
            set { start = value; }
        }

        public T End
        {
            get { return end; }
            set { end = value; }
        }
    }
}
