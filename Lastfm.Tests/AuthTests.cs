using Lastfm.NETCore.Common;
using Lastfm.NETCore.Model;
using Xunit;

namespace Lastfm.Tests
{
    public class AuthTests
    {
        [Fact]
        public async void GetToken_Test()
        {
            var res = await Auth.GetTokenAsync("73dcb69ae592d67147da5ade22d37a24");
        }
    }
}