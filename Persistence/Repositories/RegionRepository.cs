using Application.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
	public class RegionRepository : EfRepositoryBase<Region, int, CaseAppContext>, IRegionRepository
	{
		public RegionRepository(CaseAppContext context) : base(context)
		{
		}
	}
}
