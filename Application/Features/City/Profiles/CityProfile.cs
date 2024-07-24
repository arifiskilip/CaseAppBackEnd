using AutoMapper;
using Domain.Entities;

namespace Application.Features
{
	public class CityProfile : Profile
	{
        public CityProfile()
        {
            CreateMap<GetAllByRegionIdCityResponse, City>().ReverseMap();
        }
    }
}
