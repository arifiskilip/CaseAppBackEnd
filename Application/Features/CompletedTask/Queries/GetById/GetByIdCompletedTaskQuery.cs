using Application.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features
{
	public class GetByIdCompletedTaskQuery : IRequest<IPaginate<GetByIdCompletedTaskResponse>>
	{
        public int Id { get; set; }

		public int PageIndex { get; set; } = 1;
		public int PageSize { get; set; } = 10;

        public class GetByIdCompletedTaskQueryHandler : IRequestHandler<GetByIdCompletedTaskQuery, IPaginate<GetByIdCompletedTaskResponse>>
		{
			private readonly ICompletedTaskRepository _completedTaskRepository;
			private readonly IMapper _mapper;
			public GetByIdCompletedTaskQueryHandler(ICompletedTaskRepository completedTaskRepository, IMapper mapper)
			{
				_completedTaskRepository = completedTaskRepository;
				_mapper = mapper;
			}

			public async Task<IPaginate<GetByIdCompletedTaskResponse>> Handle(GetByIdCompletedTaskQuery request, CancellationToken cancellationToken)
			{
				var result = await _completedTaskRepository.GetListAsync(
					predicate:x=> x.TaskId == request.Id,
					orderBy:x=> x.OrderBy(x=>x.Id),
					include:x=> x.Include(i=>i.User).Include(i=>i.Task).ThenInclude(i=> i.TaskType).ThenInclude(i=> i.UnitType).Include(i=> i.Task).ThenInclude(i=>i.City).ThenInclude(i=>i.Region),
					index:request.PageIndex,
					size:request.PageSize,
					enableTracking:false);

				List<GetByIdCompletedTaskResponse> tasks = _mapper.Map<List<GetByIdCompletedTaskResponse>>(result.Items);

				return new Paginate<GetByIdCompletedTaskResponse>(tasks.AsQueryable(), result.Pagination);
			}
		}

	}
}
