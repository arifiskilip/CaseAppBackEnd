using Application.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
	public class CityRepository : EfRepositoryBase<City, int, CaseAppContext>, ICityRepository
	{
		public CityRepository(CaseAppContext context) : base(context)
		{
		}
	}
}
