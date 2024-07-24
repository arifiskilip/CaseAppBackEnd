using Core.Domain;

namespace Domain.Entities
{
	public class UnitType : Entity<int>
	{
		public string Name { get; set; }

		public virtual ICollection<TaskType> TaskTypes { get; set; }
	}
}
