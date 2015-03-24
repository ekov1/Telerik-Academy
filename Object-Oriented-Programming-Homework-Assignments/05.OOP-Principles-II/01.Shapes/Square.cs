namespace _01.Shapes
{
    class Square : Rectangle
    {
        private double side;

        public Square(int side) 
            : base(side, side)
        {
        }

        public override double CalculateSurface()
        {
            return this.Width*this.Height;
        }
    }
}
