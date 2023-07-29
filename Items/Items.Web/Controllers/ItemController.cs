namespace Items.Web.Controllers
{
	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	public class ItemController : BaseController
	{
		[AllowAnonymous]
		public async Task<IActionResult> All()
		{

			return View();
		}
	}
}
