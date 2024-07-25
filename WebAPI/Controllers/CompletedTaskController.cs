using Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	public class CompletedTaskController : BaseController
	{
		[HttpGet]
		public async Task<IActionResult> GetById([FromQuery] GetByIdCompletedTaskQuery query)
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
	}
}
