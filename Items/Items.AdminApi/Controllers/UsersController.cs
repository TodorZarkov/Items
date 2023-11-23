namespace Items.AdminApi.Controllers
{
	using Items.Data.Models;
	using Items.Services.Data.Interfaces;
	using Items.Services.Data.Models.User;
	using Services.Common.Interfaces;
	using static Common.RoleConstants;
	using Items.Services.Validator.Interfaces;
	using Items.AdminApi.Infrastructure.Extensions;

	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Options;

	using System.Security.Claims;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.Extensions.Configuration.UserSecrets;

	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly SignInManager<ApplicationUser> signInManager;
		private readonly UserManager<ApplicationUser> userManager;
		private readonly IOptions<ApiBehaviorOptions> apiBehaviorOptions;
		private readonly IUserService userService;
		private readonly ITokenAuthService tokenAuthService;
		private readonly IUserValidatorService userValidator;

		public UsersController(
			IOptions<ApiBehaviorOptions> apiBehaviorOptions,
			IUserService userService,
			SignInManager<ApplicationUser> signInManager,
			ITokenAuthService tokenAuthService,
			UserManager<ApplicationUser> userManager,
			IUserValidatorService userValidator)
		{
			this.apiBehaviorOptions = apiBehaviorOptions;
			this.userService = userService;
			this.signInManager = signInManager;
			this.tokenAuthService = tokenAuthService;
			this.userManager = userManager;
			this.userValidator = userValidator;
		}



		[HttpPost("/api/Login")]
		public async Task<IActionResult> Login([FromBody] LoginUserServiceModel model)
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



		[HttpPost]
		public async Task<IActionResult> Register([FromBody] RegisterUserServiceModel model)
		{
			return Ok(model);
		}


		[HttpDelete("{userId}")]
		public async Task<IActionResult> Unregister([FromRoute] Guid userId)
		{
			return Ok(new { userId });
		}


		[Authorize(Roles = SuperAdmin)]
		[HttpPost("{userId}/Roles")]
		public async Task<IActionResult> AssignRole([FromRoute] Guid userId, [FromBody] string roleName)
		{
			ApplicationUser? user = await userService.GetByIdAsync(userId);

			if (user == null || !(await userValidator.CanAssign(userId, roleName)))
			{
				foreach (ModelError error in userValidator.ModelErrors)
				{
					ModelState.AddModelError(error.PropertyName, error.Message);
				}
				return apiBehaviorOptions
					.Value.InvalidModelStateResponseFactory(ControllerContext);
			}

			

			var result = await userManager.AddToRoleAsync(user, roleName) ;
			if (result.Succeeded)
			{
				return Ok();
			}

			return StatusCode(StatusCodes.Status500InternalServerError);
		}


		[Authorize(Roles = SuperAdmin)]
		[HttpDelete("{userId}/Roles/{roleId}")]
		public async Task<IActionResult> UnassignRole([FromRoute] Guid userId, [FromRoute] Guid roleId )
		{
			Guid? currentUserId = User.GetId();



			return Ok(new { userId, currentUserId, roleId });
		}
	}
}
