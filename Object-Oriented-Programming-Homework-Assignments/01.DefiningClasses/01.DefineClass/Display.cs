using System;

namespace _01.DefineClass
{
    public class Display
    {

        private double size;
        private long colors;

        public Display(double size)
        {
            this.Size = size;
        }

        public Display(double size, long colors)
        {
            this.Size = size;
            this.Colors = colors;
        }

        public double Size { get; private set; }
        public long Colors { get; private set; }

        public override string ToString()
        {
            return String.Format(@"Display Size: {0} inches,
Display Colors: {1}", this.Size, this.Colors);
        }
    }
}
