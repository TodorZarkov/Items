namespace Items.Web.Controllers
{
	using static Common.NotificationMessages;
	using Items.Web.Infrastructure.Filters;

	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;

	[Authorize]
	[AutoValidateAntiforgeryToken]
	[HtmlDecodeFilter]
	public abstract class BaseController : Controller
	{

		protected IActionResult GeneralError(Exception? e = null)
		{
			TempData[ErrorMessage] = "Unexpected error has occurred! Try again later or contact the administrator.";
			return RedirectToAction("Index", "Home");
		}
	}

	
}
