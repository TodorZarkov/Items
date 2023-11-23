namespace Items.Services.Data.Interfaces
{
	using Items.Data.Models;

	public interface IUserService
	{
		Task<ApplicationUser?> GetByEmailAsync(string email);
		Task<ApplicationUser?> GetByIdAsync(Guid userId);
		Task<DateTime> GetRotationItemsDateAsync(Guid userId);
		Task<bool> RoleExistAsync(string role);
		Task SetRotationItemsDateAsync(Guid userId, DateTime utcNow);
	}
}
