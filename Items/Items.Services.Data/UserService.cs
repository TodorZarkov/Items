namespace Items.Services.Data
{
	using Items.Data;
	using Items.Services.Data.Interfaces;
	using Microsoft.EntityFrameworkCore;
	using System;
	using System.Threading.Tasks;

	public class UserService : IUserService
	{
		private readonly ItemsDbContext dbContext;

		public UserService(ItemsDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<DateTime> GetRotationItemsDateAsync(Guid userId)
		{
			DateTime date = await dbContext.Users
				.Where(u => u.Id == userId)
				.Select(u => u.RotationItemsDate)
				.FirstAsync();

			return date;
		}

		public async Task SetRotationItemsDateAsync(Guid userId, DateTime newDateTime)
		{
			dbContext.Users
				.Find(userId)!
				.RotationItemsDate = newDateTime;

			await dbContext.SaveChangesAsync();
		}
	}
}
