namespace Items.Services.Data
{
    using Items.Data;
	using Items.Services.Data.Interfaces;
	using Items.Web.ViewModels.Location;
    using Microsoft.EntityFrameworkCore;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class LocationService : ILocationService
    {
        private readonly ItemsDbContext dbContext;
        public LocationService(ItemsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<AllLocationViewModel>> AllAsync(Guid userId)
        {
            var locations = await dbContext.Locations
                .Where(l => l.UserId == userId)
                .OrderBy(l => l.Name)
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

            return locations;
        }
    }
}
