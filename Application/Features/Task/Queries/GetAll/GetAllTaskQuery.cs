using Application.Repositories;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features
{
	public class GetAllTaskQuery : IRequest<List<GetAllTaskResponse>>
	{


		public class GetAllTaskQueryHandler : IRequestHandler<GetAllTaskQuery, List<GetAllTaskResponse>>
		{
			private readonly ITaskRepository _taskRepository;
			private readonly IMapper _mapper;

			public GetAllTaskQueryHandler(ITaskRepository taskRepository, IMapper mapper)
			{
				_taskRepository = taskRepository;
				_mapper = mapper;
			}

			public async Task<List<GetAllTaskResponse>> Handle(GetAllTaskQuery request, CancellationToken cancellationToken)
			{
				var result = await _taskRepository.GetListNotPagedAsync(
					include: x => x.Include(i => i.TaskType).Include(i => i.City).ThenInclude(i => i.Region),
					orderBy: x => x.OrderBy(o => o.Id),
					enableTracking: false);
				return _mapper.Map<List<GetAllTaskResponse>>(result);
			}
		}
	}
}
