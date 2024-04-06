namespace Items.Services.Data.Interfaces
{
	using Items.Data.Models;
	using Items.Services.Data.Models.User;
	using Microsoft.AspNetCore.Http;
	using Microsoft.AspNetCore.Identity;

	public interface IUserService
	{
		Task<long> CountAsync();
		Task<ApplicationUser?> GetByEmailAsync(string email);
		Task<ApplicationUser?> GetByIdAsync(Guid userId);
		Task<AllRoleServiceModel[]> GetRolesAsync(ApplicationUser user);
		Task<string?> GetRoleAsync(Guid roleId);
		Task<DateTime> GetRotationItemsDateAsync(Guid userId);
		Task<IdentityResult> RegisterAsync(RegisterUserServiceModel model);
		Task<bool> RoleExistAsync(string role);
		Task SetRotationItemsDateAsync(Guid userId, DateTime utcNow);
		Task AddProfilePictureAsync(Guid userId, IFormFile profilePicture);
		Task<byte[]?> GetProfilePictureAsync(Guid userId);
		Task DeleteProfilePictureAsync(Guid userId);
	}
}
