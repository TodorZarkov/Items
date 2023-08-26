namespace Items.Web.ViewComponents
{
	using Microsoft.AspNetCore.Mvc;

	using Items.Services.Data.Interfaces;
	using Items.Web.ViewModels.Category;
	using Items.Web.Infrastructure.Extensions;

	public class NavDropdownViewComponent : ViewComponent
	{
		private readonly ICategoryService categoryService;

		public NavDropdownViewComponent(ICategoryService categoryService)
		{
			this.categoryService = categoryService;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			Dictionary<string, List<CategoryFilterViewModel>> categories =
				new Dictionary<string, List<CategoryFilterViewModel>>();

			categories["All"] = (await categoryService.GetAllPublicAsync()).ToList();

			if (User.Identity?.IsAuthenticated ?? false)
			{

				string? userId = UserClaimsPrincipal.GetId();
				//todo: can userId be null here???

				categories["Mine"] = (await categoryService.GetMineAsync(new Guid(userId))).ToList();
			}

			return View(categories);

		}
	}
}
