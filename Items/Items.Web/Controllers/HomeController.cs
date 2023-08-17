namespace Items.Web.Controllers
{
	using Items.Services.Common.Interfaces;
	using Items.Services.Data.Interfaces;
	using Items.Web.Extensions;
	using Items.Web.ViewModels.Home;
	using static Items.Common.GeneralConstants;

	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	using System.Diagnostics;

	public class HomeController : BaseController
	{
		private readonly IDateTimeProvider dateTimeProvider;
		private readonly IItemService itemService;
		private readonly IUserService userService;

		public HomeController(IDateTimeProvider dateTimeProvider, IItemService itemService, IUserService userService)
		{
			this.dateTimeProvider = dateTimeProvider;
			this.itemService = itemService;
			this.userService = userService;
		}

		[AllowAnonymous]
		public async Task<IActionResult> Index()
		{
			if (User.Identity?.IsAuthenticated ?? false)
			{
				return RedirectToAction("DailyRotation");
			}

			IEnumerable<IndexViewModel> viewModel =
				await itemService.LastPublicItemsAsync(LastPublicItemsNumber);

			return View(viewModel);
		}

		public async Task<IActionResult> DailyRotation()
		{
			Guid userId = Guid.Parse(User.GetId());
			DateTime rotationDate = await userService.GetRotationItemsDateAsync(userId);

			DateTime currentDate = dateTimeProvider.GetCurrentDate();

			if (rotationDate.Date != currentDate)
			{
				await userService
					.SetRotationItemsDateAsync(userId,
												dateTimeProvider.GetCurrentDateTime());

				await itemService
					.SetDailyRotationsAsync(userId,
											CarouselItemsNumber);
			}

			IEnumerable<OnRotationViewModel> itemsToRotate = await itemService.GetDailyRotationsAsync(userId);

			return View(itemsToRotate);
		}

		public async Task<IActionResult> NewRotation()
		{
			Guid userId = Guid.Parse(User.GetId());
			DateTime rotationDate = await userService.GetRotationItemsDateAsync(userId);

			DateTime currentDate = dateTimeProvider.GetCurrentDate();
			DateTime currentDateTime = dateTimeProvider.GetCurrentDateTime();


			await userService
				.SetRotationItemsDateAsync(userId, currentDateTime);

			await itemService
				.SetDailyRotationsAsync(userId,
										CarouselItemsNumber);


			return RedirectToAction("DailyRotation");
		}



		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}