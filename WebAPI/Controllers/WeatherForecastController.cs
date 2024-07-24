using Application.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Contexts;

namespace WebAPI.Controllers
{
	public class WeatherForecastController : BaseController
	{
		[HttpGet]
		public async Task<IActionResult> Get([FromQuery] GetAllFilteredPaginatedTaskQuery query)
		{
			var result = await _mediator.Send(query);
			return Ok(result);
		}
	}
}
