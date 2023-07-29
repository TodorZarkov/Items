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
        private const int numberOfItems = 3;
        public HomeController(IItemService itemService)
        {
            this.itemService = itemService;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            IEnumerable<IndexViewModel> viewModel = 
                await itemService.LastPublicItemsAsync(numberOfItems);

            return View(viewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}