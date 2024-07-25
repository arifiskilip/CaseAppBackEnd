using Application.Features;
using Microsoft.AspNetCore.Mvc;

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

		[HttpPost]
		public async Task<IActionResult> Add([FromBody] AddCompletedTaskCommand command)
		{
			var result = await _mediator.Send(command);
			return Ok(result);
		}
		[HttpGet]
		public async Task<IActionResult> GetBYCompleted([FromQuery] GetByIdCompletedTaskQuery query)
		{
			var result = await _mediator.Send(query);
			return Ok(result);
		}
	}
}
