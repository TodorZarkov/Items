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
	}
}
