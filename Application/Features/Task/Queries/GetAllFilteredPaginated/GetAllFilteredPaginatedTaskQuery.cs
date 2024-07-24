﻿using Application.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features
{
	public class GetAllFilteredPaginatedTaskQuery : IRequest<IPaginate<GetAllFilteredPaginatedTaskResponse>>
	{
        public int CityId { get; set; }
        public int TaskTypeId { get; set; }

		public int PageIndex { get; set; } = 1;
		public int PageSize { get; set; } = 10;



		public class GetAllFilteredPaginatedTaskQueryHandler : IRequestHandler<GetAllFilteredPaginatedTaskQuery, IPaginate<GetAllFilteredPaginatedTaskResponse>>
		{
			private readonly ITaskRepository _taskRepository;
			private readonly IMapper _mapper;

			public GetAllFilteredPaginatedTaskQueryHandler(ITaskRepository taskRepository, IMapper mapper)
			{
				_taskRepository = taskRepository;
				_mapper = mapper;
			}

			public async Task<IPaginate<GetAllFilteredPaginatedTaskResponse>> Handle(GetAllFilteredPaginatedTaskQuery request, CancellationToken cancellationToken)
			{
				var result = await _taskRepository.GetListAsync(
					predicate: x => x.CityId == request.CityId || x.TaskTypeId == request.TaskTypeId,
					include: x => x.Include(i => i.TaskType).Include(i => i.City).ThenInclude(i => i.Region),
					enableTracking: false,
					orderBy: x => x.OrderBy(o => o.Id),
					index: request.PageIndex,
					size: request.PageSize);

				List<GetAllFilteredPaginatedTaskResponse> tasks = _mapper.Map<List<GetAllFilteredPaginatedTaskResponse>>(result.Items);

				return new Paginate<GetAllFilteredPaginatedTaskResponse>(tasks.AsQueryable(), result.Pagination);
			}
		}
	}
}