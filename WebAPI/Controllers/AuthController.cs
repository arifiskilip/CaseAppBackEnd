using Application.Features.Auth.Commands.Login;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	public class AuthController : BaseController
	{
		[HttpPost]
		public async Task<IActionResult> Login([FromBody] LoginCommand command)
		{
			var result = await _mediator.Send(command);
			return Ok(result);
		}
	}
}
