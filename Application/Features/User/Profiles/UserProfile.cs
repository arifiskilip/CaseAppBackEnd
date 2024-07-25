using AutoMapper;

namespace Application.Features
{
	public class UserProfile : Profile
	{
        public UserProfile()
        {
            CreateMap<Domain.Entities.User, GetUserByAuthenticatedResponse>().ReverseMap();
        }
    }
}
