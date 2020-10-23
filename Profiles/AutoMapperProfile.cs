using AutoMapper;
using BandWebApi.Entity;
using BandWebApi.Helpers;
using BandWebApi.Models;

namespace BandWebApi.Profiles {
    public class AutoMapperProfile: Profile {
        public AutoMapperProfile()
        {
            CreateMap<Entity.Band, Models.BandDto>().ForMember(
                   dest => dest.FoundedYearAgo,
                   option => option.MapFrom(s => $"{s.Founded.ToString("yyyy/mm/dd")} ({s.Founded.GetYearsAgo()}) years ago "));
            CreateMap<BandForCreatingDto,Band>();
            
            CreateMap<Album, AlbumDto>();
            CreateMap<AlbumForCreatingDto, Album>(); 

        }
    }
}