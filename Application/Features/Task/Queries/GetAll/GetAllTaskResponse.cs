namespace Application.Features
{
	public class GetAllTaskResponse
	{
		public int Id { get; set; }
		public string TaskName { get; set; }
		public string CityRegionName { get; set; }
		public int Total { get; set; }
		public int? Performed { get; set; }
	}
}
