namespace Items.Web.Controllers
{
	using Items.Services.Data.Interfaces;
	using Items.Services.Data.Models.Place;

	using Items.Web.Infrastructure.Extensions;
	using Items.Web.ViewModels.Place;
	using static Items.Common.NotificationMessages;

	using Microsoft.AspNetCore.Mvc;
	using Items.Web.ViewModels.Base;

	public class PlaceController : BaseController
	{
		private readonly IPlaceService placeService;
		private readonly ILocationService locationService;

		public PlaceController(IPlaceService placeService, ILocationService locationService)
		{
			this.placeService = placeService;
			this.locationService = locationService;
		}

		[HttpGet]
		public async Task<IActionResult> All(QueryFilterModel? queryModel = null)
		{
			try
			{
				Guid userId = Guid.Parse(User.GetId());
				AllPlaceServiceModel model = await placeService.AllAsync(userId, queryModel);

				return View(model);
			}
			catch (Exception e)
			{
				return GeneralError(e);
			}
		}

		//for ajax
		[HttpGet]
		public async Task<IActionResult> AllByLocation(Guid id)
		{
			try
			{
				Guid userId = Guid.Parse(User.GetId());
				IEnumerable<ForSelectPlaceViewModel> model = await placeService.AllForSelectAsync(userId, id);

				if (!model.Any())
				{
					return BadRequest();
				}

				return Ok(model);
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError);
			}
		}


		[HttpGet]
		public async Task<IActionResult> Add(Guid? id)
		{
			try
			{
				Guid userId = Guid.Parse(User.GetId());
				PlaceFormModel model = new PlaceFormModel()
				{
					AvailableLocations = await locationService.GetForSelectAsync(userId),
				};

				if (id.HasValue)
				{
					model.LocationId = (Guid)id;
				}

				return View(model);
			}
			catch (Exception e)
			{
				return GeneralError(e);
			}
			
		}

		[HttpPost]
		public async Task<IActionResult> Add(PlaceFormModel model)
		{
			try
			{
				Guid userId = Guid.Parse(User.GetId());
				bool isAllowedLocationId = await locationService.IsAllowedIdAsync(model.LocationId, userId);
				if (!isAllowedLocationId)
				{
					ModelState.AddModelError(nameof(model.LocationId), "Invalid Location Id.");
				}
				if (!ModelState.IsValid || !isAllowedLocationId)
				{
					model.AvailableLocations = await locationService.GetForSelectAsync(userId);
					return View(model);
				}

				await placeService.CreateAsync(model);
				TempData[SuccessMessage] = "The Place is Created.";

				return RedirectToAction("All", "Place");
			}
			catch (Exception e)
			{
				return GeneralError(e);
			}
		}

		[HttpGet]
		public async Task<IActionResult> Edit(int id)
		{
			try
			{
				Guid userId = Guid.Parse(User.GetId());
				bool isAllowedId = await placeService.IsAllowedIdAsync(id, userId);
				if (!isAllowedId)
				{
					TempData[ErrorMessage] = "You cannot edit this Place";
					return RedirectToAction("All", "Place");
				}

				PlaceFormModel model = await placeService.GetByIdAsync(id);
				model.AvailableLocations = await locationService.GetForSelectAsync(userId);

				return View(model);
			}
			catch (Exception e)
			{
				return GeneralError(e);
			}
		}

		[HttpPost]
		public async Task<IActionResult> Edit(int id, PlaceFormModel model)
		{
			try
			{
				Guid userId = Guid.Parse(User.GetId());
				bool isAllowedId = await placeService.IsAllowedIdAsync(id, userId);
				if (!isAllowedId)
				{
					TempData[ErrorMessage] = "You cannot edit this Place.";
				}
				if (!ModelState.IsValid || !isAllowedId)
				{
					model.AvailableLocations = await locationService.GetForSelectAsync(userId);
					return View(model);
				}

				await placeService.EditAsync(id, model);
				return RedirectToAction("All", "Place");
			}
			catch (Exception e)
			{
				return GeneralError(e);
			}
		}

		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				Guid userId = Guid.Parse(User.GetId());
				bool isAllowedId = await placeService.IsAllowedIdAsync(id, userId);
				if (!isAllowedId)
				{
					TempData[ErrorMessage] = "You cannot delete this Place.";
				}
				bool hasItems = await placeService.HasItems(id);
				if (hasItems)
				{
					TempData[InformationMessage] = "The Place must be empty.";
					return RedirectToAction("All", "Place");
				}

				await placeService.DeleteAsync(id);
				TempData[SuccessMessage] = "Deleted successfully";

				return RedirectToAction("All", "Place");
			}
			catch (Exception e)
			{
				return GeneralError(e);
			}
		}


	}
}
