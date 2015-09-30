namespace XML_Parser
{
    using System;
    using System.Collections.Generic;
    using System.Xml;
    using System.Xml.Linq;
    using System.Linq;


    class Program
    {
        static void Main(string[] args)
        {
            var fileLocation = "../../xml/catalogue.xml";


           /*
           var generator = new XMLGenerator();

           var numberOfEntries = 15;

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
                var price = Double.Parse(node["price"].InnerText);
                
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
    }
}
