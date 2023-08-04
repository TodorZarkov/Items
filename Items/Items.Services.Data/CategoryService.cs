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


        public async Task<ICollection<CategoryFilterViewModel>> GetAllAsync()
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
	}
}
