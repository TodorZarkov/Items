namespace Items.Data.Seeders
{
    using Items.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public static class PlaceSeeder
    {
        public static ModelBuilder SeedPlaces(this ModelBuilder builder)
        {
            builder
                .Entity<Place>()
                .HasData(GeneratePlaces());

            return builder;
        }


        private static Place[] GeneratePlaces()
        {
            List<Place> places = new List<Place>();

            Place place = new Place
            {
                Id = 1,
                Name = "My Room, Cabinet,  Drawer 5",
                LocationId = Guid.Parse("F9182575-B31F-4D24-BB44-17A062DFE6FE"),//pesho's location
            };
            places.Add(place);

            place = new Place
            {
                Id = 2,
                Name = "My Room, Cabinet,  Drawer 6",
                LocationId = Guid.Parse("F9182575-B31F-4D24-BB44-17A062DFE6FE"),//pesho's location
            };
            places.Add(place);

            place = new Place
            {
                Id = 3,
                Name = "My Room, Desk,  Drawer 1",
                LocationId = Guid.Parse("6E1F7BE8-13DC-4C6B-BB59-D6EE7CEC35D8"),//stamat's location
            };
            places.Add(place);

            place = new Place
            {
                Id = 4,
                Name = "My Room, Desk,  Drawer 2",
                LocationId = Guid.Parse("6E1F7BE8-13DC-4C6B-BB59-D6EE7CEC35D8"),//stamat's location
            };
            places.Add(place);

            return places.ToArray();
        }
    }
}
