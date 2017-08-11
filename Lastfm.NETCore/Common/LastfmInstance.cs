using Lastfm.NETCore.Common.AutoMapper;

namespace Lastfm.NETCore.Common
{
    public static class LastfmInstance
    {
        public static void Configure()
        {
            AutoMapperConfig.Configure();
        }
    }
}