namespace Items.Services.Data
{
	using Items.Common.Enums;
	using Items.Data;
	using Items.Data.Models;
	using Items.Services.Data.Interfaces;
	using Items.Services.Data.Models.Location;
	using Items.Web.ViewModels.Base;
	using Items.Web.ViewModels.Location;

	using AutoMapper;

	using Microsoft.EntityFrameworkCore;

	using System.Collections.Generic;
	using System.Threading.Tasks;
	using static Items.Common.GeneralConstants;

	public class LocationService : ILocationService
	{
		private readonly ItemsDbContext dbContext;
		private readonly IMapper mapper;

		public LocationService(ItemsDbContext dbContext, IMapper mapper)
		{
			this.dbContext = dbContext;
			this.mapper = mapper;
		}

		public async Task<AllLocationServiceModel> GetAllAsync(
			Guid userId, QueryFilterModel? queryModel = null)
		{
			var locationQuery = dbContext.Locations
				.AsQueryable()
				.AsNoTracking()
				.Where(l => l.UserId == userId);

			string? searchTerm = queryModel?.SearchTerm;
			if (!string.IsNullOrEmpty(searchTerm))
			{
				locationQuery = locationQuery

					.Where(l => l.Name.ToLower().Contains(searchTerm.ToLower())
							|| (l.Description != null && l.Description.ToLower().Contains(searchTerm.ToLower()))
							|| l.Country.ToLower().Contains(searchTerm.ToLower())
							|| (l.Town != null && l.Town.ToLower().Contains(searchTerm.ToLower()))
					);
			}

			int[]? categoryIds = queryModel?.CategoryIds;
			if (categoryIds != null && categoryIds.Length != 0)
			{
				locationQuery = locationQuery
					.Where(l => l.Items
									.Where(i => !i.Deleted)
									.Any(i => i.ItemsCategories
										.Any(ic => categoryIds.Contains(ic.CategoryId))));
			}

			Sorting? sorting = queryModel?.SortBy;
			if (sorting != null)
			{
				if (sorting == Sorting.Name)
				{
					locationQuery = locationQuery
						.OrderBy(l => l.Name.ToLower());
				}
				else if (sorting == Sorting.Country)
				{
					locationQuery = locationQuery
						.OrderBy(l => l.Country);
				}
				else if (sorting == Sorting.Town)
				{
					locationQuery = locationQuery
						.OrderBy(l => l.Town)
						.ThenBy(l => l.Name);
				}


			}

			var totalLocationsCount = await locationQuery.CountAsync();

			int currentPage = queryModel?.CurrentPage ?? DefaultCurrentPage;
			int hitsPerPage = queryModel?.HitsPerPage ?? DefaultHitsPerPage;

			locationQuery = locationQuery
				.Skip((currentPage - 1) * hitsPerPage)
				.Take(hitsPerPage);

			var locations = await locationQuery
				.Select(l => new AllLocationViewModel
				{
					Id = l.Id,
					Name = l.Name,
					Description = l.Description != null ? l.Description : "Not Added",
					GeoLocation = l.GeoLocation != null ? l.GeoLocation.ToString() : "Not Added",
					Border = l.Border != null ? l.Border.ToString() : "Not Added",
					Country = l.Country,
					Town = l.Town,
					Address = l.Address,
					Places = l.Places.Count,
					Items = l.Items.Count,
					Visibility = new LocationVisibilityViewModel
					{
						Address = l.LocationVisibility.Address,
						Border = l.LocationVisibility.Border,
						Country = l.LocationVisibility.Country,
						Description = l.LocationVisibility.Description,
						GeoLocation = l.LocationVisibility.GeoLocation,
						Name = l.LocationVisibility.Name,
						Town = l.LocationVisibility.Town,
						Id = l.LocationVisibility.Id
					}
				})
				.ToArrayAsync();

			AllLocationServiceModel result = new AllLocationServiceModel()
			{
				Locations = locations,
				TotalLocationsCount = totalLocationsCount
			};


			return result;
		}

		public async Task<LocationFormModel> GetByIdAsync(Guid id)
		{
			Location location = await dbContext.Locations
				.Include(l => l.LocationVisibility)
				.AsNoTracking()
				.SingleAsync(l => l.Id == id);

			LocationFormModel model = mapper.Map<LocationFormModel>(location);

			return model;
		}

		public async Task<IEnumerable<ForSelectLocationViewModel>> AllForSelectAsync(Guid userId)
		{
			IEnumerable<ForSelectLocationViewModel> locations = await dbContext.Locations
				.AsNoTracking()
				.Where(l => l.UserId == userId)
				.OrderBy(l => l.Name)
				.Select(l => new ForSelectLocationViewModel
				{
					LocationId = l.Id,
					LocationName = l.Name,
				})
				.ToArrayAsync();

			return locations;
		}

		public async Task<bool> IsAllowedIdAsync(Guid locationId, Guid userId)
		{
			bool result = await dbContext.Locations
				.Where(l => l.UserId == userId)
				.AnyAsync(l => l.Id == locationId);

			return result;
		}

		public async Task<Guid> CreateAsync(LocationFormModel model, Guid userId)
		{
			Location location = new Location()
			{
				UserId = userId,
				Name = model.Name,
				Description = model.Description,
				GeoLocation = null,
				Border = null,
				Country = model.Country,
				Town = model.Town,
				Address = model.Address,
				LocationVisibility = new LocationVisibility()
				{
					Name = model.LocationVisibility.Name,
					Description = model.LocationVisibility.Description,
					GeoLocation = model.LocationVisibility.GeoLocation,
					Border = model.LocationVisibility.Border,
					Country = model.LocationVisibility.Country,
					Town = model.LocationVisibility.Town,
					Address = model.LocationVisibility.Address
				}
			};

			dbContext.Locations.Add(location);

			await dbContext.SaveChangesAsync();

			return location.Id;
		}

		public async Task EditAsync(LocationFormModel model, Guid id)
		{
			Location location = await dbContext.Locations
				.Include(l => l.LocationVisibility)
				.SingleAsync(l => l.Id == id);

			mapper.Map<LocationFormModel, Location>(model, location);

			await dbContext.SaveChangesAsync();
		}

		public async Task<bool> IsEmptyAsync(Guid id)
		{
			bool hasPlaces = await dbContext.Locations
				.AnyAsync(l => l.Id == id && l.Places.Any());

			bool hasItems = await dbContext.Locations
				.AnyAsync(l => l.Id == id && l.Items.Any());

			return !hasPlaces && !hasItems;
		}

		public async Task Delete(Guid id)
		{
			Location location = await dbContext.Locations
				.SingleAsync(l=> l.Id == id);

			dbContext.Locations.Remove(location);

			await dbContext.SaveChangesAsync();
		}
	}
}
