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
                .Select(l => new AllLocationViewModel
                {
                    Id = l.Id,
                    Name = l.Name,
                    Description = l.Description,
                    GeoLocation = l.GeoLocation != null ? l.GeoLocation.ToString() : null,
                    Border = l.Border != null ? l.Border.ToString() : null,
                    Country = l.Country,
                    Town = l.Town,
                    Address = l.Address,
                    Places = l.Places.Count,
                    Items = l.Items.Count,
                    Visibility = new LocationVisibilityViewModel
                    {
                        Address = l.LocationVisibility.Address.ToString(),
                        Border = l.LocationVisibility.Border.ToString(),
                        Country = l.LocationVisibility.Country.ToString(),
                        Description = l.LocationVisibility.Description.ToString(),
                        GeoLocation = l.LocationVisibility.GeoLocation.ToString(),
                        Name = l.LocationVisibility.Name.ToString(),
                        Town = l.LocationVisibility.Town.ToString(),
                        Id = l.LocationVisibility.Id
                    }
                })
                .ToArrayAsync();

            return locations;
        }
    }
}
