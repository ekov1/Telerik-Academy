using System;

namespace _01.Structure
{
    [Serializable]
    public struct Point3D
    {
        private static readonly Point3D initialPoint3D;
        private double x;
        private double y;
        private double z;

        public Point3D(double x, double y, double z)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        static Point3D()
        {
            initialPoint3D = new Point3D(0, 0, 0);
        }

        public double X { get; private set; }
        public double Y { get; private set; }
        public double Z { get; private set; }
        public static Point3D InitialPoint3D { get { return initialPoint3D; } }


        public override string ToString()
        {
            return String.Format("X: {0},  Y: {1},  Z: {2}", this.X, this.Y, this.Z);
        }
    }
}
