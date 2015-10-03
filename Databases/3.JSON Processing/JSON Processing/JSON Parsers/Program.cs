using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Xml.Linq;
using JSON_Parsers.Models;
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

            doc.Save("../../Output Files/ta-yt-feed.xml");

            var json = JsonConvert.SerializeXNode(doc, Formatting.Indented);

            var jsonObj = JObject.Parse(json);

            File.WriteAllText("../../Output Files/ta-yt-feed.json", json);

            GetAllVideoTitles(jsonObj);

            var videos = GetAllVideosFromJSON(jsonObj);
            videos = MakeValidEmbedableVideoLinks(videos);
            var html = GenerateHTMLFromVideos(videos);

            File.WriteAllText("../../Output Files/parsedFeed.html", html);

        }

        private static void GetAllVideoTitles(JObject json)
        {
            var entries = json["feed"]["entry"]
                .Select(y => y["title"]).ToList();

            Console.WriteLine("Video Titles found in the RSS Feed: \n" + string.Join("\r\n", entries) + "\n");
            Console.WriteLine("--------------");
        }

        private static IEnumerable<Video> GetAllVideosFromJSON(JObject json)
        {
            return json["feed"]["entry"].Select(x => JsonConvert.DeserializeObject<Video>(x.ToString()));
        }

        private static IEnumerable<Video> MakeValidEmbedableVideoLinks(IEnumerable<Video> videos)
        {
            var makeValidEmbedableVideoLinks = videos as Video[] ?? videos.ToArray();

            foreach (var video in makeValidEmbedableVideoLinks)
            {
                video.Link.Href = video.Link.Href.Replace("watch?v=", "embed/");
            }

            return makeValidEmbedableVideoLinks;
        }

        private static string GenerateHTMLFromVideos(IEnumerable<Video> videos)
        {
            var html = new StringBuilder();

            html.Append("<!DOCTYPE html><html>" +
                "<head>" +
                "<style>" + 
                "body { " +
                        "background-color:#00FF22;" +
                        "}" +
                    "div { " +
                        "width: 420px; height: 450px; padding:10px; margin:5px; background-color:#AAA; border-radius:10px " +
                        "}" +
                "</style>" +
                "</head>" +
                "<body>");

            foreach (var video in videos)
            {
                html.Append("<div> <h4>" + video.Title + "</h4>" +
                                  "<iframe width=\"420\" height=\"345\" " + "src=\"" + video.Link.Href + "\" " +
                                  "frameborder=\"0\" allowfullscreen></iframe>" +
                                  "<br /><a href=\"" + video.Link.Href + "\">Watch on Youtube</a></div>");
            }
            html.Append("</body></html>");

            return html.ToString();
        }

    }
}
