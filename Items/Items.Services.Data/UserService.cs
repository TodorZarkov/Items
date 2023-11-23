namespace Items.Services.Data
{
	using Items.Data;
	using Items.Data.Models;
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

		public async Task<ApplicationUser?> GetByEmailAsync(string email)
		{
			ApplicationUser?  user = await dbContext.Users
				.FirstOrDefaultAsync(u => u.NormalizedEmail == email.ToUpper());

			return user;
		}

		public async Task<ApplicationUser?> GetByIdAsync(Guid userId)
		{
			ApplicationUser? user = await dbContext.Users.FindAsync(userId);
			return user;
		}

		public async Task<DateTime> GetRotationItemsDateAsync(Guid userId)
		{
			DateTime date = await dbContext.Users
				.Where(u => u.Id == userId)
				.Select(u => u.RotationItemsDate)
				.FirstAsync();

			return date;
		}

		public async Task<bool> RoleExistAsync(string role)
		{
			bool result = await dbContext.Roles
				.AnyAsync(r => r.NormalizedName == role.ToUpper());

			return result;
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
