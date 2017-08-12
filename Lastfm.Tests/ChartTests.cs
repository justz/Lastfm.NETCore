using Lastfm.NETCore.Common;
using Lastfm.NETCore.Model;
using Xunit;

namespace Lastfm.Tests
{
    public class ChartTests
    {
        public ChartTests()
        {
            LastfmActivator.Activate();
        }
        
        [Fact]
        public async void GetTopArtists_Test()
        {
            var artists = await Chart.GetTopArtistsAsync();
        }
        
        [Fact]
        public async void GetTopTracks_Test()
        {
            var tracks = await Chart.GetTopTracksAsync();
        }
        
        [Fact]
        public async void GetTopTags_Test()
        {
            var tags = await Chart.GetTopTagsAsync();
        }
    }
}