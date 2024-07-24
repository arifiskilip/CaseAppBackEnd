namespace Application.Services
{
	public interface ITaskService
	{
		Task<Domain.Entities.Task> GetByIdAsync(int id);
		Task<Domain.Entities.Task> UpdateAsync(Domain.Entities.Task task);
	}
}
