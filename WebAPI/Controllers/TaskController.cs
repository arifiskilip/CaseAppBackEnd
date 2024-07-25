using Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	public class TaskController : BaseController
	{
		[HttpGet]
		public async Task<IActionResult> GetAll([FromQuery] GetAllTaskQuery query)
		{
			var result = await _mediator.Send(query);
			return Ok(result);
		}
		[HttpGet]
		public async Task<IActionResult> GetAllFilteredPaginated([FromQuery] GetAllFilteredPaginatedTaskQuery query)
		{
			var result = await _mediator.Send(query);
			return Ok(result);
		}
	}
}
