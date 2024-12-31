using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	[Authorize]
	public class TestController : ControllerBase
	{
		[HttpGet]
		public async Task<IActionResult> GetDataAsync()
		{
			if (ModelState.IsValid)
			{
				return Ok("Authorized");
			}
			return Unauthorized();
		}
	}
}
