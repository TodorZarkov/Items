namespace Items.Data.Configurations
{
    using Items.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class LocationEntityConfiguration : IEntityTypeConfiguration<Location>
    {
        public void Configure(EntityTypeBuilder<Location> builder)
        {
            builder
                .HasOne(e => e.User)
                .WithMany(e => e.Locations)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(e => e.Places)
                .WithOne(e => e.Location)
                .HasForeignKey(e => e.LocationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.LocationVisibility)
                .WithOne(e => e.Location)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasData(GenerateLocations());
        }

        private Location[] GenerateLocations()
        {
            List<Location> locations = new List<Location>();

            Location location = new Location
            {
                Id = Guid.Parse("F9182575-B31F-4D24-BB44-17A062DFE6FE"),
                Name = "Вкъщи",
                LocationVisibilityId = Guid.Parse("BCF0602C-9F4D-4CA0-8403-460E9DBD6A75"),
                UserId = Guid.Parse("7BEE3220-A1A1-4502-EFEA-08DB9037BC59"),//pesho's id
                Country = "Bulgaria",
                Town = "Sofia",
                Address = "bul. Slivnitsa 8"
            };
            locations.Add(location);
            
            location = new Location
            {
                Id = Guid.Parse("6E1F7BE8-13DC-4C6B-BB59-D6EE7CEC35D8"),
                Name = "У нас",
                LocationVisibilityId = Guid.Parse("21BB8F90-6E2A-4464-B97F-D051E697C278"),
                UserId = Guid.Parse("8B5B3B04-BF70-4018-FFBF-08DB913996C1"),//stamat's id
                Country = "Bulgaria",
                Town = "Sofia",
                Address = "bul. Slivnitsa 9"
            };
            locations.Add(location);

            return locations.ToArray();
        }
    }
}
