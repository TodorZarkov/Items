namespace Items.Web.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	public class Category : Controller
	{
		[HttpGet]
		public async Task<IActionResult> AllPublicNames()
		{

			return View();
		}


		[HttpGet]
		public async Task<IActionResult> MyNames()
		{

			return View();
		}

		
	}
}
