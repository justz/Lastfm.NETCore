using System.Collections.Generic;
using Newtonsoft.Json;

namespace Lastfm.NETCore.Model
{
    public class Artist
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("mbid")]
        public string Mbid { get; set; }

        [JsonProperty("match")]
        public string Match { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("image")]
        public IList<Image> Image { get; set; }

        [JsonProperty("streamable")]
        public string Streamable { get; set; }
        
        [JsonProperty("listeners")]
        public string Listeners { get; set; }
    }
}