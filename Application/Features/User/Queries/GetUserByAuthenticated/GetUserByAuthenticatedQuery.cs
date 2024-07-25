using Application.Repositories;
using Application.Services;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using MediatR;

namespace Application.Features.User.Queries.GetUserByAuthenticated
{
	public class GetUserByAuthenticatedQuery : IRequest<GetUserByAuthenticatedResponse>, ISecuredRequest
	{
		public string[] Roles => ["Person"];


		public class GetUserByAuthenticatedQueryHandler : IRequestHandler<GetUserByAuthenticatedQuery, GetUserByAuthenticatedResponse>
		{
			private readonly IAuthService _authService;
			private readonly IUserRepository _userRepository;
			private readonly IMapper _mapper;

			public GetUserByAuthenticatedQueryHandler(IAuthService authService, IUserRepository userRepository, IMapper mapper)
			{
				_authService = authService;
				_userRepository = userRepository;
				_mapper = mapper;
			}

			public async Task<GetUserByAuthenticatedResponse> Handle(GetUserByAuthenticatedQuery request, CancellationToken cancellationToken)
			{
				var userId = await _authService.GetAuthenticatedUserIdAsync();
				var user = await _userRepository.GetAsync(
					predicate: x => x.Id == userId,
					enableTracking: false);
				return _mapper.Map<GetUserByAuthenticatedResponse>(user);
			}
		}
	}
}
