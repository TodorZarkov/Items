namespace Items.Services.Common.Interfaces
{
	using System.Security.Claims;

	public interface ITokenAuthService
	{
		public string BuildToken(Claim[] claims);

		public string BuildRefreshToken();

		public ClaimsPrincipal GetPrincipalFromToken(string token);
	}
}
