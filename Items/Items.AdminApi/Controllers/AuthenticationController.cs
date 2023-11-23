namespace Items.AdminApi.Controllers
{
	using Items.Data.Models;
	using Items.Services.Data.Interfaces;
	using Items.Services.Data.Models.User;
	using Services.Common.Interfaces;

	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Options;
	using Items.Services.Common;
	using System.Security.Claims;
	using System.Reflection.Metadata.Ecma335;
	using Microsoft.AspNetCore.Authorization;

	[Route("api/[controller]")]
	[ApiController]
	public class AuthenticationController : ControllerBase
	{
		private readonly SignInManager<ApplicationUser> signInManager;
		private readonly UserManager<ApplicationUser> userManager;
		private readonly IOptions<ApiBehaviorOptions> apiBehaviorOptions;
		private readonly IUserService userService;
		private readonly ITokenAuthService tokenAuthService;

		public AuthenticationController(
			IOptions<ApiBehaviorOptions> apiBehaviorOptions,
			IUserService userService,
			SignInManager<ApplicationUser> signInManager,
			ITokenAuthService tokenAuthService,
			UserManager<ApplicationUser> userManager)
		{
			this.apiBehaviorOptions = apiBehaviorOptions;
			this.userService = userService;
			this.signInManager = signInManager;
			this.tokenAuthService = tokenAuthService;
			this.userManager = userManager;
		}



		[HttpPost("Login")]
		public async Task<IActionResult> Login(LoginUserServiceModel model)
		{
			try
			{
				ApplicationUser? user = await userService.GetByEmailAsync(model.Email);
				if (user is null)
				{
					return BadRequest();
				}

				string[] roles = (await userManager.GetRolesAsync(user)).ToArray();

				var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

				if (result.Succeeded)
				{
					List<Claim> claims = new List<Claim>();
					foreach (string role in roles)
					{
						claims.Add(new Claim(ClaimTypes.Role, role));
					}
					claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
					claims.Add(new Claim(ClaimTypes.Name, user.UserName));
					claims.Add(new Claim(ClaimTypes.Email, user.Email));
					string token = tokenAuthService.BuildToken(claims.ToArray());

					return Ok(new { token });
				}

				return BadRequest();
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}

		}


	}
}
