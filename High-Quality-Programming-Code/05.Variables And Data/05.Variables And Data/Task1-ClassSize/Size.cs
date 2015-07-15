namespace Task1_ClassSize
{
    using System;

    public class Size
    {
        public double Width;
        public double Height;

        public Size(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public static Size GetRotatedSize(Size size, double angle)
        {
            return new Size(Math.Abs(Math.Cos(angle)) * size.Width + 
                Math.Abs(Math.Sin(angle)) * size.Height,
                Math.Abs(Math.Sin(angle)) * size.Width +
                Math.Abs(Math.Cos(angle)) * size.Height);
        }
    }
}
