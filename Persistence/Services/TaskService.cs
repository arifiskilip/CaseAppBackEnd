using Application.Features;
using Application.Repositories;
using Application.Services;
using Core.CrossCuttingConcers.Exceptions.Types;

namespace Persistence.Services
{
	public class TaskService : ITaskService
	{
		private readonly ITaskRepository _taskRepository;

		public TaskService(ITaskRepository taskRepository)
		{
			_taskRepository = taskRepository;
		}

		public async Task<Domain.Entities.Task> GetByIdAsync(int id)
		{
			var checkTask = await _taskRepository.GetAsync(predicate:x=> x.Id == id, enableTracking:true);
			if (checkTask is null)
			{
				throw new BusinessException(TaskMessages.TaskNotFount);
			}
			return checkTask;
		}

		public async Task<Domain.Entities.Task> UpdateAsync(Domain.Entities.Task task)
		{
			await _taskRepository.UpdateAsync(task);
			return task;
		}
	}
}
