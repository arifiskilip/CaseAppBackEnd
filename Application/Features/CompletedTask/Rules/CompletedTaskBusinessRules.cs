using Core.Application.Rules;
using Core.CrossCuttingConcers.Exceptions.Types;

namespace Application.Features
{
	public class CompletedTaskBusinessRules : BaseBusinessRules
	{
		public async Task CheckTargetNumberAsync(Domain.Entities.Task task, int quantity)
		{
			await Task.Run(() =>
			{
				if ((task.Performed + quantity) > task.Total)
				{
					throw new BusinessException(TaskMessages.TargetNumberExceeded);
				}
			});
		}
	}
}
