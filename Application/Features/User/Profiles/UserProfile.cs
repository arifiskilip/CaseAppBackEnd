using Application.Features.User.Queries.GetUserByAuthenticated;
using AutoMapper;

namespace Application.Features.User.Profiles
{
	public class UserProfile : Profile
	{
        public UserProfile()
        {
            CreateMap<Domain.Entities.User, GetUserByAuthenticatedResponse>().ReverseMap();
        }
    }
}
