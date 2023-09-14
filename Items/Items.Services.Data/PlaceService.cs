namespace Items.Services.Data
{
	using Items.Data;
	using Items.Data.Models;
	using Items.Services.Data.Interfaces;
	using Items.Web.ViewModels.Base;
	using Items.Web.ViewModels.Place;

	using AutoMapper;

	using Microsoft.EntityFrameworkCore;

	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public class PlaceService : IPlaceService
	{
		private readonly ItemsDbContext dbContext;
		private readonly IMapper mapper;

		public PlaceService(ItemsDbContext dbContext, IMapper mapper)
		{
			this.dbContext = dbContext;
			this.mapper = mapper;
		}

		public async Task<IEnumerable<AllPlaceViewModel>> AllAsync(Guid userId, QueryFilterModel? placeQuery = null)
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
					Items = p.Items.Count(i => !i.Deleted),
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
					LocationName = p.Location.Name,
					ExtendedPlaceName = p.Name + " (" + p.Location.Name + ")"
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

		public async Task<PlaceFormModel> GetByIdAsync(int id)
		{
			Place place = await dbContext.Places
				.SingleAsync(p => p.Id == id);

			PlaceFormModel model = mapper.Map<PlaceFormModel>(place);

			return model;
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

		public async Task<bool> HasItems(int id)
		{
			Place place = await dbContext.Places
				.Include(p => p.Items)
				.SingleAsync(p => p.Id == id);

			return place.Items.Count > 0;
		}


		public async Task<int> CreateAsync(PlaceFormModel model)
		{
			Place place = mapper.Map<Place>(model);

			dbContext.Places.Add(place);
			await dbContext.SaveChangesAsync();

			return place.Id;
		}

		public async Task EditAsync(int id, PlaceFormModel model)
		{
			Place place = await dbContext.Places
				.Include(p => p.Items)
				.Include(p => p.Location)
				.SingleAsync(p => p.Id == id);

			if (place.LocationId != model.LocationId)
			{
				Guid oldLocationId = place.LocationId;
				Guid newLocationId = model.LocationId;
				Item[] itemsToMove = await dbContext.Items
					.Where(i => i.LocationId == oldLocationId &&
								i.PlaceId == id)
					.ToArrayAsync();

				foreach (Item item in itemsToMove)
				{
					item.LocationId = newLocationId;
				}
			}

			mapper.Map<PlaceFormModel, Place>(model, place);

			await dbContext.SaveChangesAsync();

		}

		public async Task DeleteAsync(int id)
		{
			Place place = await dbContext.Places
				.SingleAsync(p => p.Id == id);

			dbContext.Places.Remove(place);

			await dbContext.SaveChangesAsync();
		}

		
	}
}
