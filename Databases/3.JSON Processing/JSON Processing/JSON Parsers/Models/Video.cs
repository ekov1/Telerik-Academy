using Newtonsoft.Json;

namespace JSON_Parsers.Models
{
    public class Video
    {
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("link")]
        public Url Link { get; set; }

        [JsonProperty("yt:videoId")]
        public string Id { get; set; }
    }
}
