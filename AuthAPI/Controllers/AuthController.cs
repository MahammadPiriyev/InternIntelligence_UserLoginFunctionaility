using AuthAPI.Domain.Entities;
using AuthAPI.Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AuthAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AuthController : ControllerBase
	{
		private readonly IAuthService _authService;
		public AuthController(IAuthService authService)
		{
			_authService = authService;
		}

		[HttpPost("register")]
		public async Task<IActionResult> Register(Login user)
		{
			if(await _authService.Register(user))
			{
				return Ok();
			}
			return BadRequest();
		}

		[HttpPost("login")]
		public async Task<IActionResult> Login(Login user)
		{
			if (await _authService.Login(user))
			{
				var tokenString = _authService.GenerateTokenString(user);
				return Ok(tokenString);
			}
			return BadRequest("Username or password is not correct!");
		}

		[HttpPost("logout")]
		public async Task<IActionResult> Logout()
		{
			await _authService.Logout();
			return Ok(new { message = "Logged out successfully" });
		}
	}
}
