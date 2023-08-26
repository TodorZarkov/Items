namespace Items.Web.Controllers
{
	using Items.Services.Data.Interfaces;
	using Items.Web.Infrastructure.Extensions;
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
			var userId = User.GetId();
			var locations = await locationService.AllAsync(Guid.Parse(userId));

			return View(locations);
		}
	}
}
