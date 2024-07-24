using Application.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
	public class CompletedTaskRepository : EfRepositoryBase<CompletedTask, int, CaseAppContext>, ICompletedTaskRepository
	{
		public CompletedTaskRepository(CaseAppContext context) : base(context)
		{
		}
	}
}
