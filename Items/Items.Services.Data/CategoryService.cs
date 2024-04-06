namespace Items.Services.Data
{
	using Items.Data;
	using Items.Services.Data.Interfaces;
	using Items.Web.ViewModels.Category;
	using static Items.Common.RoleConstants;

	using Microsoft.EntityFrameworkCore;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using Items.Data.Models;

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
				.Where(r => r.NormalizedName == SuperAdmin.ToUpper() || r.NormalizedName == Admin.ToUpper())
				.Select(r => r.Id)
				.ToArrayAsync();


			var adminIds = await dbContext.UserRoles
				.Where(ur => adminRoleId.Contains(ur.RoleId))
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
				.Where(r => r.NormalizedName == SuperAdmin.ToUpper() || r.NormalizedName == Admin.ToUpper())
				.Select(r => r.Id)
				.ToArrayAsync();


			var adminIds = await dbContext.UserRoles
				.Where(ur => adminRoleId.Contains(ur.RoleId))
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
				.Where(r => r.NormalizedName == SuperAdmin.ToUpper() || r.NormalizedName == Admin.ToUpper())
				.Select(r => r.Id)
				.ToArrayAsync();


			var adminIds = await dbContext.UserRoles
				.Where(ur => adminRoleId.Contains(ur.RoleId))
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


		public async Task<IEnumerable<ForSelectCategoryViewModel>> GetForSelectAsync(Guid? userId = null)
		{
			if (userId == null)
			{
				var adminRoleId = await dbContext.Roles
				.Where(r => r.NormalizedName == SuperAdmin.ToUpper() || r.NormalizedName == Admin.ToUpper())
				.Select(r => r.Id)
				.ToArrayAsync();


				var adminIds = await dbContext.UserRoles
					.Where(ur => adminRoleId.Contains(ur.RoleId))
					.Select(ur => ur.UserId)
					.ToArrayAsync();


				ICollection<ForSelectCategoryViewModel> categoryViewModels = await dbContext.Categories
					.Where(c => adminIds.Contains(c.CreatorId))
					.Select(c => new ForSelectCategoryViewModel
					{
						Id = c.Id,
						Name = c.Name
					})
					.ToArrayAsync();

				return categoryViewModels;
			}
			else
			{
				ICollection<ForSelectCategoryViewModel> categoryViewModels = await dbContext.Categories
					.Where(c => c.CreatorId == userId)
					.Select(c => new ForSelectCategoryViewModel
					{
						Id = c.Id,
						Name = c.Name
					})
					.ToArrayAsync();

				return categoryViewModels;
			}

		}



		public async Task<int> AddAsync(CategoryFormViewModel model, Guid userId)
		{
			Category category = new Category
			{
				CreatorId = userId,
				Name = model.Name
			};

			await dbContext.Categories.AddAsync(category);
			await dbContext.SaveChangesAsync();

			return category.Id;
		}



		public async Task<bool> IsAllowedIdsAsync(int[] ids, Guid userId)
		{

			HashSet<Guid> adminIdsHS = await GetAdminIds();


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

		//todo: index the name
		public async Task<bool> ExistNameAsync(string name, Guid userId, Guid )
		{
			var adminIds = await GetAdminIds();
			bool result = await dbContext.Categories
				.AsNoTracking()
				.AnyAsync(c => 
					c.Name == name && 
					(c.CreatorId == userId || adminIds.Contains(c.CreatorId))
				);

			return result;
		}

		private async Task<HashSet<Guid>> GetAdminIds()
		{
			var adminRoleId = await dbContext.Roles
				.Where(r => r.NormalizedName == SuperAdmin.ToUpper() || r.NormalizedName == Admin.ToUpper())
				.Select(r => r.Id)
				.ToArrayAsync();


			var adminIds = await dbContext.UserRoles
				.Where(ur => adminRoleId.Contains(ur.RoleId))
				.Select(ur => ur.UserId)
				.ToArrayAsync();

			HashSet<Guid> adminIdsHS = adminIds.ToHashSet();
			return adminIdsHS;
		}
	}
}
