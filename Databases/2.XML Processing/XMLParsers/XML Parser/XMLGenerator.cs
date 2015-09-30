using System;
using System.Collections.Generic;
using System.Xml.Linq;
using XML_Parser.Models;

namespace XML_Parser
{
    public class XMLGenerator
    {
        public XDocument GenerateCustomXML(int entries)
        {
            var data = this.GenerateAlbums(entries);

            XDocument doc = new XDocument {Declaration = new XDeclaration("1.0", "utf-8", null)};

            var root = new XElement("catalogue");

            doc.Add(root);

            foreach (var entry in data)
            {
                var album = new XElement("album", 
                    new XElement("name", entry.Name), 
                    new XElement("artist", entry.Artist), 
                    new XElement("year", entry.Year), 
                    new XElement("producer", entry.Producer), 
                    new XElement("price", entry.Price));

                var songs = new XElement("songs");

                foreach (var song in entry.Songs)
                {
                    var currSong = new XElement("song", 
                        new XElement("title", song.Title), 
                        new XElement("duration", song.Duration));

                    songs.Add(currSong);
                }

                album.Add(songs);

                root.Add(album);
            }

            return doc;
        }

        private IList<Album> GenerateAlbums(int entries)
        {
            var list = new List<Album>();
            var artists = new string[] {
                "Pesho",
                "Pochivni Dni",
                "Rigana",
                "Gosho",
                "Mc Petko",
                "Lamqta",
                "Snoop Kolyo",
                "Muhanela",
                "KURaBEATkata"
            };
            var name = new string[]
            {
                "Mnogo stanahte",
                "Te sa cherni",
                "Beloto",
                "gibsoKartoniteee",
                "89",
                "Pop Hits 2015",
                "Le Shitty Kygo's remixes",
                "90te godini",
                "Zlatnite hitove na Lamqta"
            };
            var year = new int[]
            {
                1998, 2005, 2016, 2001, 2004, 2002, 2010, 2012, 2015
            };
            var producer = "Drisko";

            var prices = new double[] {
                14.5,
                22,
                34,
                15,
                9.99,
                19.99,
                24.99,
                21.99,
                2.99,
                6.79,
                29.99
            };

            var songs = new List<IList<Song>>();
            songs.Add(new List<Song>() { new Song("1. Te sa zeleni", 3.12), new Song("2. Pachata", 4.40), new Song("3. Nie sme veliki", 2.32) });
            songs.Add(new List<Song>() { new Song("1. Chervenite momcheta", 5.02), new Song("2. Loshite momcheta", 3.43), new Song("3. Tq se mqta", 6.00) });
            songs.Add(new List<Song>() { new Song("1. Zdrasti mace", 5.52), new Song("2. Chao murshoo", 2.58) });
            songs.Add(new List<Song>() { new Song("1. Hills", 4.33), new Song("2. Call me", 4.02), new Song("3. Shake it", 3.38), new Song("4. Another Generic Pop Song", 6.22), new Song("5. I see fire (Kygo)", 5.34) });

            var artistRNG = new Random();
            var namesRNG = new Random();
            var yearsRNG = new Random();

            for (int i = 0; i < entries; i++)
            {
                list.Add(new Album(name[(namesRNG.Next() % name.Length)], artists[(artistRNG.Next() % artists.Length)], year[(yearsRNG.Next() % year.Length)], producer, prices[(yearsRNG.Next() % prices.Length)], songs[(i % songs.Count)]));
            }

            return list;
        }

    }
}
