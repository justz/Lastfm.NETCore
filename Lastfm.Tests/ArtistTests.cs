using Lastfm.NETCore.Model;
using Xunit;

namespace Lastfm.Tests
{
    public class ArtistTests
    {
        [Fact]
        public async void GetInfo_Test()
        {
            var res = await Artist.GetInfoAsync("rammstein");
        }
    }
}