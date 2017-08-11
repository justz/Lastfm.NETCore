using Lastfm.NETCore.Model;
using Xunit;

namespace Lastfm.Tests
{
    public class ChartTests
    {
        [Fact]
        public async void GetTopArtists_Test()
        {
            var artists = await Chart.GetTopArtists();
        }
    }
}