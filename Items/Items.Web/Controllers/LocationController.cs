namespace Items.Web.Controllers
{
	using Items.Services.Data.Interfaces;
	using Items.Web.Infrastructure.Extensions;
	using Items.Web.ViewModels.Location;

	using Microsoft.AspNetCore.Mvc;

	public class LocationController : BaseController
	{
		private readonly ILocationService locationService;

		public LocationController(ILocationService locationService)
		{
			this.locationService = locationService;
		}

		public async Task<IActionResult> All()
		{
			try
			{
				Guid userId = Guid.Parse(User.GetId());
				IEnumerable<AllLocationViewModel> locations = await locationService.GetAllAsync(userId);

				return View(locations);
			}
			catch (Exception e)
			{
				return GeneralError(e);
			}
		}
	}
}
