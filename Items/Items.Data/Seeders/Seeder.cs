namespace Items.Data.Seeders
{
    using Microsoft.EntityFrameworkCore;

    public static class Seeder 
    {
       
        public static ModelBuilder Seed(this ModelBuilder builder)
        {

            builder
                .SeedUsers()
                .SeedRoles()
                .SeedUsersRoles()
                .SeedCategories()
                .SeedCurrencies()
                .SeedUnits()
                .SeedLocations()
                .SeedLocationsVisibilities()
                .SeedPlaces()

                //.SeedItems()
                //.SeedItemsCategories()
                //.SeedItemsVisibilities()
                //.SeedOffers()

                .SeedTicketStatuses()
                .SeedTicketTypes();


            return builder;
        }
        
    }
}
