using Core.Persistence.Repositories;
using Domain.Entities;

namespace Application.Repositories
{
	public interface ITaskTypeRepository : IAsyncRepository<TaskType, int>, IRepository<TaskType, int>
	{
	}
}
