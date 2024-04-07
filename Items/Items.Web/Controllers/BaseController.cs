namespace Items.Web.Controllers
{
	using static Common.NotificationMessages;
	using Items.Web.Infrastructure.Filters;

	using Microsoft.AspNetCore.Authorization;
	using Microsoft.AspNetCore.Mvc;
	using System.Security.Cryptography;
	using Items.Web.Infrastructure.Extensions;
	using Items.Services.Data.Models.File;
	using Items.Services.Data.Interfaces;

	[Authorize]
	[AutoValidateAntiforgeryToken]
	[HtmlDecodeFilter]
	public abstract class BaseController : Controller
	{
		
		//todo: is here anonymous?
		protected IActionResult GeneralError(Exception? e = null)
		{

			TempData[ErrorMessage] = "Unexpected error has occurred! Try again later or contact the administrator.";
			return RedirectToAction("Index", "Home");
		}

	}

	
}
