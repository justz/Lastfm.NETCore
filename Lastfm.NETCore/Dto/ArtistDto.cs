using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Lastfm.NETCore.Builder;
using Lastfm.NETCore.Common;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using static Lastfm.NETCore.Helper.RestClientHelper;

namespace Lastfm.NETCore.Dto
{
    public class ArtistDto
    {
        #region [Properties]

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("mbid")]
        public string Mbid { get; set; }

        [JsonProperty("match")]
        public string Match { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("image")]
        public IList<ImageDto> Images { get; set; }

        [JsonProperty("streamable")]
        public string Streamable { get; set; }

        [JsonProperty("listeners")]
        public string Listeners { get; set; }

        #endregion

        #region [Methods]

        public override string ToString()
        {
            return Name;
        }

        #endregion
    }
}