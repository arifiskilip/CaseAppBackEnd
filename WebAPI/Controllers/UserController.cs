using Application.Features.User.Queries.GetUserByAuthenticated;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	public class UserController : BaseController
	{
		[HttpGet]
		public async Task<IActionResult> GetUserByAuthenticated([FromQuery] GetUserByAuthenticatedQuery query)
		{
			var result = await _mediator.Send(query);
			return Ok(result);
		}
	}
}
