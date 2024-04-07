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
	using System.Diagnostics.Eventing.Reader;

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
		public async Task DeleteAsync(int id)
		{
			Category? category = await dbContext.Categories.FindAsync(id) 
				?? throw new ArgumentNullException();
			dbContext.Categories.Remove(category);

			await dbContext.SaveChangesAsync();
		}


		public async Task<bool> IsAllowedIdsAsync(int[]? ids, Guid userId)
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
		public async Task<bool> ExistNameAsync(string name, Guid userId)
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

		public async Task<long> CountReferencesAsync(int categoryId)
		{
			long numberOfReferences = await dbContext.ItemsCategories
				.AsNoTracking()
				.LongCountAsync(ic => ic.CategoryId == categoryId);

			return numberOfReferences;
		}

		public async Task<bool> IsOwnerAsync(Guid userId, int categoryId)
		{
			Category category = await dbContext.Categories.FindAsync(categoryId)
				?? throw new ArgumentNullException("Category id doesn't exist.");

			return category.CreatorId == userId;
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

		public async Task<bool> ExistAsync(int categoryId)
		{
			Category? category = await dbContext.Categories.FindAsync(categoryId);

			if (category == null)
			{
				return false;
			}

			return true;
		}
	}
}
