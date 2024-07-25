using Core.Domain;

namespace Application.Features
{
	public class GetAllFilteredPaginatedTaskResponse : IEntity
	{
        public int Id { get; set; }
        public string TaskName { get; set; }
        public string CityRegionName { get; set; }
        public int Total { get; set; }
        public string UnitTypeName { get; set; }
        public int? Performed { get; set; }
    }
}
