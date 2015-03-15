using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace _01.Structure
{
    public static class PathStorage
    {
        const string pathsPrefix = "..//..//Paths_";
        const string extension = ".data";

        public static void SavePath(Path path, string name)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            Stream stream = new FileStream(pathsPrefix + name + extension, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);

            formatter.Serialize(stream, path);
            stream.Close();
            Console.WriteLine("\nPath has been saved successfully!\n");
        }

        public static Path LoadPath(string name)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                Stream stream = new FileStream(name, FileMode.Open, FileAccess.Read, FileShare.Read);

                Path dessedPath = (Path) formatter.Deserialize(stream);
                stream.Close();
                Console.WriteLine("\nPath loaded successfully!\n");
                return dessedPath;
            }
            catch (Exception)
            {
                Console.WriteLine("File does not exist or could not load properly. Initialized an empty Path.");
                return new Path();
            }
        }
    }
}
