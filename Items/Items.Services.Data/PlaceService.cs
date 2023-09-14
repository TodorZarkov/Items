namespace Items.Services.Data
{
	using Items.Data;
	using Items.Data.Models;
	using Items.Services.Data.Interfaces;
	using Items.Web.ViewModels.Base;
	using Items.Web.ViewModels.Place;
	using static Items.Common.GeneralConstants;

	using AutoMapper;

	using Microsoft.EntityFrameworkCore;

	using System;
	using System.Collections.Generic;
	using System.Threading.Tasks;
	using Items.Services.Data.Models.Place;
	using Items.Common.Enums;
	using Items.Services.Data.Models.Location;

	public class PlaceService : IPlaceService
	{
		private readonly ItemsDbContext dbContext;
		private readonly IMapper mapper;

		public PlaceService(ItemsDbContext dbContext, IMapper mapper)
		{
			this.dbContext = dbContext;
			this.mapper = mapper;
		}

		public async Task<AllPlaceServiceModel> AllAsync(Guid userId, QueryFilterModel? queryModel = null)
		{
			var placeQuery = dbContext.Places
				.AsQueryable()
				.AsNoTracking()
				.Include(p => p.Location)
				.Where(p => p.Location.UserId == userId);

			string? searchTerm = queryModel?.SearchTerm;
			if (!string.IsNullOrEmpty(searchTerm))
			{
				placeQuery = placeQuery

					.Where(p => p.Name.ToLower().Contains(searchTerm.ToLower())
							|| (p.Description != null && p.Description.ToLower().Contains(searchTerm.ToLower()))
							|| p.Location.Name.ToLower().Contains(searchTerm.ToLower())
					);
			}

			int[]? categoryIds = queryModel?.CategoryIds;
			if (categoryIds != null && categoryIds.Length != 0)
			{
				placeQuery = placeQuery
					.Where(p => p.Items
									.Where(i => !i.Deleted)
									.Any(i => i.ItemsCategories
										.Any(ic => categoryIds.Contains(ic.CategoryId))));
			}

			Sorting? sorting = queryModel?.SortBy;
			if (sorting != null)
			{
				if (sorting == Sorting.Name)
				{
					placeQuery = placeQuery
						.OrderBy(p => p.Name.ToLower());
				}
				else if (sorting == Sorting.Country)
				{
					placeQuery = placeQuery
						.OrderBy(p => p.Location.Country);
				}
				else if (sorting == Sorting.Town)
				{
					placeQuery = placeQuery
						.OrderBy(p => p.Location.Town)
						.ThenBy(p => p.Name);
				}


			}

			var totalPlacesCount = await placeQuery.CountAsync();

			int currentPage = queryModel?.CurrentPage ?? DefaultCurrentPage;
			int hitsPerPage = queryModel?.HitsPerPage ?? DefaultHitsPerPage;

			placeQuery = placeQuery
				.Skip((currentPage - 1) * hitsPerPage)
				.Take(hitsPerPage);

			IEnumerable<AllPlaceViewModel> places = await placeQuery
				.Select(p => new AllPlaceViewModel
				{
					Id = p.Id,
					Name = p.Name,
					Location = p.Location.Name,
					Description = p.Description != null ? p.Description : "Not Added.",
					Items = p.Items.Count(i => !i.Deleted),
				})
				.ToArrayAsync();



			AllPlaceServiceModel result = new AllPlaceServiceModel()
			{
				Places = places,
				TotalPlacesCount = totalPlacesCount
			};


			return result;
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
