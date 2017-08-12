using System.Collections.Generic;
using Lastfm.NETCore.Model;
using Newtonsoft.Json;

namespace Lastfm.NETCore.Dto
{
    internal class SearchTrackDto
    {
        #region [Properties]

        [JsonProperty("artist")]
        internal string Artist { get; set; }

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

        [JsonProperty("image")]
        public IList<ImageDto> Images { get; set; }
        
        #endregion
    }
}