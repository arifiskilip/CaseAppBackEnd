using Application.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features
{
	public class GetAllByRegionIdCityQuery : IRequest<List<GetAllByRegionIdCityResponse>>, ISecuredRequest
	{
        public int RegionId { get; set; }

		public string[] Roles => ["Person"];

		public class GetAllByRegionIdCityQueryHandler : IRequestHandler<GetAllByRegionIdCityQuery, List<GetAllByRegionIdCityResponse>>
		{
			private readonly ICityRepository _cityRepository;
			private readonly IMapper _mapper;

			public GetAllByRegionIdCityQueryHandler(ICityRepository cityRepository, IMapper mapper)
			{
				_cityRepository = cityRepository;
				_mapper = mapper;
			}

			public async Task<List<GetAllByRegionIdCityResponse>> Handle(GetAllByRegionIdCityQuery request, CancellationToken cancellationToken)
			{
				var result = await _cityRepository.GetListNotPagedAsync(
					predicate: x => x.RegionId == request.RegionId,
					orderBy: x => x.OrderBy(o => o.Id),
					enableTracking: false);

				return _mapper.Map<List<GetAllByRegionIdCityResponse>>(result);
			}
		}

	}
}
