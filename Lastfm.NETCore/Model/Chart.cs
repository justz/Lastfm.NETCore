using System.Collections.Generic;
using System.Threading.Tasks;
using Lastfm.NETCore.Builder;
using Lastfm.NETCore.Common;
using Lastfm.NETCore.Dto;
using static Lastfm.NETCore.Helper.ActivatorHelper;
using static Lastfm.NETCore.Helper.RestClientHelper;

namespace Lastfm.NETCore.Model
{
    public sealed class Chart
    {
        public static async Task<List<Artist>> GetTopArtistsAsync(int count = 50)
        {
            var url = new RequestUrlBuilder()
                .SetApiKey(LastfmActivator.ApiKeysProvider.ApiKey)
                .SetMethod("chart.gettopartists")
                .SetLimit(count)
                .SetFormat()
                .Build();

            var artists = await GetRequestAndMap<List<ArtistDto>, List<Artist>>(url, o => o["artists"]["artist"]);
            return artists;
        }

        public static async Task<List<Tag>> GetTopTagsAsync(int count = 10)
        {
            ThrowIfApiKeyProviderIsNull();
            
            var url = new RequestUrlBuilder()
                .SetApiKey(LastfmActivator.ApiKeysProvider.ApiKey)
                .SetMethod("chart.gettoptags")
                .SetLimit(count)
                .SetFormat()
                .Build();

            var tags = await GetRequestAndMap<List<TagDto>, List<Tag>>(url, o => o["tags"]["tag"]);
            return tags;
        }

        public static async Task<List<Track>> GetTopTracksAsync(int count = 50)
        {
            ThrowIfApiKeyProviderIsNull();
            
            var url = new RequestUrlBuilder()
                .SetApiKey(LastfmActivator.ApiKeysProvider.ApiKey)
                .SetMethod("chart.gettoptracks")
                .SetLimit(count)
                .SetFormat()
                .Build();

            var tracks = await GetRequestAndMap<List<TrackDto>, List<Track>>(url, o => o["tracks"]["track"]);
            return tracks;
        }
    }
}