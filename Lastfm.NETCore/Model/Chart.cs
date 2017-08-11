using System.Collections.Generic;
using System.Threading.Tasks;
using Lastfm.NETCore.Builder;
using Lastfm.NETCore.Common;
using Lastfm.NETCore.Helper;

namespace Lastfm.NETCore.Model
{
    public class Chart
    {
        public static async Task<List<Artist>> GetTopArtists()
        {
            var url = new RequestUrlBuilder()
                .SetApiKey(ApiKeyProvider.Instance.ApiKey)
                .SetMethod("chart.gettopartists")
                .SetFormat()
                .Build();

            var artists = await RestClientHelper.GetRequest<List<Artist>>(url, o => o["artists"]["artist"]);
            return artists;
        }
    }
}