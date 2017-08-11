using System.Collections.Generic;
using Newtonsoft.Json;

namespace Lastfm.NETCore.Dto
{
    public class AlbumDto
    {
        #region [Properties]

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("playcount")]
        public int Playcount { get; set; }

        [JsonProperty("mbid")]
        public string Mbid { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("artist")]
        public ArtistDto Artist { get; set; }

        [JsonProperty("image")]
        public IList<ImageDto> Images { get; set; }

        #endregion

        #region [Methods]

        public override string ToString()
        {
            return Name;
        }

        #endregion
    }
}