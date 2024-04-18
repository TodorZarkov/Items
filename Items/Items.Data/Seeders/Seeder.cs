namespace Items.Data.Seeders
{
    using Items.Data.Models;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.EntityFrameworkCore;

    using System;
    using System.Collections.Generic;

    public static class Seeder 
    {
       
        public static ModelBuilder Seed(this ModelBuilder builder)
        {

            builder
                .SeedUsers()
                .SeedCategories()
                .SeedCurrencies()
                .SeedItemsCategories()
                .SeedItems()
                .SeedItemsVisibilities()
                .SeedLocations()
                .SeedLocationsVisibilities()
                .SeedOffers()
                .SeedPlaces()
                .SeedRoles()
                .SeedUnits()
                .SeedUsersRoles()

                .SeedTicketStatuses()
                .SeedTicketTypes();


            return builder;
        }
        
    }
}
