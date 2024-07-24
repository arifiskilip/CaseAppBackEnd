using Application.Repositories;
using Core.Persistence.Repositories;
using Persistence.Contexts;
using Task = Domain.Entities.Task;

namespace Persistence.Repositories
{
	public class TaskRepository : EfRepositoryBase<Task, int, CaseAppContext>, ITaskRepository
	{
		public TaskRepository(CaseAppContext context) : base(context)
		{
		}
	}
}
