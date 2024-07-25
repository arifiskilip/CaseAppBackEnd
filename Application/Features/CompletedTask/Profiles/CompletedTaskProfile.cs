using AutoMapper;
using Domain.Entities;

namespace Application.Features
{
	public class CompletedTaskProfile : Profile
	{
        public CompletedTaskProfile()
        {
            CreateMap<AddCompletedTaskCommand, CompletedTask>().ReverseMap();

			CreateMap<CompletedTask, GetByIdCompletedTaskResponse>()
				.ForMember(opt => opt.UserName, x => x.MapFrom(i => i.User.FirstName + " " + i.User.LastName))
				.ForMember(opt => opt.UnitTypeName, x => x.MapFrom(i => i.Task.TaskType.UnitType.Name))
				.ForMember(opt => opt.CityRegionName, x => x.MapFrom(i => i.Task.City.Name + " - " + i.Task.City.Region.Name))
				.ForMember(opt => opt.CompletedQuantity, x => x.MapFrom(i => i.Quantity))
				.ForMember(opt => opt.WorkingHours, x => x.MapFrom(i => (i.EndDate - i.StartDate)));

		}
    }
}
