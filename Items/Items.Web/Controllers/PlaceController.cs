namespace Items.Web.Controllers
{
	using Items.Services.Data.Interfaces;
	using Items.Web.Infrastructure.Extensions;
	using Items.Web.ViewModels.Place;
	using Microsoft.AspNetCore.Mvc;

	public class PlaceController : BaseController
	{
		private readonly IPlaceService placeService;

		public PlaceController(IPlaceService placeService)
		{
			this.placeService = placeService;
		}

		public async Task<IActionResult> All()
		{
			try
			{
				Guid userId = Guid.Parse(User.GetId());
				IEnumerable<AllPlaceViewModel> model = await placeService.AllAsync(userId);

				return View(model);
			}
			catch (Exception e)
			{
				return GeneralError(e);
			}
		}
	}
}
