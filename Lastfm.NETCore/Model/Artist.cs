using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Lastfm.NETCore.Builder;
using Lastfm.NETCore.Common;
using Lastfm.NETCore.Helper;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Lastfm.NETCore.Model
{
    public class Artist
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
        public IList<Image> Images { get; set; }

        [JsonProperty("streamable")]
        public string Streamable { get; set; }

        [JsonProperty("listeners")]
        public string Listeners { get; set; }

        #endregion

        #region [API Methods]

        public static async Task<Artist> GetInfoAsync(string name)
        {
            var url = new RequestUrlBuilder()
                .SetMethod("artist.getInfo")
                .SetExtraMethod($"artist={name}")
                .SetAutoCorrect(true)
                .SetApiKey(ApiKeyProvider.Instance.ApiKey)
                .SetFormat()
                .Build();

            var artist = await GetRequest<Artist>(url, o => o["artist"]);
            return artist;
        }

        public static async Task<List<Artist>> SearchAsync(string name, int count = 10)
        {
            var url = new RequestUrlBuilder()
                .SetMethod("artist.search")
                .SetExtraMethod($"artist={name}")
                .SetLimit(count)
                .SetAutoCorrect(true)
                .SetApiKey(ApiKeyProvider.Instance.ApiKey)
                .SetFormat()
                .Build();

            var artists = await GetRequest<List<Artist>>(url, o => o["results"]["artistmatches"]["artist"]);
            return artists;
        }
        
        public static async Task<Artist> GetCorrectionAsync(string name)
        {
            var url = new RequestUrlBuilder()
                .SetMethod("artist.getCorrection")
                .SetExtraMethod($"artist={name}")
                .SetApiKey(ApiKeyProvider.Instance.ApiKey)
                .SetFormat()
                .Build();

            var artist = await GetRequest<Artist>(url, o => o["corrections"]["correction"]["artist"]);
            return artist;
        }
        
        public static async Task<List<Artist>> GetSimilarAsync(string name, int count = 10)
        {
            var url = new RequestUrlBuilder()
                .SetMethod("artist.getSimilar")
                .SetExtraMethod($"artist={name}")
                .SetAutoCorrect(true)
                .SetLimit(count)
                .SetApiKey(ApiKeyProvider.Instance.ApiKey)
                .SetFormat()
                .Build();

            var artists = await GetRequest<List<Artist>>(url, o => o["similarartists"]["artist"]);
            return artists;
        }
        
        public static async Task<IEnumerable<Track>> GetTopTracksAsync(string name, int count = 20)
        {
            var url = new RequestUrlBuilder()
                .SetMethod("artist.getTopTracks")
                .SetExtraMethod($"artist={name}")
                .SetLimit(count)
                .SetAutoCorrect(true)
                .SetApiKey(ApiKeyProvider.Instance.ApiKey)
                .SetFormat()
                .Build();

            var tracks = await GetRequest<List<Track>>(url, o => o["toptracks"]["track"]);
            return tracks;
        }
        
        public static async Task<List<Album>> GetTopAlbumsAsync(string name, int count = 10)
        {
            var url = new RequestUrlBuilder()
                .SetMethod("artist.getTopAlbums")
                .SetExtraMethod($"artist={name}")
                .SetAutoCorrect(true)
                .SetLimit(count)
                .SetApiKey(ApiKeyProvider.Instance.ApiKey)
                .SetFormat()
                .Build();

            var albums = await GetRequest<List<Album>>(url, o => o["topalbums"]["album"]);
            return albums;
        }

        public static async Task<List<Tag>> GetTopTagsAsync(string name, int count = 5)
        {
            var url = new RequestUrlBuilder()
                .SetMethod("artist.getTopTags")
                .SetExtraMethod($"artist={name}")
                .SetAutoCorrect(true)
                .SetApiKey(ApiKeyProvider.Instance.ApiKey)
                .SetFormat()
                .Build();

            var tags = await GetRequest<List<Tag>>(url, o => o["toptags"]["tag"]);
            return tags.Take(count).ToList();
        }

        #endregion

        #region [Helpers]

        private static async Task ThrowIfNull(object obj, string content)
        {
            if (obj == null)
            {
                var error = await RestClientHelper.ParseResponse<ErrorResponse>(content);
                throw new RestClientException(error.Message);
            }
        }

        private static async Task<T> GetRequest<T>(string url, Func<JObject, JToken> keyParamsFunc)
        {
            using (var client = new HttpClient())
            {
                string content = null;
                
                try
                {
                    var response = await client.GetAsync(url).ConfigureAwait(false);
                    content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    response.EnsureSuccessStatusCode();

                    var tracks = await RestClientHelper
                        .ParseResponse<T>(keyParamsFunc(JObject.Parse(content))
                        .ToString())
                        .ConfigureAwait(false);

                    await ThrowIfNull(tracks, content);
                    
                    return tracks;
                }
                catch (Exception ex)
                {
                    throw RestClientHelper.GetException(ex, content);
                }
            }
        }

        #endregion
    }
}