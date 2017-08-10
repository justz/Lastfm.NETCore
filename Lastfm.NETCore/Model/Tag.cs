using Newtonsoft.Json;

namespace Lastfm.NETCore.Model
{
    public class Tag
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }
}