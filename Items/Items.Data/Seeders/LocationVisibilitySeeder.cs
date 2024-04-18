namespace Items.Data.Seeders
{
    using Items.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public static class LocationVisibilitySeeder
    {
        public static ModelBuilder SeedLocationsVisibilities(this ModelBuilder builder)
        {
            builder
                .Entity<LocationVisibility>()
                .HasData(GenerateLocationVisibilities());

            return builder;
        }


        private static LocationVisibility[] GenerateLocationVisibilities()
        {
            List<LocationVisibility> locationVisibilities = new List<LocationVisibility>();

            LocationVisibility locationVisibility = new LocationVisibility
            {
                Id = Guid.Parse("BCF0602C-9F4D-4CA0-8403-460E9DBD6A75")
            };
            locationVisibilities.Add(locationVisibility);

            locationVisibility = new LocationVisibility
            {
                Id = Guid.Parse("21BB8F90-6E2A-4464-B97F-D051E697C278")
            };
            locationVisibilities.Add(locationVisibility);



            return locationVisibilities.ToArray();
        }
    }
}
