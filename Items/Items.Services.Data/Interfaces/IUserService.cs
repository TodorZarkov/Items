namespace Items.Services.Data.Interfaces
{
	public interface IUserService
	{
		Task<DateTime> GetRotationItemsDateAsync(Guid userId);
		Task SetRotationItemsDateAsync(Guid userId, DateTime utcNow);
	}
}
