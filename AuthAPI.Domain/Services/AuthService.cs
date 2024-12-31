using AuthAPI.Domain.Entities;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthAPI.Domain.Services
{
	public class AuthService : IAuthService
	{
		private readonly SignInManager<IdentityUser> _signInManager;
		private readonly UserManager<IdentityUser> _userManager;
		private readonly IConfiguration _config;


		public AuthService(UserManager<IdentityUser> userManager, IConfiguration config, SignInManager<IdentityUser> signInManager)
		{
			_userManager = userManager;
			_config = config;
			_signInManager = signInManager;
		}
		public async Task<bool> Register(Login user)
		{
			var identityUser = new IdentityUser
			{
				UserName = user.Username,
				Email = user.Username,
				EmailConfirmed = true
			};
			var result = await _userManager.CreateAsync(identityUser, user.Password);
			return result.Succeeded;
		}

		public async Task<bool> Login(Login user)
		{
			var identityUser = await _userManager.FindByEmailAsync(user.Username);
			if (identityUser == null)
			{
				return false;
			}
			return await _userManager.CheckPasswordAsync(identityUser, user.Password);
		}
		public async Task Logout()
		{
			await _signInManager.SignOutAsync();
		}
		public string GenerateTokenString(Login user)
		{
			IEnumerable<Claim> claims = new List<Claim>
			{
				new Claim(ClaimTypes.Email, user.Username),
				new Claim(ClaimTypes.Role, "Admin"),
			};

			SymmetricSecurityKey securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("Jwt:Key").Value!));
			SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha512);

			JwtSecurityToken securityToken = new JwtSecurityToken(
				claims:claims,
				expires:DateTime.Now.AddMinutes(60),
				issuer: _config.GetSection("Jwt:Issuer").Value, 
				audience: _config.GetSection("Jwt:Audience").Value,
				signingCredentials:signingCredentials);

			string tokenString = new JwtSecurityTokenHandler().WriteToken(securityToken);
			return tokenString;
		}
	}
}
