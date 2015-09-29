namespace XML_Parser
{
    using System;
    using System.Collections.Generic;
    using System.Xml;

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

            //// Extracting all unique artists and listing their albums

            GetArtistsAndTheNumberOfTheirAlbumsUsingDOMParser(fileLocation);
            Console.WriteLine("\n\n");
            GetArtistsAndTheNumberOfTheirAlbumsUsingXPath(fileLocation);
            Console.WriteLine("\n\n");
            DeleteAllAlbumsWithPriceGreaterThan20UsingDOMParser(fileLocation);
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
    }
}
