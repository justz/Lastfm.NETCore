using System.Collections.Generic;
using Newtonsoft.Json;

namespace Lastfm.NETCore.Model
{
    public class Album
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("playcount")]
        public int Playcount { get; set; }

        [JsonProperty("mbid")]
        public string Mbid { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("artist")]
        public Artist Artist { get; set; }

        [JsonProperty("image")]
        public IList<Image> Images { get; set; }
    }
}