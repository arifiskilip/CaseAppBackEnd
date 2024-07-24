using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Repositories
{
	public interface ICompletedTaskRepository : IAsyncRepository<CompletedTask, int>, IRepository<CompletedTask, int>
	{
	}
}
