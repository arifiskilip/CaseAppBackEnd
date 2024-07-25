using Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	public class CityController:BaseController
	{
		[HttpGet]
		public async Task<IActionResult> GetAllByRegionId([FromQuery] GetAllByRegionIdCityQuery query)
		{
			var result = await _mediator.Send(query);
			return Ok(result);
		}
	}
}
