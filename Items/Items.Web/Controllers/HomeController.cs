namespace Items.Web.Controllers
{
	using Items.Services.Common.Interfaces;
	using Items.Services.Data.Interfaces;
	using Items.Web.ViewModels.Home;
	using Items.Web.Infrastructure.Extensions;
	using static Items.Common.GeneralConstants;

	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	using System.Diagnostics;
	using Items.Services.Data.Models.File;
	using Items.Services.Data;

	public class HomeController : BaseController
	{
		private readonly IDateTimeProvider dateTimeProvider;
		private readonly IItemService itemService;
		private readonly IUserService userService;
		private readonly IFileService fileService;
		private readonly IFileIdentifierService fileIdentifierService;
		private readonly IContractService contractService;

		public HomeController(IDateTimeProvider dateTimeProvider, IItemService itemService, IUserService userService, IFileIdentifierService fileIdentifierService, IFileService fileService, IContractService contractService)
		{
			this.dateTimeProvider = dateTimeProvider;
			this.itemService = itemService;
			this.userService = userService;
			this.fileIdentifierService = fileIdentifierService;
			this.fileService = fileService;
			this.contractService = contractService;
		}

		[AllowAnonymous]
		public async Task<IActionResult> Index()
		{
			if (User.Identity?.IsAuthenticated ?? false)
			{
				return RedirectToAction("DailyRotation");
			}

			IEnumerable<IndexViewModel> indexModel =
				await itemService.LastPublicItemsAsync(LastPublicItemsNumber);
			IndexStatViewModel indexStatViewModel = new IndexStatViewModel
			{
				IndexViewModels = indexModel,
				DealsCompletedCount = await contractService.CountCompletedAsync(),
				ItemsCount = await itemService.CountAsync(),
				ItemsOnMarketCount = await itemService.CountOnMarketAsync(),
				UsersCount = await userService.CountAsync()
			};

			return View(indexStatViewModel);
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


		[AllowAnonymous]
		public async Task<IActionResult> File(Guid id)
		{
			Guid userId = new Guid();
			if (User.Identity?.IsAuthenticated ?? false)
			{
				userId = Guid.Parse(User.GetId());
			}
			bool canAccess = await fileIdentifierService.CanAccessAsync(userId, id);
			if (!canAccess)
			{
				return StatusCode(StatusCodes.Status403Forbidden);
			}


			FileServiceModel file = await fileService.GetAsync(id);

			return File(file.Bytes, file.MimeType);
		}
	}
}