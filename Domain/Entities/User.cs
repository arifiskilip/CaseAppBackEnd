using Core.Security.Entitites;

namespace Domain.Entities
{
	public class User : BaseUser
	{
		public virtual ICollection<CompletedTask> CompletedTasks { get; set; }
	}
}
