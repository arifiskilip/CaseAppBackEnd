using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Repositories
{
	public interface ICityRepository : IAsyncRepository<City, int>, IRepository<City, int>
	{
	}
}
