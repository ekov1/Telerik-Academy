using System;
using System.Collections.Generic;

namespace _01.Structure
{
    [Serializable]
    public class Path
    {
        private List<Point3D> pathsList;

        public Path()
        {
            this.PathsList = new List<Point3D>();
        }

        public List<Point3D> PathsList { get; private set; }

        public void AddPoint(Point3D point)
        {
            this.PathsList.Add(point);
        }

        public void RemovePoint(Point3D point)
        {
            this.PathsList.Remove(point);
        }
    }
}
