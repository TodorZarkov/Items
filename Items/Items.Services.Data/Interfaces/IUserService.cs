namespace Items.Services.Data.Interfaces
{
	using Items.Data.Models;

	public interface IUserService
	{
		Task<ApplicationUser?> GetByEmailAsync(string email);
		Task<DateTime> GetRotationItemsDateAsync(Guid userId);
		Task SetRotationItemsDateAsync(Guid userId, DateTime utcNow);
	}
}
