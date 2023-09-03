namespace Items.Web.Controllers
{
	using Items.Services.Data.Interfaces;
	using Items.Web.Infrastructure.Extensions;
	using Items.Web.ViewModels.Category;
	using Items.Web.ViewModels.Item;

	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Http.Extensions;
	using Microsoft.AspNetCore.Mvc;

	public class CategoryController : BaseController
	{
		private readonly IItemService itemService;
		private readonly ICategoryService categoryService;

		public CategoryController(IItemService itemService, ICategoryService categoryService)
		{
			this.itemService = itemService;
			this.categoryService = categoryService;
		}

		
	}
}
