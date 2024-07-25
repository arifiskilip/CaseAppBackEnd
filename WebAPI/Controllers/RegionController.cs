using Application.Features;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	public class RegionController : BaseController
	{
		[HttpGet]
		public async Task<IActionResult> GetAll([FromQuery] GetAllRegionQuery query)
		{
			var result = await _mediator.Send(query);
			return Ok(result);
		}
	}
}
