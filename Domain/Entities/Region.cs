using Core.Domain;

namespace Domain.Entities
{
	public class Region : Entity<int>
	{
		public string Name { get; set; }

		public virtual ICollection<City> Cities { get; set; }
	}
}
