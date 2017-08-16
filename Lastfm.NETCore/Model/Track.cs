using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Lastfm.NETCore.Builder;
using Lastfm.NETCore.Common;
using Lastfm.NETCore.Dto;
using Newtonsoft.Json;
using static Lastfm.NETCore.Helper.ActivatorHelper;
using static Lastfm.NETCore.Helper.RestClientHelper;

namespace Lastfm.NETCore.Model
{
    public class Track
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
        public Artist Artist { get; set; }

        [JsonProperty("image")]
        public IList<Image> Images { get; set; }

        #endregion

        #region [Methods]

        public override string ToString()
        {
            return Name;
        }

        #endregion

        #region [API Methods] 

        public static async Task<List<Track>> SearchAsync(string name, int count = 10)
        {
            ThrowIfApiKeyProviderIsNull();
            
            var url = new RequestUrlBuilder()
                .SetMethod("track.search")
                .SetApiKey(LastfmActivator.ApiKeysProvider.ApiKey)
                .SetFormat()
                .SetLimit(count)
                .SetExtraMethod($"track={name}")
                .Build();

            var tracks = await GetRequestAndMapAsync<List<SearchTrackDto>, List<Track>>(url, o => o["results"]["trackmatches"]["track"]).ConfigureAwait(false);
            return tracks;
        }

        public static async Task<List<Track>> SimilarAsync(string track, string artist, int count = 20)
        {
            ThrowIfApiKeyProviderIsNull();
            
            var url = new RequestUrlBuilder()
                .SetMethod("track.getsimilar")
                .SetApiKey(LastfmActivator.ApiKeysProvider.ApiKey)
                .SetFormat()
                .SetLimit(count)
                .SetExtraMethod($"artist={artist}")
                .SetExtraMethod($"track={track}")
                .Build();
            
            var tracks = await GetRequestAndMapAsync<List<TrackDto>, List<Track>>(url, o => o["similartracks"]["track"]).ConfigureAwait(false);
            return tracks;
        }

        #endregion
    }
}