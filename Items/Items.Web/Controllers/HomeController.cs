namespace Items.Web.Controllers
{
	using Items.Services.Data.Interfaces;
	using Items.Web.Extensions;
	using Items.Web.ViewModels.Home;

	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

    using System.Diagnostics;

    public class HomeController : BaseController
    {
        private readonly IItemService itemService;
        private readonly IUserService userService;
        private const int numberOfItemsIndex = 5;
        private const int numberOfItemsToRotate = 4;

		public HomeController(IItemService itemService, IUserService userService)
		{
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
                await itemService.LastPublicItemsAsync(numberOfItemsIndex);

            return View(viewModel);
        }

        public async Task<IActionResult> DailyRotation()
        {
            Guid userId = Guid.Parse(User.GetId());
            DateTime rotationDate = await userService.GetRotationItemsDateAsync(userId);

            if (rotationDate.Date != DateTime.UtcNow.Date)
            {
				await userService.SetRotationItemsDateAsync(userId, DateTime.UtcNow);
				await itemService.SetDailyRotationsAsync(userId, numberOfItemsToRotate);
			}

			IEnumerable<OnRotationViewModel> itemsToRotate = await itemService.GetDailyRotationsAsync(userId);

			return View(itemsToRotate);
        }


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}