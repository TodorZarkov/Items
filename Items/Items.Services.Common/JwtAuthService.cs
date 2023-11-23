namespace Items.Services.Common
{
	using Items.Services.Common.Interfaces;
	using Microsoft.Extensions.Configuration;

	using Microsoft.IdentityModel.Tokens;
	using System.IdentityModel.Tokens.Jwt;
	using System.Security.Claims;
	using System.Text;

	public class JwtAuthService : ITokenAuthService
	{
		private readonly IConfiguration config;
		private readonly IDateTimeProvider dateTimeProvider;

		public JwtAuthService(IConfiguration config, IDateTimeProvider dateTimeProvider)
		{
			this.config = config;
			this.dateTimeProvider = dateTimeProvider;
		}

		public string BuildToken(Claim[] claims)
		{
			SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
			SigningCredentials creds = new SigningCredentials(key, config["Jwt:SecurityAlg"]);

			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				Audience = config["Jwt:Audience"],
				Issuer = config["Jwt:Issuer"],
				Expires = dateTimeProvider.GetCurrentDateTime().AddMinutes(double.Parse(config["Jwt:ExpirationMinutes"])),
				SigningCredentials = creds,
				NotBefore = dateTimeProvider.GetCurrentDateTime()
			};

			var tokenHandler = new JwtSecurityTokenHandler();
			var token = tokenHandler.CreateToken(tokenDescriptor);

			return tokenHandler.WriteToken(token);
		}


		public string BuildRefreshToken()
		{
			throw new NotImplementedException();
		}


		public ClaimsPrincipal GetPrincipalFromToken(string token)
		{
			throw new NotImplementedException();
		}
	}
}
