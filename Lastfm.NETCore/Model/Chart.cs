using System.Collections.Generic;
using System.Threading.Tasks;
using Lastfm.NETCore.Builder;
using Lastfm.NETCore.Common;
using static Lastfm.NETCore.Helper.RestClientHelper;

namespace Lastfm.NETCore.Model
{
    public sealed class Chart
    {
        public static async Task<List<Artist>> GetTopArtistsAsync(int count = 50)
        {
            var url = new RequestUrlBuilder()
                .SetApiKey(ApiKeyProvider.Instance.ApiKey)
                .SetMethod("chart.gettopartists")
                .SetLimit(count)
                .SetFormat()
                .Build();

            var artists = await GetRequest<List<Artist>>(url, o => o["artists"]["artist"]);
            return artists;
        }
        
        public static async Task<List<Tag>> GetTopTagsAsync(int count = 10)
        {
            var url = new RequestUrlBuilder()
                .SetApiKey(ApiKeyProvider.Instance.ApiKey)
                .SetMethod("chart.gettoptags")
                .SetLimit(count)
                .SetFormat()
                .Build();

            var tags = await GetRequest<List<Tag>>(url, o => o["tags"]["tag"]);
            return tags;
        }
        
        public static async Task<List<Track>> GetTopTracksAsync(int count = 50)
        {
            var url = new RequestUrlBuilder()
                .SetApiKey(ApiKeyProvider.Instance.ApiKey)
                .SetMethod("chart.gettoptracks")
                .SetLimit(count)
                .SetFormat()
                .Build();

            var tracks = await GetRequest<List<Track>>(url, o => o["tracks"]["track"]);
            return tracks;
        }
    }
}