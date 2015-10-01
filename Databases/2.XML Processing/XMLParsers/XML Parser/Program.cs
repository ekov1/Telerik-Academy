using System.Runtime.InteropServices;
using System.Xml.Schema;
using System.Xml.Xsl;

namespace XML_Parser
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.Linq;
    using System.Linq;


    class Program
    {
        static void Main()
        {
            var fileLocation = "../../xml/catalogue.xml";

            Console.WriteLine("---- DISCLAIMER: ----");
            Console.WriteLine("-- This project holds all the xml manipulation related to the catalogue tasks --");
            Console.WriteLine("-- Look for the implementation in the Program.cs of the project -- ");
            Console.WriteLine("-- For the other tasks related to the local file system open the XML Parser - Files project --");
            Console.WriteLine("--------\n");
            Console.WriteLine("The XML Entries are generated through a custom generator, if you wish to fill in the catalogue with new entries, just uncommend the code block!\n");
           /*
           var generator = new XMLGenerator();

           var numberOfEntries = 25;

           var document = generator.GenerateCustomXML(numberOfEntries);

           document.Save(fileLocation);
           Console.WriteLine("catalogue.xml generated in xml/ !\n");
           */

            GetArtistsAndTheNumberOfTheirAlbumsUsingDOMParser(fileLocation);
            Console.WriteLine("\n\n");
            GetArtistsAndTheNumberOfTheirAlbumsUsingXPath(fileLocation);
            Console.WriteLine("\n\n");
            DeleteAllAlbumsWithPriceGreaterThan20UsingDOMParser(fileLocation);
            Console.WriteLine("\n\n");
            ExtractAllSongTitlesUsingXmlReader(fileLocation);
            Console.WriteLine("\n\n");
            ExtractAllSongTitlesUsingXDocumentLINQ(fileLocation);
            Console.WriteLine("\n\n");
            ExtractAllAlbumsAndTheirAuthorsInXML(fileLocation);
            Console.WriteLine("\n\n");
            GetAllNewAlbumsPricesUsingXPath(fileLocation);
            Console.WriteLine("\n\n");
            GetAllNewAlbumsPricesUsingLINQ(fileLocation);
            Console.WriteLine("\n\n");
            XslTransformToHtml(fileLocation);
            Console.WriteLine("\n\n");
            ValidateXmlAgainstXsd(fileLocation);
        }

        private static void GetArtistsAndTheNumberOfTheirAlbumsUsingXPath(string fileLocation)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileLocation);

            var artistsList = new Dictionary<string, int>();

            var queryPath = "/catalogue/album/artist";

            XmlNodeList artists = doc.SelectNodes(queryPath);

            foreach (XmlNode artistNode in artists)
            {
                var artist = artistNode.InnerText;

                if (artistsList.ContainsKey(artist))
                {
                    artistsList[artist]++;
                }
                else
                {
                    artistsList.Add(artist, 1);
                }
            }

            Console.WriteLine("Artists and the number of produced albums: {{Using xPath}}\n");
            foreach (var entry in artistsList)
            {
                Console.WriteLine("Artist ~~ {0} ~~ has {1} albums in the current entry!", entry.Key, entry.Value);
            }
        }

        private static void GetArtistsAndTheNumberOfTheirAlbumsUsingDOMParser(string fileLocation)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileLocation);
            var root = doc.DocumentElement;

            var artistsList = new Dictionary<string, int>();

            foreach (XmlNode node in root.ChildNodes)
            {
                var artist = node["artist"].InnerText;
                if (artistsList.ContainsKey(artist))
                {
                    artistsList[artist]++;
                }
                else
                {
                    artistsList.Add(artist, 1);
                }
            }

            Console.WriteLine("Artists and the number of produced albums: {{Using DOM-Parser}}\n");
            foreach (var entry in artistsList)
            {
                Console.WriteLine("Artist ~~ {0} ~~ has {1} albums in the current entry!", entry.Key, entry.Value);
            }
        }

        private static void DeleteAllAlbumsWithPriceGreaterThan20UsingDOMParser(string fileLocation)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileLocation);
            var root = doc.DocumentElement;
            var nodesToRemove = new List<XmlNode>();

            foreach (XmlNode node in root.ChildNodes)
            {
                var price = double.Parse(node["price"].InnerText);
                
                if (price > 20)
                {
                    nodesToRemove.Add(node);
                }
            }

            foreach (XmlNode node in nodesToRemove)
            {
                root.RemoveChild(node);
            }

            Console.WriteLine("catalogueWithDeletedAlbums.xml generated in xml/ !\n");
            doc.Save("../../xml/" + "catalogueWithDeletedAlbums.xml");
        }

        private static void ExtractAllSongTitlesUsingXmlReader(string fileLocation)
        {
            Console.WriteLine("All song titles in the document: \n");
            using (XmlReader reader = new XmlTextReader(fileLocation))
            {
                var songList = new List<string>();

                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element && reader.Name == "title")
                    {
                        var songTitle = reader.ReadElementString();

                        if (!songList.Contains(songTitle))
                        {
                            songList.Add(songTitle);
                            Console.WriteLine(songTitle);
                        }
                    }
                }
            }
        }

        private static void ExtractAllSongTitlesUsingXDocumentLINQ(string fileLocation)
        {
            Console.WriteLine("All song titles in the document using XDocument and LINQ: \n");

            var doc = XDocument.Load(fileLocation);
            
            var titles = from title in doc.Descendants("title") select title.Value;
            // removes duplicate entries
            titles = titles.GroupBy(x => x).Select(y => y.First());
            Console.WriteLine(string.Join("\r\n", titles));
        }

        private static void ExtractAllAlbumsAndTheirAuthorsInXML(string fileLocation)
        {
            var albumsLocation = "../../xml/album.xml";

            using (var reader = new XmlTextReader(fileLocation))
            {
                using (var writer = new XmlTextWriter(albumsLocation, Encoding.UTF8))
                {
                    writer.Formatting = Formatting.Indented;
                    writer.IndentChar = '\t';
                    writer.Indentation = 1;

                    writer.WriteStartDocument();
                    writer.WriteStartElement("albums");

                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element && reader.Name == "name")
                        {
                            writer.WriteStartElement("album");
                            writer.WriteStartElement("name");
                            writer.WriteString(reader.ReadElementString());
                            writer.WriteEndElement();
                        }
                        if (reader.NodeType == XmlNodeType.Element && reader.Name == "artist")
                        {
                            writer.WriteStartElement("artist");
                            writer.WriteString(reader.ReadElementString());
                            writer.WriteEndElement();
                            writer.WriteEndElement();
                        }
                    }

                    writer.WriteEndElement();
                    writer.WriteEndDocument();
                }
            }
            Console.WriteLine("Albums and their authors .xml generated in xml/album.xml \n");
        }

        private static void GetAllNewAlbumsPricesUsingXPath(string fileLocation)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(fileLocation);
            var queryPath = "/catalogue/album/price[../year>2010]";

            XmlNodeList prices = doc.SelectNodes(queryPath);

            Console.WriteLine("Prices of all albums released no later than 5 years ago Using XPath: \n");
            foreach (XmlNode price in prices)
            {
                Console.Write(price.InnerText + ", ");
            }
        }

        private static void GetAllNewAlbumsPricesUsingLINQ(string fileLocation)
        {
            var doc = XDocument.Load(fileLocation);

            var prices = doc.Descendants("album").Where(x => int.Parse(x.Element("year").Value) > 2010).Select(x => x.Element("price").Value).ToList();

            Console.WriteLine("Prices of all albums released no later than 5 years ago Using LINQ: \n");
            Console.WriteLine(string.Join(", ", prices));
        }

        private static void XslTransformToHtml(string fileLocation)
        {
            XslCompiledTransform xslt = new XslCompiledTransform();
            xslt.Load("../../xml/catalogue.xslt");
            xslt.Transform(fileLocation, "../../xml/catalogue.html");
            Console.WriteLine("Catalogue.xml as HTML generated in xml/catalogue.html");
        }

        private static void ValidateXmlAgainstXsd(string fileLocation)
        {
            var schemas = new XmlSchemaSet();
            schemas.Add(string.Empty, "../../xml/catalogue.xsd");

            XDocument doc = XDocument.Load(fileLocation);
            XDocument invalidDoc = XDocument.Load("../../xml/invalidCatalogue.xml");

            Console.WriteLine("Validating a valid Xml against xsd results: ");
            doc.Validate(schemas, (sender, args) => Console.WriteLine(args.Message));
            Console.WriteLine("\nValidating an invalid xml against xsd results: ");
            invalidDoc.Validate(schemas, (sender, args) => Console.WriteLine(args.Message));
        }
    }
}
