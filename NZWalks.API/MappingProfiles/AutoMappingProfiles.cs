using AutoMapper;
using NZwalks.Core.Domain.Entities;
using NZWalks.API.Dtos;

namespace NZWalks.API.MappingProfiles
{
    public class AutoMappingProfiles : Profile
    {
        public AutoMappingProfiles()
        {
            CreateMap<Region, RegionResponse>().ReverseMap();
            CreateMap<Region, AddRegionDto>().ReverseMap();
            CreateMap<AddRegionDto, Region>().ReverseMap();
            CreateMap<Region, RegionDto>().ReverseMap();
            CreateMap<UpdateRegionDto, Region>().ReverseMap();
            CreateMap<AddWalksDto, Walk>().ReverseMap();
            CreateMap<Walk, WalkResponseDto>().ReverseMap();
            CreateMap<Difficulty, DifficultyDto>().ReverseMap();
            CreateMap<UpdateWalksDto, Walk>().ReverseMap();

        }
    }
}
