using System;

namespace _01.Structure
{
    static class Distance
    {

        public static double CalculateDistance(Point3D p1, Point3D p2)
        {
            return Math.Sqrt((p2.X - p1.X)*(p2.X - p1.X) + (p2.Y - p1.Y)*(p2.Y - p1.Y) + (p2.Z - p1.Z)*(p2.Z - p1.Z));
        }

    }
}
