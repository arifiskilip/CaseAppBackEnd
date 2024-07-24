using Core.Domain;

namespace Domain.Entities
{
	public class TaskType : Entity<int>
	{
		public string Name { get; set; }
		public int UnitTypeId { get; set; }

		public virtual UnitType UnitType { get; set; }
		public virtual ICollection<Task> Tasks { get; set; }
	}
}
