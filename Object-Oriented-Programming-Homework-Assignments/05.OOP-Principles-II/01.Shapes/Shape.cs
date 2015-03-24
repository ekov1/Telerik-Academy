namespace _01.Shapes
{
    public abstract class Shape
    {
        private double width;
        private double height;

        public Shape(double width, double height)
        {
            this.Width = width;
            this.Height = height;
        }

        public double Width
        {
            get { return width; }
            private set { width = value; }
        }

        public double Height
        {
            get { return height; }
            private set { height = value; }
        }

        public abstract double CalculateSurface();
    }
}
