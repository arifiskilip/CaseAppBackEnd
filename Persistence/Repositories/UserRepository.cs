using Application.Repositories;
using Core.Persistence.Repositories;
using Core.Security.Entitites;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace Persistence.Repositories
{
	public class UserRepository : EfRepositoryBase<User, int, CaseAppContext>,
	   IUserRepository
	{
		public UserRepository(CaseAppContext context) : base(context)
		{
		}

		public async Task<IList<Core.Security.Entitites.OperationClaim>> GetClaimsAsync(User user)
		{
			var result = from oc in Context.Set<OperationClaim>()
						 join uoc in Context.Set<UserOperationClaim>()
							 on oc.Id equals uoc.OperationClaimId
						 where uoc.UserId == user.Id
						 select new Core.Security.Entitites.OperationClaim { Id = oc.Id, Name = oc.Name };
			return await result.ToListAsync();
		}
	}
}
