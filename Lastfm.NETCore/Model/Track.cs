﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lastfm.NETCore.Builder;
using Lastfm.NETCore.Common;
using Newtonsoft.Json;
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

        public static async Task<List<Track>> Search(string name, int count = 10)
        {
            var url = new RequestUrlBuilder()
                .SetMethod("track.search")
                .SetApiKey(ApiKeyProvider.Instance.ApiKey)
                .SetFormat()
                .SetLimit(count)
                .SetExtraMethod($"track={name}")
                .Build();

            var res = await GetRequest<List<SearchTrack>>(url, o => o["results"]["trackmatches"]["track"]);
            var tracks = res.Select(a => a.ExtractArtist()).ToList();
            return tracks;
        }

        public static async Task<List<Track>> Similar(string track, string artist, int count = 20)
        {
            var url = new RequestUrlBuilder()
                .SetMethod("track.getsimilar")
                .SetApiKey(ApiKeyProvider.Instance.ApiKey)
                .SetFormat()
                .SetLimit(count)
                .SetExtraMethod($"artist={artist}")
                .SetExtraMethod($"track={track}")
                .Build();
            
            var tracks = await GetRequest<List<Track>>(url, o => o["similartracks"]["track"]);
            return tracks;
        }

        #endregion
    }
    
    /// <summary>
    /// Костыль для костыльного Lastfm.
    /// В запросе track.search отличается поле artist
    /// обычно оно типа Artist, но в данном запросе типа string.
    /// И чтобы не городить Dto или конвертеры я создал этот костыль.
    /// </summary>
    internal class SearchTrack : Track
    {
        #region [Properties]

        [JsonProperty("artist")]
        internal new string Artist { get; set; }

        #endregion

        #region [Methods]

        internal Track ExtractArtist()
        {
            base.Artist = new Artist {Name = Artist};
            return this;
        }

        #endregion
    }
}