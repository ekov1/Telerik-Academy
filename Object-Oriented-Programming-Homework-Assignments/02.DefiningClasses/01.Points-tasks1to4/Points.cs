using System;

namespace _01.Structure
{
    class Points
    {
        static void Main()
        {
            const string pathsPrefix = "..//..//Paths_";
            const string extension = ".data";
            string pathName = "testPath";


            Point3D point1 = new Point3D(0,0,0);
            Point3D point2 = new Point3D(15,2,6);
            Point3D point3 = new Point3D(2, 6, 17);
            Point3D point4 = new Point3D(2, 11, -2);


            Console.WriteLine(point1);
            Console.WriteLine(point2);
            Console.WriteLine();
            Console.WriteLine("{0:F4}", Distance.CalculateDistance(point1, point2));

            Path testPath = new Path();
            testPath.AddPoint(point1);
            testPath.AddPoint(point2);
            testPath.AddPoint(point3);
            testPath.AddPoint(point4);

            PathStorage.SavePath(testPath, pathName); //we save a path

            Path loadedPath = PathStorage.LoadPath(pathsPrefix + pathName + extension); //we load a path

        }
    }
}
