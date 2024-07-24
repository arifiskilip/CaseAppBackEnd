using AutoMapper;
using Domain.Entities;

namespace Application.Features
{
	public class CompletedTaskProfile : Profile
	{
        public CompletedTaskProfile()
        {
            CreateMap<AddCompletedTaskCommand, CompletedTask>().ReverseMap();
        }
    }
}
