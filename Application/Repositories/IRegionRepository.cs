using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Repositories
{
	public interface IRegionRepository : IAsyncRepository<Region, int>, IRepository<Region, int>
	{
	}
}
