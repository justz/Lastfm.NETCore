﻿using System.Collections.Generic;
using Newtonsoft.Json;

namespace Lastfm.NETCore.Model
{
    public class Track
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("playcount")]
        public string Playcount { get; set; }

        [JsonProperty("listeners")]
        public string Listeners { get; set; }

        [JsonProperty("mbid")]
        public string Mbid { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("streamable")]
        public string Streamable { get; set; }

        [JsonProperty("artist")]
        public Artist Artist { get; set; }

        [JsonProperty("image")]
        public IList<Image> Image { get; set; }
    }
}