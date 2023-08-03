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
			if (User.Identity?.IsAuthenticated ?? false)
			{
				Dictionary<string, IEnumerable<CategoryViewModel>> categories =
				new Dictionary<string, IEnumerable<CategoryViewModel>>();

				categories["All"] = await categoryService.GetAllAsync();

				string? userId = UserClaimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;

				//todo: can userId be null here???

				categories["Mine"] = await categoryService.GetMineAsync(new Guid(userId));



				return View("MineAndAll", categories);
			}
			else
			{
				IEnumerable<CategoryViewModel> categories =
				await categoryService.GetAllAsync();

				return View("All", categories);
			}
			
		}
    }
}
