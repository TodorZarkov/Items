namespace Items.Data.Configurations
{
	using Items.Common.Enums;
	using Items.Data.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class ItemEntityConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder
                .HasOne(e => e.Owner)
                .WithMany(e => e.Items)
                .HasForeignKey(e => e.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Location)
                .WithMany(e => e.Items)
                .HasForeignKey(e => e.LocationId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Place)
                .WithMany(e => e.Items)
                .HasForeignKey(e => e.PlaceId)
                .OnDelete(DeleteBehavior.Restrict);

             builder
                .HasOne(e => e.AcquireDocument)
                .WithMany(e => e.Items)
                .HasForeignKey(e => e.DocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder
                .HasOne(e => e.Unit)
                .WithMany()
                .HasForeignKey(e => e.UnitId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(i => i.Currency)
                .WithMany()
                .HasForeignKey(i => i.CurrencyId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(i => i.ItemVisibility)
                .WithOne(iv => iv.Item)
                .OnDelete(DeleteBehavior.Restrict);
            
            builder
                .HasMany(i => i.Contracts)
                .WithOne(c => c.Item)
                .HasForeignKey(c => c.ItemId)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasMany(i => i.ItemPictures)
                .WithOne(f => f.Item)
                .HasForeignKey(f => f.ItemId)
                .OnDelete(DeleteBehavior.Restrict);

            //builder
            //    .HasData(GenerateItems());
        }

   //     private Item[] GenerateItems()
   //     {
   //         List<Item> items = new List<Item>();

   //         Item item = new Item
   //         {
   //             Id = Guid.Parse("70AB6375-3DA7-41CB-B80C-DCEE2BA4FBBB"),
   //             OwnerId = Guid.Parse("7BEE3220-A1A1-4502-EFEA-08DB9037BC59"),//pesho
   //             ItemVisibilityId = Guid.Parse("8D725141-2B5A-468F-9E1E-61AB0C7F8F5E"),
   //             Name = "Ford Mustang Mach1 1973",
   //             Quantity = 1m,
   //             UnitId = 1,//pcs
   //             Description = "The Ford Mustang Mach 1 is a performance-oriented option package[1] of the Ford Mustang muscle car, originally introduced in August 1968 for the 1969 model year. It was available until 1978, returned briefly in 2003, 2004, and most recently in 2021.\r\n\r\nAs part of a Ford heritage program, the Mach 1 package returned in 2003 as a high-performance version of the New Edge platform. Visual connections to the 1969 model were integrated into the design to pay homage to the original. This generation of the Mach 1 was discontinued after the 2004 model year, with the introduction of the fifth generation Mustang.\r\n\r\nFord first used the name \"Mach 1\" in its 1969 display of a concept called the \"Levacar Mach I\" at the Ford Rotunda. This concept vehicle used a cushion of air as propulsion on a circular dais. ",
   //             AcquiredPrice = 60m,
   //             AcquiredDate = DateTime.Parse("10-10-2022"),
   //             //ItemCategory - toys, cars
   //             PlaceId = 1,
   //             LocationId = Guid.Parse("F9182575-B31F-4D24-BB44-17A062DFE6FE"),
                
   //             CurrencyId = 1,

				
			//	StartSell = DateTime.Parse("12-12-2023"),
   //             EndSell = DateTime.Parse("01-08-2024"),
   //             CurrentPrice = 55m,
   //             IsAuction = true,

			//	//todo: set predefined MainPictureId
			//    OnRotation = true,
   //             OnRotationNow = false
   //         };
   //         items.Add(item);
            
   //         item = new Item
   //         {
   //             Id = Guid.Parse("E4D2697E-8EDF-49F5-BAC0-BC76DFBB43EE"),
   //             Name = "Toyota Rav 4",
			//	Description = "Very cool small SUV",
			//	AcquiredPrice = 10m,
			//	AcquiredDate = DateTime.Parse("12-10-2022"),
				



			//	OwnerId = Guid.Parse("7BEE3220-A1A1-4502-EFEA-08DB9037BC59"),//pesho
   //             LocationId = Guid.Parse("F9182575-B31F-4D24-BB44-17A062DFE6FE"), //pesho's location


   //             ItemVisibilityId = Guid.Parse("A78C2EDA-79CB-4ACC-A7E4-92E0B45E20EB"),
   //             Quantity = 1m,
   //             UnitId = 1,//pcs
   //             //ItemCategory - toys, cars
   //             PlaceId = 1,
   //             CurrencyId = 1,

                
   //             StartSell = DateTime.Parse("11-11-2023"),
   //             EndSell = DateTime.Parse("01-08-2024"),
   //             CurrentPrice = 55m,

			//	//todo: set predefined MainPictureId
			//	OnRotation = true,
   //             OnRotationNow = false
   //         };
   //         items.Add(item);

			//item = new Item
			//{
			//	Id = Guid.Parse("EA486471-25CA-40C5-BDCE-C7C4157EB1B0"),
			//	Name = "Trabant",
			//	Description = "Old Cardboard Vehicle from GDR",
			//	AcquiredPrice = 11m,
			//	AcquiredDate = DateTime.Parse("12-10-2022"),
				



			//	OwnerId = Guid.Parse("7BEE3220-A1A1-4502-EFEA-08DB9037BC59"),//pesho
			//	LocationId = Guid.Parse("F9182575-B31F-4D24-BB44-17A062DFE6FE"), //pesho's location


			//	ItemVisibilityId = Guid.Parse("0FB06C25-8E6F-4FD2-A1D9-3CEBB4621D2E"),
			//	Quantity = 1m,
			//	UnitId = 1,//pcs
			//			   //ItemCategory - toys, cars
			//	PlaceId = 1,
			//	CurrencyId = 1,

                
   //             StartSell = DateTime.Parse("10-10-2023"),
   //             EndSell = DateTime.Parse("01-08-2024"),
   //             CurrentPrice = 55m,

			//	//todo: set predefined MainPictureId
			//	OnRotation = true,
   //             OnRotationNow = false
   //         };
			//items.Add(item);

			//item = new Item
   //         {
   //             Id = Guid.Parse("2AA8B934-59F3-473B-842E-3DF2A3590B92"),
   //             Name = "1997 Porsche 911 Carrera, Red",
			//	Description = "The Porsche 911 (pronounced Nine Eleven or in German: Neunelf) is a two-door 2+2 high performance rear-engined sports car introduced in September 1964 by Porsche AG of Stuttgart, Germany. It has a rear-mounted flat-six engine and originally a torsion bar suspension. The car has been continuously enhanced through the years but the basic concept has remained unchanged.[1] The engines were air-cooled until the introduction of the 996 series in 1998.[",
			//	AcquiredPrice = 22m,
			//	AcquiredDate = DateTime.Parse("12-11-2020"),
				



			//	OwnerId = Guid.Parse("7BEE3220-A1A1-4502-EFEA-08DB9037BC59"),//pesho
   //             LocationId = Guid.Parse("F9182575-B31F-4D24-BB44-17A062DFE6FE"), //pesho's location


   //             ItemVisibilityId = Guid.Parse("A33DD8ED-4619-4D18-A25C-2BB25B7BB456"),
   //             Quantity = 1m,
   //             UnitId = 1,//pcs
   //             //ItemCategory - toys, cars
   //             PlaceId = 1,
   //             CurrencyId = 1,
			//	//todo: set predefined MainPictureId
			//	OnRotation = true,
   //             OnRotationNow = false
   //         };
   //         items.Add(item);
            
			//item = new Item
   //         {
   //             Id = Guid.Parse("7EC3D946-D2EF-4D54-A98E-00EA2B2E8B45"),
   //             Name = "Chevrolet Camaro",
			//	Description = "Hollywood Rides 1:24 Scale 2006",
			//	AcquiredPrice = 23m,
			//	AcquiredDate = DateTime.Parse("12-11-2020"),
				



			//	OwnerId = Guid.Parse("7BEE3220-A1A1-4502-EFEA-08DB9037BC59"),//pesho
   //             LocationId = Guid.Parse("F9182575-B31F-4D24-BB44-17A062DFE6FE"), //pesho's location


   //             ItemVisibilityId = Guid.Parse("D009129E-5655-4CD2-BA67-114E2E792B8C"),
   //             Quantity = 1m,
   //             UnitId = 1,//pcs
   //             //ItemCategory - toys, cars
   //             PlaceId = 2,//pesho's
   //             CurrencyId = 1,
			//	//todo: set predefined MainPictureId
			//	OnRotation = true,
   //             OnRotationNow = false
   //         };
   //         items.Add(item);
            
			//item = new Item
   //         {
   //             Id = Guid.Parse("EA9141C8-8C5B-4126-9A30-7A82796E922C"),
   //             Name = "Land Rover Discovery",
			//	Description = "Brown - Welly 24008 - 1/24 scale",
			//	AcquiredPrice = 110m,
			//	AcquiredDate = DateTime.Parse("12-12-2021"),

				
			//	StartSell = DateTime.Parse("09-09-2023"),
			//	EndSell = DateTime.Parse("01-08-2024"),
   //             CurrentPrice = 55m,
			//	IsAuction = true,


			//	OwnerId = Guid.Parse("8B5B3B04-BF70-4018-FFBF-08DB913996C1"),//stamat
   //             LocationId = Guid.Parse("6E1F7BE8-13DC-4C6B-BB59-D6EE7CEC35D8"), //stamat's location
   //             PlaceId = 3,//stamat's


   //             ItemVisibilityId = Guid.Parse("C0BBCABF-5C24-4CA6-86BC-ECA11AE46EB8"),
   //             Quantity = 1m,
   //             UnitId = 1,//pcs
   //             //ItemCategory - toys, cars
   //             CurrencyId = 1,
			//	//todo: set predefined MainPictureId
			//	OnRotation = true,
   //             OnRotationNow = false
   //         };
   //         items.Add(item);
            
			//item = new Item
   //         {
   //             Id = Guid.Parse("CC1A92FF-E773-4D37-8D66-DDB31AB612B2"),
   //             Name = "Puzzle Cars",
			//	Description = "Puzzle from cars movie. 500pcs",
			//	AcquiredPrice = 8m,
			//	AcquiredDate = DateTime.Parse("12-12-2021"),


				
			//	StartSell = DateTime.Parse("08-08-2023"),
			//	EndSell = DateTime.Parse("01-08-2024"),
   //             CurrentPrice = 55m,

			//	OwnerId = Guid.Parse("8B5B3B04-BF70-4018-FFBF-08DB913996C1"),//stamat
			//	LocationId = Guid.Parse("6E1F7BE8-13DC-4C6B-BB59-D6EE7CEC35D8"), //stamat's location
			//	PlaceId = 4,//stamat's


   //             ItemVisibilityId = Guid.Parse("61C89A18-8BDA-4D12-9A70-CDB17AEDD752"),
   //             Quantity = 1m,
   //             UnitId = 1,//pcs
   //             //ItemCategory - toys, puzzles, cars
   //             CurrencyId = 1,
			//	//todo: set predefined MainPictureId
			//	OnRotation = true,
   //             OnRotationNow = false
   //         };
   //         items.Add(item);
            
			//item = new Item
   //         {
   //             Id = Guid.Parse("A0F0C44B-1BA4-484D-9C36-498579B61D37"),
   //             Name = "puzzle vehicles",
			//	Description = "Hape knob puzzle vehicles",
			//	AcquiredPrice = 9m,
			//	AcquiredDate = DateTime.Parse("12-12-2021"),


			//	OwnerId = Guid.Parse("8B5B3B04-BF70-4018-FFBF-08DB913996C1"),//stamat
   //             LocationId = Guid.Parse("6E1F7BE8-13DC-4C6B-BB59-D6EE7CEC35D8"), //stamat's location
   //             PlaceId = 4,//stamat's


   //             ItemVisibilityId = Guid.Parse("CBD7BD12-AA21-4E33-95CF-FD9C342DB010"),
   //             Quantity = 1m,
   //             UnitId = 1,//pcs
   //             //ItemCategory - toys, puzzles, cars
   //             CurrencyId = 1,
			//	//todo: set predefined MainPictureId
			//	OnRotation = true,
   //             OnRotationNow = false
   //         };
   //         items.Add(item);
            
			//item = new Item
   //         {
   //             Id = Guid.Parse("A676AF29-2FD2-4E17-918D-73EC948CDC73"),
   //             Name = "Puzzle Cadillac",
			//	AcquiredPrice = 50m,
			//	AcquiredDate = DateTime.Parse("02-08-2022"),
				



			//	OwnerId = Guid.Parse("8B5B3B04-BF70-4018-FFBF-08DB913996C1"),//stamat
   //             LocationId = Guid.Parse("6E1F7BE8-13DC-4C6B-BB59-D6EE7CEC35D8"), //stamat's location
   //             PlaceId = 4,//stamat's


   //             ItemVisibilityId = Guid.Parse("49ABFA42-69F7-4240-A2EF-4E1B3EF7C16C"),
   //             Quantity = 1m,
   //             UnitId = 1,//pcs
   //             //ItemCategory - toys, puzzles, cars
   //             CurrencyId = 1,
			//	//todo: set predefined MainPictureId
			//	OnRotation = true,
   //             OnRotationNow = false
   //         };
   //         items.Add(item);


   //         return items.ToArray();
   //     }
    }
}
