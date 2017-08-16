using Lastfm.NETCore.Common;
using Lastfm.NETCore.Model;
using Lastfm.NETCore.Provider;
using Xunit;

namespace Lastfm.Tests
{
    public class ArtistTests
    {
        [Fact]
        public async void GetInfo_Test()
        {
            LastfmActivator.Configure(() => ApiKeyProvider.Instance);
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
        
        [Fact]
        public async void GetSimilar_Test()
        {
            var res = await Artist.GetSimilarAsync("ramstain");
        }
        
        [Fact]
        public async void GetTopTracks_Test()
        {
            var res = await Artist.GetTopTracksAsync("ramstain");
        }
        
        [Fact]
        public async void GetTopAlbums_Test()
        {
            var res = await Artist.GetTopAlbumsAsync("ramstain");
        }
        
        [Fact]
        public async void GetTopTags_Test()
        {
            var res = await Artist.GetTopTagsAsync("ramstain");
        }
    }
}