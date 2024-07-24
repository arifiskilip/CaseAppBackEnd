using Core.Domain;

namespace Domain.Entities
{
	public class Task : Entity<int>
	{
		public int TaskTypeId { get; set; }
		public virtual TaskType TaskType { get; set; }
		public int CityId { get; set; }
		public virtual City City { get; set; }
		public int Total { get; set; }
		public int Performed { get; set; } = 0;

        public virtual ICollection<CompletedTask> CompletedTasks { get; set; }
	}
}
