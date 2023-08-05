namespace Items.Web.Controllers
{
	using Items.Services.Data.Interfaces;
	using Items.Web.Extensions;
	using Microsoft.AspNetCore.Mvc;

	public class Location : BaseController
	{
		private readonly ILocationService locationService;

		public Location(ILocationService locationService)
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
