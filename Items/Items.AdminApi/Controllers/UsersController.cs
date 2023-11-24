﻿namespace Items.AdminApi.Controllers
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


		[HttpPost]
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


		//todo: how to forget user - to set deleted flag and to delete personal data. to set email as nullable. to break relations. to inform user of closing activities...
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
			string? roleName =  await userService.GetRoleAsync(roleId);
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
	}
}
