using Application.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;

namespace Persistence.Repositories
{
	public class TaskTypeRepository : EfRepositoryBase<TaskType, int, CaseAppContext>, ITaskTypeRepository
	{
		public TaskTypeRepository(CaseAppContext context) : base(context)
		{
		}
	}
}
