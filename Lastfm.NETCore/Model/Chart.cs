using System.Collections.Generic;
using System.Threading.Tasks;
using Lastfm.NETCore.Builder;
using Lastfm.NETCore.Common;
using static Lastfm.NETCore.Helper.RestClientHelper;

namespace Lastfm.NETCore.Model
{
    public sealed class Chart
    {
        public static async Task<List<Artist>> GetTopArtists(int count = 50)
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
        
        public static async Task<List<Track>> GetTopTracks(int count = 50)
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