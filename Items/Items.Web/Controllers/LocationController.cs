namespace Items.Web.Controllers
{
	using Items.Services.Data.Interfaces;
	using Items.Services.Data.Models.Location;
	using Items.Web.Infrastructure.Extensions;
	using Items.Web.ViewModels.Base;
	using Items.Web.ViewModels.Location;
	using static Items.Common.NotificationMessages;

	using Microsoft.AspNetCore.Mvc;
	using Items.Web.ViewModels.Item;

	public class LocationController : BaseController
	{
		private readonly ILocationService locationService;
		private readonly IItemService itemService;

		public LocationController(ILocationService locationService, IItemService itemService)
		{
			this.locationService = locationService;
			this.itemService = itemService;
		}

		public async Task<IActionResult> All([FromQuery] QueryFilterModel? queryModel = null)
		{
			try
			{
				Guid userId = Guid.Parse(User.GetId());
				AllLocationServiceModel locations =
					await locationService.GetAllAsync(userId, queryModel);

				return View(locations);
			}
			catch (Exception e)
			{
				return GeneralError(e);
			}
		}


		[HttpGet]
		public IActionResult Add()
		{
			LocationFormModel model = new LocationFormModel()
			{
				LocationVisibility = new LocationVisibilityFormModel()
			};

			return View(model);
		}

		[HttpPost]
		public async Task<IActionResult> Add(LocationFormModel model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}
			Guid userId = Guid.Parse(User.GetId());

			Guid locationId = await locationService.CreateAsync(model, userId);
			TempData[SuccessMessage] = "The Location is Created.";

			return RedirectToAction("All", "Location");
		}

		[HttpGet]
		public async Task<IActionResult> Edit(Guid id)
		{
			try
			{
				Guid userId = Guid.Parse(User.GetId());
				bool isAllowedId = await locationService.IsAllowedIdAsync(id, userId);
				if (!isAllowedId)
				{
					TempData[ErrorMessage] = "The location you are trying to edit isn't yours.";
					return RedirectToAction("All", "Location");
				}

				LocationFormModel model = await locationService.GetByIdAsync(id);
				return View(model);
			}
			catch (Exception e)
			{
				return GeneralError(e);
			}

		}

		[HttpPost]
		public async Task<IActionResult> Edit(Guid id, LocationFormModel model)
		{
			try
			{
				Guid userId = Guid.Parse(User.GetId());
				bool isAllowedId = await locationService.IsAllowedIdAsync(id, userId);
				if (!isAllowedId)
				{
					TempData[ErrorMessage] = "The location you are trying to edit isn't yours.";
					return RedirectToAction("All", "Location");
				}

				if (!ModelState.IsValid)
				{
					return View(model);
				}

				await locationService.EditAsync(model, id);

				return RedirectToAction("All", "Location");
			}
			catch (Exception e)
			{
				return GeneralError(e);
			}

		}

		[HttpGet]
		public async Task<IActionResult> Delete(Guid id)
		{
			try
			{
				Guid userId = Guid.Parse(User.GetId());
				bool isAllowedId = await locationService.IsAllowedIdAsync(id, userId);
				if (!isAllowedId)
				{
					TempData[ErrorMessage] = "The location you are trying to delete isn't yours.";
					return RedirectToAction("All", "Location");
				}

				bool isEmpty = await locationService.IsEmptyAsync(id);
				// todo: to fix when it contains mark deleted items: either mark location as deleted or delete permanently items.
				if (!isEmpty)
				{
					TempData[InformationMessage] = "You must remove Everything(Items and Places) from your location before delete it.";
					return RedirectToAction("All", "Location");

				}

				await locationService.Delete(id);

				return RedirectToAction("All", "Location");
			}
			catch (Exception e)
			{
				return GeneralError(e);
			}
			
		}

	}
}
