using Core.Domain;

namespace Domain.Entities
{
	public class City : Entity<int>
	{
		public string Name { get; set; }

		public int RegionId { get; set; }
		public virtual Region Region { get; set; }
		public virtual ICollection<Task> Tasks { get; set; }
	}
}
