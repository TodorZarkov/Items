namespace Items.Services.Data
{
	using Items.Data;
	using Items.Services.Data.Interfaces;
	using Items.Web.ViewModels.Location;
	using Items.Web.ViewModels.Place;
	using Microsoft.EntityFrameworkCore;
	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public class PlaceService : IPlaceService
	{
		private readonly ItemsDbContext dbContext;

		public PlaceService(ItemsDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<IEnumerable<AllPlaceViewModel>> AllAsync(Guid userId)
		{
			IEnumerable<AllPlaceViewModel> places = await dbContext.Places
				.Where(p => p.Location.UserId == userId)
				.OrderBy(p => p.Name)
				.Select(p => new AllPlaceViewModel
				{
					Id = p.Id,
					Name = p.Name,
					Location = p.Location.Name,
					Description = p.Description != null ? p.Description : "Not Added.",
					Items = p.Items.Count,
				})
				.ToArrayAsync();

			return places;
		}

		public async Task<IEnumerable<ForSelectPlaceViewModel>> AllForSelectAsync(Guid userId, Guid locationId)
		{
			IEnumerable<ForSelectPlaceViewModel> places = await dbContext.Places
				.Where(p => p.Location.UserId == userId && p.LocationId == locationId)
				.OrderBy(p => p.Location.Name)
				.ThenBy(p => p.Name)
				.Select(p => new ForSelectPlaceViewModel
				{
					PlaceId = p.Id,
					PlaceName = p.Name,
				})
				.ToArrayAsync();

			return places;
		}

		
		public async Task<IEnumerable<ForSelectPlaceViewModel>> AllForSelectAsync(Guid userId)
		{
			IEnumerable<ForSelectPlaceViewModel> places = await dbContext.Places
				.Where(p => p.Location.UserId == userId)
				.OrderBy(p => p.Name)
				.Select(p => new ForSelectPlaceViewModel
				{
					PlaceId = p.Id,
					PlaceName = p.Name,
					LocationName = p.Location.Name,
					ExtendedPlaceName = $"{p.Name} - ( {p.Location.Name} )"
				})
				.ToArrayAsync();

			return places;
		}

		public async Task<bool> IsAllowedIdAsync(int placeId, Guid locationId, Guid userId)
		{
			bool result = await dbContext.Places
				.Where(p => p.Location.UserId == userId && p.LocationId == locationId)
				.AnyAsync(p => p.Id == placeId);

			return result;
		}

		public async Task<bool> IsAllowedIdAsync(int placeId, Guid userId)
		{
			bool result = await dbContext.Places
				.Where(p => p.Location.UserId == userId)
				.AnyAsync(p => p.Id == placeId);

			return result;
		}
	}
}
