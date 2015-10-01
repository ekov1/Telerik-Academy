using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JSON_Parsers
{
    class Program
    {
        static void Main()
        {
            var data = new WebClient().DownloadData("https://www.youtube.com/feeds/videos.xml?channel_id=UCLC-vbm7OWvpbqzXaoAMGGw");
            var rssString = Encoding.UTF8.GetString(data).TrimEnd('\0');

            var doc = XDocument.Parse(rssString);
            
            doc.Save("../../files/ta-yt-feed.xml");

            var json = JsonConvert.SerializeXNode(doc, Formatting.Indented);

            File.WriteAllText("../../files/ta-yt-feed.json", json);

            var jsonObj = JObject.Parse(json);
            var entries = jsonObj["feed"]["entry"]
                .Select(y => y["title"]).ToList();

            Console.WriteLine("Video Titles found in the RSS Feed: \n" + string.Join("\r\n", entries) + "\n");
            Console.WriteLine("--------------");
        }
    }
}
