namespace Items.Services.Data
{
	using Items.Data;
	using Items.Services.Data.Interfaces;
	using Items.Web.ViewModels.Category;
	using Microsoft.EntityFrameworkCore;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public class CategoryService : ICategoryService
	{
		private readonly ItemsDbContext dbContext;

        public CategoryService(ItemsDbContext dbContext)
        {
			this.dbContext = dbContext;
        }


        public async Task<ICollection<CategoryFilterViewModel>> GetAllPublicAsync()
		{
			var adminRoleId = await dbContext.Roles
				.Where(r => r.NormalizedName == "ADMIN")
				.Select(r => r.Id)
				.ToArrayAsync();


			var adminIds = await dbContext.UserRoles
				.Where(ur => ur.RoleId == adminRoleId[0])
				.Select(ur => ur.UserId)
				.ToArrayAsync();


			ICollection<CategoryFilterViewModel> categoryViewModels = await dbContext.Categories
				.Where(c => adminIds.Contains(c.CreatorId))
				.Select(c => new CategoryFilterViewModel
				{
					Id = c.Id,
					Name = c.Name
				})
				.ToArrayAsync();

			return categoryViewModels;
		}

		public async Task<ICollection<CategoryFilterViewModel>> GetMineAsync(Guid userId)
		{
			ICollection<CategoryFilterViewModel> categories = await dbContext.Categories
				.Where(c => c.CreatorId == userId)
				.Select(c => new CategoryFilterViewModel
				{
					Id = c.Id,
					Name = c.Name
				})
				.ToArrayAsync();

			return categories;
		}

		public async Task<IEnumerable<CategoryFilterViewModel>> AllForSelectAsync(Guid userId)
		{
			var adminRoleId = await dbContext.Roles
				.Where(r => r.NormalizedName == "ADMIN")
				.Select(r => r.Id)
				.ToArrayAsync();


			var adminIds = await dbContext.UserRoles
				.Where(ur => ur.RoleId == adminRoleId[0])
				.Select(ur => ur.UserId)
				.ToArrayAsync();


			ICollection<CategoryFilterViewModel> categoryViewModels = await dbContext.Categories
				.Where(c => adminIds.Contains(c.CreatorId) || c.CreatorId == userId)
				.Select(c => new CategoryFilterViewModel
				{
					Id = c.Id,
					Name = c.Name
				})
				.ToArrayAsync();

			return categoryViewModels;
		}


		public async Task<ICollection<int>> GetAllPublicIdsAsync()
		{
			var adminRoleId = await dbContext.Roles
				.Where(r => r.NormalizedName == "ADMIN")
				.Select(r => r.Id)
				.ToArrayAsync();


			var adminIds = await dbContext.UserRoles
				.Where(ur => ur.RoleId == adminRoleId[0])
				.Select(ur => ur.UserId)
				.ToArrayAsync();


			int[] categoryIds = await dbContext.Categories
				.Where(c => adminIds.Contains(c.CreatorId))
				.Select(c => c.Id)
				.ToArrayAsync();

			return categoryIds;
		}

		public async Task<ICollection<int>> GetAllIdsAsync()
		{
			
			int[] categoryIds = await dbContext.Categories
				.Select(c => c.Id)
				.ToArrayAsync();

			return categoryIds;
		}


		public async Task<bool> IsAllowedIdsAsync(int[] ids, Guid userId)
		{
			var adminRoleId = await dbContext.Roles
				.Where(r => r.NormalizedName == "ADMIN")
				.Select(r => r.Id)
				.ToArrayAsync();


			var adminIds = await dbContext.UserRoles
				.Where(ur => ur.RoleId == adminRoleId[0])
				.Select(ur => ur.UserId)
				.ToArrayAsync();

			HashSet<Guid> adminIdsHS = adminIds.ToHashSet();


			int[] validIds = await dbContext.Categories
				.Where(c => adminIdsHS.Contains(c.CreatorId) || userId == c.CreatorId)
				.Select(c => c.Id)
				.ToArrayAsync();
			HashSet<int> validIdsHS = validIds.ToHashSet();
			if (ids == null || ids.Length == 0)
			{
				return false;
			}
			return ids.All(i => validIdsHS.Contains(i));
		}

		public async Task<bool> IsAllowedPublicIdsAsync(int[] ids)
		{
			HashSet<int> validIds = (await GetAllPublicIdsAsync()).ToHashSet();

			return ids.All(i => validIds.Contains(i));
		}

		
	}
}
