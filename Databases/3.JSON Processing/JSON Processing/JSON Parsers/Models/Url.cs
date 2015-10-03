using Newtonsoft.Json;

namespace JSON_Parsers.Models
{
    public class Url
    {
        [JsonProperty("@rel")]
        public string Rel { get; set; }

        [JsonProperty("@href")]
        public string Href { get; set; }
    }
}
