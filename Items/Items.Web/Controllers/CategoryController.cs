namespace Items.Web.Controllers
{
	using Microsoft.AspNetCore.Mvc;

	public class CategoryController : BaseController
	{
		public async Task<IActionResult> Filtered()
		{
			return View();
		}
	}
}
