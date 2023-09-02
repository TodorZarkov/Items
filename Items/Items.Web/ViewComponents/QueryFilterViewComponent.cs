namespace Items.Web.ViewComponents
{
	using Items.Services.Common.Interfaces;
	using Items.Services.Data.Interfaces;
	using Items.Web.ViewModels.Base;
	using Items.Web.Infrastructure.Extensions;
	using static Common.Enums.Criteria;
	using static Common.Enums.Sorting;

	using Microsoft.AspNetCore.Mvc;
	using NuGet.Packaging;
	using Items.Common.Enums;

	public class QueryFilterViewComponent : ViewComponent
	{
		private readonly ICategoryService categoryService;
		private readonly IHelper helper;

		public QueryFilterViewComponent(ICategoryService categoryService, IHelper helper)
		{
			this.categoryService = categoryService;
			this.helper = helper;
		}

		public async Task<IViewComponentResult> InvokeAsync(int hits)
		{
			QueryFilterViewModel model = new QueryFilterViewModel();

			string? controllerName = Request.RouteValues["controller"]?.ToString();
			string? controllerNamePlural = helper.Pluralize(controllerName);

			bool isAuthenticated = User.Identity?.IsAuthenticated ?? false;



			model.AllAvailableCategories = await categoryService.GetForSelectAsync();

			model.SearchPlaceHolder = $"Search in {controllerNamePlural}";

			model.AvailableCriteria
				.AddRange(helper.GetAllowedCriteria(isAuthenticated, controllerName));
			model.AvailableSorting
				.AddRange(helper.GetAllowedSorting(isAuthenticated, controllerName));

			if (isAuthenticated)
			{
				Guid userId = Guid.Parse(UserClaimsPrincipal.GetId());

				model.MyAvailableCategories = await categoryService.GetForSelectAsync(userId);
			}



			if (Request.Query.ContainsKey("HitsPerPage"))
			{
				if (int.TryParse(Request.Query["HitsPerPage"], out int hitsPerPage))
				{
					model.HitsPerPage = hitsPerPage;
				}
			}

			if (Request.Query.ContainsKey("SearchTerm"))
			{
				model.SearchTerm = Request.Query["SearchTerm"];
			}

			if (Request.Query.ContainsKey("CurrentPage"))
			{
				if (int.TryParse(Request.Query["CurrentPage"], out int currentPage))
				{
					model.CurrentPage = currentPage;
				}
			}

			if (Request.Query.ContainsKey("SortBy"))
			{
				model.Sorting = Request.Query["SortBy"];
			}

			if (Request.Query.ContainsKey("CategoryIds"))
			{
				foreach (var id in Request.Query["CategoryIds"])
				{
					if (int.TryParse(id, out int result))
					{
						model.CategoryIds.Add(result);
					}
				}

			}

			if (Request.Query.ContainsKey("Criteria"))
			{
				foreach (var criteria in Request.Query["Criteria"])
				{
					model.Criteria.Add(criteria);
				}
			}



			model.Hits = hits;
			if (model.Hits > 0)
			{
				model.LastPage =
					model.Hits / model.HitsPerPage + (model.Hits % model.HitsPerPage == 0 ? 0 : 1);
			}
			

			return View(model);
		}
	}
}
