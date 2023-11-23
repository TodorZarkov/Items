namespace Items.Services.Validator
{
	using Items.Data.Models;
	using Items.Services.Data.Interfaces;
	using Items.Services.Data.Models.User;
	using Items.Services.Validator.Interfaces;
	using Microsoft.AspNetCore.Identity;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public class UserValidatorService : IUserValidatorService
	{
		private readonly IUserService userService;
		private readonly UserManager<ApplicationUser> userManager;
		private readonly RoleManager<IdentityRole<Guid>> roleManager;

		public UserValidatorService(IUserService userService, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole<Guid>> roleManager)
		{
			this.ModelErrors = new HashSet<ModelError>();
			this.userService = userService;
			this.userManager = userManager;
			this.roleManager = roleManager;
		}
		public ICollection<ModelError> ModelErrors { get; set; }


		public async Task<bool> IsRegisterAdminModelValid(RegisterAdminServiceModel model)
		{
			ModelError modelError = new ModelError();
			ApplicationUser? user = await userService.GetByEmailAsync(model.Email);
			if (user is null)
			{
				modelError.PropertyName = nameof(model.Email);
				modelError.Message = "User with That Email Doesn't exist!";
				ModelErrors.Add(modelError);
				return false;
			}

			if((await userManager.IsInRoleAsync(user, model.Role)))
			{
				modelError.PropertyName = nameof(model.Role);
				modelError.Message = "The User is already in that Role!";
				ModelErrors.Add(modelError);
				return false;
			}

			if(!(await userService.RoleExistAsync(model.Role)))
			{
				modelError.PropertyName = nameof(model.Role);
				modelError.Message = "No such Role.";
				ModelErrors.Add(modelError);
				return false;
			}

			return true;
		}
	}
}
