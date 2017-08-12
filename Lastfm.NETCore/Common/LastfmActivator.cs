using Lastfm.NETCore.Common.AutoMapper;

namespace Lastfm.NETCore.Common
{
    public static class LastfmActivator
    {
        public static void Activate()
        {
            AutoMapperConfig.Configure();
        }
    }
}