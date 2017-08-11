using Lastfm.NETCore.Model;
using Xunit;

namespace Lastfm.Tests
{
    public class TrackTests
    {
        [Fact]
        public async void Search_Test()
        {
            var artists = await Track.Search("around");
        }
        
        [Fact]
        public async void Similar_Test()
        {
            var artists = await Track.Similar("Rammstein", "Du hast");
        }
    }
}