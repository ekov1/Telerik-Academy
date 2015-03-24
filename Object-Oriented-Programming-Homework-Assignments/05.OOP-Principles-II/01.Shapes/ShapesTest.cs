using System;

namespace _01.Shapes
{
    class ShapesTest
    {
        static void Main()
        {
            Shape[] shapes = new Shape[]
            {
                new Triangle(5,10),
                new Rectangle(5,10),
                new Square(4)
            };

            foreach (var item in shapes)
            {
                Console.WriteLine("{0}'s surface is {1}", item.GetType(), item.CalculateSurface());
            }
        }
    }
}
