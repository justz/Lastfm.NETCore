using System;
using Lastfm.NETCore.Builder;
using Lastfm.NETCore.Common;
using Xunit;

namespace Lastfm.Tests
{
    public class RequestUrlBuilderTest
    {
        [Fact]
        public void Build_Test()
        {
            var url = new RequestUrlBuilder()
                .SetApiKey("26cc2ebf6da38bc646733f661bfc6268")
                .SetFormat()
                .SetLimit(10)
                .SetAutoCorrect(true)
                .SetMethod("artist.search")
                .SetExtraMethod("artist=rammstein")
                .Build();
            
            Assert.Equal("http://ws.audioscrobbler.com/2.0/?" +
                         "&api_key=26cc2ebf6da38bc646733f661bfc6268" +
                         "&format=json" +
                         "&limit=10" +
                         "&autocorrect=1" +
                         "&method=artist.search" +
                         "&artist=rammstein", url);
        }
    }
}