using AuthAPI.Domain.Entities;

namespace AuthAPI.Domain.Services
{
	public interface IAuthService
	{
		string GenerateTokenString(Login user);
		Task<bool> Login(Login user);
		Task<bool> Register(Login user);
		Task Logout();
	}
}