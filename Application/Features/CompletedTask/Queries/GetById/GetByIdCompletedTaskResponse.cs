using Core.Domain;

namespace Application.Features
{ 
	public class GetByIdCompletedTaskResponse : IEntity
	{
        public int Id { get; set; }
        public string UserName { get; set; }
        public string CityRegionName { get; set; }
        public int CompletedQuantity { get; set; }
        public string UnitTypeName { get; set; }
        public TimeSpan WorkingHours { get; set; }
    }
}
