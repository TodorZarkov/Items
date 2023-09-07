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

		[HttpGet]
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

		[HttpGet]
		public async Task<IActionResult> AllByLocation(Guid id)
		{
			try
			{
				Guid userId = Guid.Parse(User.GetId());
				IEnumerable<ForSelectPlaceViewModel> model = await placeService.AllForSelectAsync(userId,id);

				if (!model.Any())
				{
					return BadRequest();
				}

				return Ok(model);
			}
			catch (Exception e)
			{
				return StatusCode(500);
			}
		}

	}
}
