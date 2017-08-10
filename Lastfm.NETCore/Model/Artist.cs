using System;
using System.Collections.Generic;
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
        public IList<Image> Image { get; set; }

        [JsonProperty("streamable")]
        public string Streamable { get; set; }
        
        [JsonProperty("listeners")]
        public string Listeners { get; set; }

        #endregion

        #region [API Methods]

        public static async Task<Artist> GetInfoAsync(string name)
        {
            using (var client = new HttpClient())
            {
                var url = new RequestUrlBuilder()
                    .SetMethod("artist.getInfo")
                    .SetExtraMethod($"artist={name}")
                    .SetAutoCorrect(true)
                    .SetApiKey(ApiKeyProvider.Instance.ApiKey)
                    .SetFormat()
                    .Build();

                string content = null;

                try
                {
                    var response = await client.GetAsync(url).ConfigureAwait(false);
                    content = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                    response.EnsureSuccessStatusCode();

                    var res = await RestClientHelper.ParseResponse<Artist>(JObject.Parse(content)["artist"].ToString())
                        .ConfigureAwait(false);
                    
                    await ThrowIfNull(res.Image, content);
                    
                    return res;
                }
                catch (Exception ex)
                {
                    throw RestClientHelper.GetException(ex, content);
                }
            }
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

        #endregion
    }
}