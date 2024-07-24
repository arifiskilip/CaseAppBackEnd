using AutoMapper;
using Domain.Entities;

namespace Application.Features
{
	public class RegionProfile : Profile
	{
        public RegionProfile()
        {
            CreateMap<GetAllRegionResponse, Region>().ReverseMap();
        }
    }
}
