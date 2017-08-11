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
                exp.CreateMap<Track, TrackDto>().ReverseMap();
                exp.CreateMap<Artist, ArtistDto>().ReverseMap();
                exp.CreateMap<Image, ImageDto>().ReverseMap();
                exp.CreateMap<Album, AlbumDto>().ReverseMap();
                exp.CreateMap<Tag, TagDto>().ReverseMap();
                exp.CreateMap<Token, TokenDto>().ReverseMap();

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