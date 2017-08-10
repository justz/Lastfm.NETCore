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
        
        [Fact]
        public async void Search_Test()
        {
            var res = await Artist.SearchAsync("rammstein");
        }
        
        [Fact]
        public async void GetCorrection_Test()
        {
            var res = await Artist.GetCorrectionAsync("ramstain");
        }
    }
}