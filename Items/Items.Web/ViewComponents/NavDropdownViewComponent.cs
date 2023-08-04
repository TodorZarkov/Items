namespace Items.Web.ViewComponents
{
	using Items.Services.Data.Interfaces;
	using Items.Web.ViewModels.Category;
	using Microsoft.AspNetCore.Mvc;
	using System.Security.Claims;

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

			categories["All"] = (await categoryService.GetAllAsync()).ToList();

			if (User.Identity?.IsAuthenticated ?? false)
			{

				string? userId = UserClaimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

				//todo: can userId be null here???

				categories["Mine"] = (await categoryService.GetMineAsync(new Guid(userId))).ToList();
			}

			return View(categories);

		}
	}
}
