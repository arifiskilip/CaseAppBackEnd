using Core.Domain;

namespace Domain.Entities
{
	public class CompletedTask : Entity<int>
	{
		public int TaskId { get; set; }
		public int UserId { get; set; }
		public int Quantity { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }

		public virtual Task Task { get; set; }
		public virtual User User { get; set; }
	}
}
