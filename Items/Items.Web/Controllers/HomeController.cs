namespace Items.Web.Controllers
{
	using Items.Services.Data.Interfaces;
	using Items.Web.ViewModels.Home;
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
    using System.Diagnostics;

    public class HomeController : BaseController
    {
        private readonly IItemService itemService;
        private const int numberOfItems = 5;


        public HomeController(IItemService itemService)
        {
            this.itemService = itemService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            if (User.Identity?.IsAuthenticated ?? false)
            {
                return RedirectToAction("DailyRotation");
            }

            IEnumerable<IndexViewModel> viewModel = 
                await itemService.LastPublicItemsAsync(numberOfItems);

            return View(viewModel);
        }

        public async Task<IActionResult> DailyRotation()
        {

            return View();
        }


		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}