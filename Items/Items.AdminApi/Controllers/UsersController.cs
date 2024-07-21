namespace Items.AdminApi.Controllers
{
	using Items.Data.Models;
	using Items.Services.Data.Interfaces;
	using Items.Services.Data.Models.User;
	using Services.Common.Interfaces;
	using static Common.RoleConstants;
	using Items.Services.Validator.Interfaces;

	using Microsoft.AspNetCore.Identity;
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.Extensions.Options;

	using System.Security.Claims;
	using Microsoft.AspNetCore.Authorization;
	using Items.AdminApi.Infrastructure.Extensions;
	using System.Net.Mime;

	[Authorize]
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



		[AllowAnonymous]
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

				AllRoleServiceModel[] roles = await userService.GetRolesAsync(user);



				var result = await signInManager.PasswordSignInAsync(user, model.Password, false, false);

				if (result.Succeeded)
				{
					List<Claim> claims = new List<Claim>();
					foreach (var role in roles)
					{
						claims.Add(new Claim(ClaimTypes.Role, role.Name));
						claims.Add(new Claim($"role{role.Name}Id", role.Id.ToString()));
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


		[AllowAnonymous]
		[HttpPost("/api/Register")]
		public async Task<IActionResult> Register([FromBody] RegisterUserServiceModel model)
		{
			IdentityResult result = await userService.RegisterAsync(model);

			if (!result.Succeeded)
			{
				foreach (IdentityError error in result.Errors)
				{
					ModelState.AddModelError(error.Code, error.Description);
				}

				return apiBehaviorOptions
						.Value.InvalidModelStateResponseFactory(ControllerContext);
			}

			return Ok();
		}


		//todo: how to forget user - to set deleted flag and to delete personal data. to set email as nullable. to break relations. to inform user of closing activities, to transfer all personal data if the user  requires ...
		[HttpDelete("Me")]
		public async Task<IActionResult> Unregister()
		{
			Guid? userId = User.GetId();
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



			var result = await userManager.AddToRoleAsync(user, roleName);
			if (result.Succeeded)
			{
				return Ok();
			}
			else
			{
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(error.Code, error.Description);
				}
				return apiBehaviorOptions
					.Value.InvalidModelStateResponseFactory(ControllerContext);
			}
		}


		[Authorize(Roles = SuperAdmin)]
		[HttpDelete("{userId}/Roles/{roleId}")]
		public async Task<IActionResult> UnassignRole([FromRoute] Guid userId, [FromRoute] Guid roleId)
		{
			//todo: now a super admin can unassign itself from the rol. is it a problem?
			//todo: consider temporary password for admin and super admin.
			ApplicationUser? user = await userService.GetByIdAsync(userId);
			if (user == null)
			{
				ModelState.AddModelError(nameof(userId), "Invalid User Id.");
				return apiBehaviorOptions
					.Value.InvalidModelStateResponseFactory(ControllerContext);
			}
			string? roleName = await userService.GetRoleAsync(roleId);
			if (string.IsNullOrEmpty(roleName))
			{
				ModelState.AddModelError(nameof(roleId), "Invalid Role Id.");
				return apiBehaviorOptions
					.Value.InvalidModelStateResponseFactory(ControllerContext);
			}

			IdentityResult result = await userManager.RemoveFromRoleAsync(user, roleName);
			if (!result.Succeeded)
			{
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError(error.Code, error.Description);
				}
				return apiBehaviorOptions
					.Value.InvalidModelStateResponseFactory(ControllerContext);
			}

			return Ok();
		}



		[HttpPost("Me/Profile/Picture")]
		public async Task<IActionResult> AddProfilePicture([FromForm] IFormFile profilePicture )
		{
			if (profilePicture == null || profilePicture.Length == 0)
			{
				ModelState.AddModelError(nameof(profilePicture), "Image file is required.");
				return apiBehaviorOptions.Value.InvalidModelStateResponseFactory(ControllerContext);
			}
			//todo: check the size of the picture

			try
			{

				Guid? userId = User.GetId();
				await userService.AddProfilePictureAsync((Guid)userId!, profilePicture);

				return Ok();
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}


		[HttpGet("Me/Profile/Picture")]
		public async Task<IActionResult> GetProfilePicture()
		{
			try
			{
				Guid? userId = User.GetId();
				byte[]? pictureBytes = await userService.GetProfilePictureAsync((Guid)userId!);
				//todo: check null, return default picture
				return File(pictureBytes, "image/png");
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status404NotFound);
			}
		}


		[HttpDelete("Me/Profile/Picture")]
		public async Task<IActionResult> RemoveProfilePicture()
		{
			try
			{
				Guid? userId = User.GetId();
				await userService.DeleteProfilePictureAsync((Guid)userId!);
				//todo: return default picture
				return Ok();
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}


		[HttpGet]
        [Authorize(Roles = SuperAdmin)]
        public async Task<IActionResult> GetAll()
		{
			try
			{
                var users = await userService.AllAsync();

                return Ok(users);
            }
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
			
		}
	}
}
