using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Lastfm.NETCore.Builder;
using Lastfm.NETCore.Common;
using Lastfm.NETCore.Dto;
using Newtonsoft.Json;
using static Lastfm.NETCore.Helper.RestClientHelper;

namespace Lastfm.NETCore.Dto
{
    public class TrackDto
    {
        #region [Properties]

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

//        [JsonProperty("streamable")]
//        public string Streamable { get; set; }

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