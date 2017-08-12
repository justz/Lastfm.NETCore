using System;
using Lastfm.NETCore.Common.AutoMapper;
using Lastfm.NETCore.Contract;

namespace Lastfm.NETCore.Common
{
    public static class LastfmActivator
    {
        public static void Configure(Func<IApiKeysProvider, IApiKeysProvider> action)
        {
            AutoMapperConfig.Configure();
            ApiKeysProvider = action(ApiKeysProvider);
        }
        
        internal static IApiKeysProvider ApiKeysProvider { get; private set; }
    }
}