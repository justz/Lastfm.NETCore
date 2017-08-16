using System;
using Lastfm.NETCore.Common.AutoMapper;
using Lastfm.NETCore.Contract;

namespace Lastfm.NETCore.Common
{
    public static class LastfmActivator
    {
        public static void Configure(Func<IApiKeysProvider> provider)
        {
            AutoMapperConfig.Configure();
            ApiKeysProvider = provider();
        }
        
        internal static IApiKeysProvider ApiKeysProvider { get; private set; }
    }
}