using Application.Features.Auth.Commands.Login;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Auth.Profiles
{
	public class AuthProfile : Profile
	{
        public AuthProfile()
        {
			CreateMap<User, LoginResponse>().ReverseMap();
		}
    }
}
