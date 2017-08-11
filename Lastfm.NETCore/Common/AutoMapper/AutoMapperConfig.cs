using AutoMapper;
using Lastfm.NETCore.Model;

namespace Lastfm.NETCore.Common.AutoMapper
{
    internal static class AutoMapperConfig
    {
        internal static void Configure()
        {
            Mapper.Initialize(exp =>
            {
                exp.CreateMap<Track, SearchTrack>().AfterMap((dest, src) => dest.Artist.Name = src.Artist);
            });
        }
    }
}