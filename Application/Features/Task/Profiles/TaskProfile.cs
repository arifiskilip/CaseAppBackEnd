using AutoMapper;
using Task = Domain.Entities.Task;

namespace Application.Features
{
	public class TaskProfile : Profile
	{
        public TaskProfile()
        {
            CreateMap<GetAllTaskResponse, Task>().ReverseMap();
            CreateMap<Task, GetAllFilteredPaginatedTaskResponse>()
                .ForMember(opt => opt.TaskName, x => x.MapFrom(m => m.TaskType.Name))
                .ForMember(opt => opt.UnitTypeName, x => x.MapFrom(m => m.TaskType.UnitType.Name))
                .ForMember(opt => opt.CityRegionName, x => x.MapFrom(m => m.City.Name + " - " + m.City.Region.Name));
			CreateMap<Task, GetAllTaskResponse>()
				.ForMember(opt => opt.TaskName, x => x.MapFrom(m => m.TaskType.Name))
				.ForMember(opt => opt.CityRegionName, x => x.MapFrom(m => m.City.Name + " - " + m.City.Region.Name));

		}
    }
}
