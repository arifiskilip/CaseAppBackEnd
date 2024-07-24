using Application.Repositories;
using AutoMapper;
using MediatR;

namespace Application.Features
{
	public class GetAllRegionQuery : IRequest<List<GetAllRegionResponse>>
	{


		public class GetAllRegionQueryHandler : IRequestHandler<GetAllRegionQuery, List<GetAllRegionResponse>>
		{
			private readonly IRegionRepository _regionRepository;
			private readonly IMapper _mapper;

			public GetAllRegionQueryHandler(IRegionRepository regionRepository, IMapper mapper)
			{
				_regionRepository = regionRepository;
				_mapper = mapper;
			}

			async Task<List<GetAllRegionResponse>> IRequestHandler<GetAllRegionQuery, List<GetAllRegionResponse>>.Handle(GetAllRegionQuery request, CancellationToken cancellationToken)
			{
				var result = await _regionRepository.GetListNotPagedAsync(
					orderBy: x => x.OrderBy(o => o.Id),
					enableTracking: false);
				return _mapper.Map<List<GetAllRegionResponse>>(result);
			}
		}
	}
}
