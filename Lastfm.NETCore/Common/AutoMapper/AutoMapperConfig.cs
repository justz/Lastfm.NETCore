using AutoMapper;
using Lastfm.NETCore.Dto;
using Lastfm.NETCore.Model;

namespace Lastfm.NETCore.Common.AutoMapper
{
    internal static class AutoMapperConfig
    {
        internal static void Configure()
        {
            Mapper.Initialize(exp =>
            {
                exp.CreateMap<Track, SearchTrackDto>()
                    .ReverseMap()
                    .AfterMap((src, dest) =>
                    {
                        if (dest.Artist == null)
                            dest.Artist = new Artist();
                        dest.Artist.Name = src?.Artist;
                    });
            });
        }
    }
}