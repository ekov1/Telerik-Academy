using System;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace XML_Parser___Files
{
    class Program
    {
        static void Main()
        {
            GenerateXMLFromTextDocument();

            var desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            GenerateXMLFromDirectoryTreeUsingXMLWriter(desktop);
            GenerateXMLFromDirectoryTreeUsingXDocument(desktop);
        }

        private static void GenerateXMLFromTextDocument()
        {
            var fileLocation = "../../files/person.txt";
            var doc = new XElement("person");

            using (var reader = new StreamReader(fileLocation))
            {
                doc.Add(new XElement("name", reader.ReadLine()));
                doc.Add(new XElement("address", reader.ReadLine()));
                doc.Add(new XElement("phone", reader.ReadLine()));
            }

            Console.WriteLine("person.xml generated in files/person.xml");
            doc.Save("../../files/person.xml");
        }

        private static void GenerateXMLFromDirectoryTreeUsingXMLWriter(string root)
        {
            Console.WriteLine("Directory whose files was analyzed: " + root);

            using (var writer = new XmlTextWriter("../../files/filesystem.xml", Encoding.UTF8))
            {
                writer.Formatting = Formatting.Indented;
                writer.IndentChar = '\t';
                writer.Indentation = 1;

                writer.WriteStartDocument();
                writer.WriteStartElement("directories");
                TraverseFileSystem(root, writer);
                writer.WriteEndElement();
                writer.WriteEndDocument();
            }

            Console.WriteLine("filesystem.xml generated in files/filesystem.xml");
        }

        private static void TraverseFileSystem(string path, XmlTextWriter writer)
        {
            try
            {
                foreach (var dir in Directory.GetDirectories(path))
                {
                    writer.WriteStartElement("dir");
                    writer.WriteAttributeString("path", dir);
                    
                    TraverseFileSystem(dir, writer);

                    foreach (var file in Directory.GetFiles(dir))
                    {
                        writer.WriteStartElement("file");
                        writer.WriteAttributeString("name", Path.GetFileName(file));
                        writer.WriteEndElement();
                    }

                    writer.WriteEndElement();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("An error occured while trying to read the file tree!");
                Console.WriteLine(e.Message);
            }
        }

        private static void GenerateXMLFromDirectoryTreeUsingXDocument(string root)
        {
            XDocument doc = new XDocument { Declaration = new XDeclaration("1.0", "utf-8", null) };

            var rootElement = new XElement("directories");

            rootElement.Add(TraverseFileSystem(root));
            
            doc.Add(rootElement);

            doc.Save("../../files/filesystemX.xml");

            Console.WriteLine("filesystemX.xml generated in files/filesystemX.xml");
        }

        private static XElement TraverseFileSystem(string path)
        {
            var element = new XElement("dir", new XAttribute("path", path));

            foreach (var dir in Directory.GetDirectories(path))
            {
                element.Add(TraverseFileSystem(dir));
            }

            foreach (var file in Directory.GetFiles(path))
            {
                element.Add(new XElement("file", new XAttribute("name", Path.GetFileName(file))));
            }

            return element;
        }
    }
}
