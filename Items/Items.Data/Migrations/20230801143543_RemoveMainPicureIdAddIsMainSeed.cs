using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Items.Data.Migrations
{
    public partial class RemoveMainPicureIdAddIsMainSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Pictures_MainPictureId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_MainPictureId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "MainPictureId",
                table: "Items");

            migrationBuilder.AddColumn<bool>(
                name: "IsMain",
                table: "Pictures",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<bool>(
                name: "IsAuction",
                table: "Items",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.InsertData(
                table: "ItemVisibilities",
                columns: new[] { "Id", "AcquireDocument", "AcquiredDate", "AcquiredPrice", "AddedOn", "CurrentPrice", "Description", "Location", "Offers", "Owner", "Quantity" },
                values: new object[,]
                {
                    { new Guid("0fb06c25-8e6f-4fd2-a1d9-3cebb4621d2e"), 1, 1, 1, 1, 2, 2, 1, 1, 1, 1 },
                    { new Guid("49abfa42-69f7-4240-a2ef-4e1b3ef7c16c"), 1, 1, 1, 1, 2, 2, 1, 1, 1, 1 },
                    { new Guid("61c89a18-8bda-4d12-9a70-cdb17aedd752"), 1, 1, 1, 1, 2, 2, 1, 1, 1, 1 },
                    { new Guid("8d725141-2b5a-468f-9e1e-61ab0c7f8f5e"), 1, 1, 1, 1, 2, 2, 1, 1, 1, 1 },
                    { new Guid("a33dd8ed-4619-4d18-a25c-2bb25b7bb456"), 1, 1, 1, 1, 2, 2, 1, 1, 1, 1 },
                    { new Guid("a78c2eda-79cb-4acc-a7e4-92e0b45e20eb"), 1, 1, 1, 1, 2, 2, 1, 1, 1, 1 },
                    { new Guid("c0bbcabf-5c24-4ca6-86bc-eca11ae46eb8"), 1, 1, 1, 1, 2, 2, 1, 1, 1, 1 },
                    { new Guid("cbd7bd12-aa21-4e33-95cf-fd9c342db010"), 1, 1, 1, 1, 2, 2, 1, 1, 1, 1 },
                    { new Guid("d009129e-5655-4cd2-ba67-114e2e792b8c"), 1, 1, 1, 1, 2, 2, 1, 1, 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "LocationVisibilities",
                columns: new[] { "Id", "Address", "Border", "Country", "Description", "GeoLocation", "Name", "Town" },
                values: new object[,]
                {
                    { new Guid("21bb8f90-6e2a-4464-b97f-d051e697c278"), 1, 1, 2, 1, 1, 1, 2 },
                    { new Guid("bcf0602c-9f4d-4ca0-8403-460e9dbd6a75"), 1, 1, 2, 1, 1, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "Border", "Country", "Description", "GeoLocation", "LocationVisibilityId", "Name", "Town", "UserId" },
                values: new object[] { new Guid("6e1f7be8-13dc-4c6b-bb59-d6ee7cec35d8"), "bul. Slivnitsa 9", null, "Bulgaria", null, null, new Guid("21bb8f90-6e2a-4464-b97f-d051e697c278"), "У нас", "Sofia", new Guid("8b5b3b04-bf70-4018-ffbf-08db913996c1") });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "Border", "Country", "Description", "GeoLocation", "LocationVisibilityId", "Name", "Town", "UserId" },
                values: new object[] { new Guid("f9182575-b31f-4d24-bb44-17a062dfe6fe"), "bul. Slivnitsa 8", null, "Bulgaria", null, null, new Guid("bcf0602c-9f4d-4ca0-8403-460e9dbd6a75"), "Вкъщи", "Sofia", new Guid("7bee3220-a1a1-4502-efea-08db9037bc59") });

            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "Id", "Description", "LocationId", "Name" },
                values: new object[,]
                {
                    { 1, null, new Guid("f9182575-b31f-4d24-bb44-17a062dfe6fe"), "My Room, Cabinet,  Drawer 5" },
                    { 2, null, new Guid("f9182575-b31f-4d24-bb44-17a062dfe6fe"), "My Room, Cabinet,  Drawer 6" },
                    { 3, null, new Guid("6e1f7be8-13dc-4c6b-bb59-d6ee7cec35d8"), "My Room, Desk,  Drawer 1" },
                    { 4, null, new Guid("6e1f7be8-13dc-4c6b-bb59-d6ee7cec35d8"), "My Room, Desk,  Drawer 2" }
                });

            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "Id", "Access", "AcquiredDate", "AcquiredPrice", "AddedOn", "CurrencyId", "CurrentPrice", "Description", "DocumentId", "EndSell", "IsAuction", "ItemVisibilityId", "LocationId", "Name", "OwnerId", "PlaceId", "Quantity", "StartSell", "UnitId" },
                values: new object[,]
                {
                    { new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92"), 1, new DateTime(2020, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 22m, new DateTime(2023, 8, 1, 14, 35, 42, 349, DateTimeKind.Utc).AddTicks(5147), 1, null, "The Porsche 911 (pronounced Nine Eleven or in German: Neunelf) is a two-door 2+2 high performance rear-engined sports car introduced in September 1964 by Porsche AG of Stuttgart, Germany. It has a rear-mounted flat-six engine and originally a torsion bar suspension. The car has been continuously enhanced through the years but the basic concept has remained unchanged.[1] The engines were air-cooled until the introduction of the 996 series in 1998.[", null, null, null, new Guid("a33dd8ed-4619-4d18-a25c-2bb25b7bb456"), new Guid("f9182575-b31f-4d24-bb44-17a062dfe6fe"), "1997 Porsche 911 Carrera, Red", new Guid("7bee3220-a1a1-4502-efea-08db9037bc59"), 1, 1m, null, 1 },
                    { new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"), 1, new DateTime(2022, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 60m, new DateTime(2023, 8, 1, 14, 35, 42, 349, DateTimeKind.Utc).AddTicks(5017), 1, null, "The Ford Mustang Mach 1 is a performance-oriented option package[1] of the Ford Mustang muscle car, originally introduced in August 1968 for the 1969 model year. It was available until 1978, returned briefly in 2003, 2004, and most recently in 2021.\r\n\r\nAs part of a Ford heritage program, the Mach 1 package returned in 2003 as a high-performance version of the New Edge platform. Visual connections to the 1969 model were integrated into the design to pay homage to the original. This generation of the Mach 1 was discontinued after the 2004 model year, with the introduction of the fifth generation Mustang.\r\n\r\nFord first used the name \"Mach 1\" in its 1969 display of a concept called the \"Levacar Mach I\" at the Ford Rotunda. This concept vehicle used a cushion of air as propulsion on a circular dais. ", null, null, null, new Guid("8d725141-2b5a-468f-9e1e-61ab0c7f8f5e"), new Guid("f9182575-b31f-4d24-bb44-17a062dfe6fe"), "Ford Mustang Mach1 1973", new Guid("7bee3220-a1a1-4502-efea-08db9037bc59"), 1, 1m, null, 1 },
                    { new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45"), 1, new DateTime(2020, 12, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), 23m, new DateTime(2023, 8, 1, 14, 35, 42, 349, DateTimeKind.Utc).AddTicks(5159), 1, null, "Hollywood Rides 1:24 Scale 2006", null, null, null, new Guid("d009129e-5655-4cd2-ba67-114e2e792b8c"), new Guid("f9182575-b31f-4d24-bb44-17a062dfe6fe"), "Chevrolet Camaro", new Guid("7bee3220-a1a1-4502-efea-08db9037bc59"), 2, 1m, null, 1 },
                    { new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37"), 1, new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 9m, new DateTime(2023, 8, 1, 14, 35, 42, 349, DateTimeKind.Utc).AddTicks(5203), 1, null, "Hape knob puzzle vehicles", null, null, null, new Guid("cbd7bd12-aa21-4e33-95cf-fd9c342db010"), new Guid("6e1f7be8-13dc-4c6b-bb59-d6ee7cec35d8"), "puzzle vehicles", new Guid("8b5b3b04-bf70-4018-ffbf-08db913996c1"), 4, 1m, null, 1 },
                    { new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73"), 1, new DateTime(2022, 2, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 50m, new DateTime(2023, 8, 1, 14, 35, 42, 349, DateTimeKind.Utc).AddTicks(5213), 1, null, null, null, null, null, new Guid("49abfa42-69f7-4240-a2ef-4e1b3ef7c16c"), new Guid("6e1f7be8-13dc-4c6b-bb59-d6ee7cec35d8"), "Puzzle Cadillac", new Guid("8b5b3b04-bf70-4018-ffbf-08db913996c1"), 4, 1m, null, 1 },
                    { new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2"), 1, new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 8m, new DateTime(2023, 8, 1, 14, 35, 42, 349, DateTimeKind.Utc).AddTicks(5181), 1, null, "Puzzle from cars movie. 500pcs", null, null, null, new Guid("61c89a18-8bda-4d12-9a70-cdb17aedd752"), new Guid("6e1f7be8-13dc-4c6b-bb59-d6ee7cec35d8"), "Puzzle Cars", new Guid("8b5b3b04-bf70-4018-ffbf-08db913996c1"), 4, 1m, null, 1 },
                    { new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"), 1, new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 10m, new DateTime(2023, 8, 1, 14, 35, 42, 349, DateTimeKind.Utc).AddTicks(5123), 1, null, "Very cool small SUV", null, null, null, new Guid("a78c2eda-79cb-4acc-a7e4-92e0b45e20eb"), new Guid("f9182575-b31f-4d24-bb44-17a062dfe6fe"), "Toyota Rav 4", new Guid("7bee3220-a1a1-4502-efea-08db9037bc59"), 1, 1m, null, 1 },
                    { new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"), 1, new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 11m, new DateTime(2023, 8, 1, 14, 35, 42, 349, DateTimeKind.Utc).AddTicks(5136), 1, null, "Old Cardboard Vehicle from GDR", null, null, null, new Guid("0fb06c25-8e6f-4fd2-a1d9-3cebb4621d2e"), new Guid("f9182575-b31f-4d24-bb44-17a062dfe6fe"), "Trabant", new Guid("7bee3220-a1a1-4502-efea-08db9037bc59"), 1, 1m, null, 1 },
                    { new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"), 1, new DateTime(2021, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 110m, new DateTime(2023, 8, 1, 14, 35, 42, 349, DateTimeKind.Utc).AddTicks(5171), 1, null, "Brown - Welly 24008 - 1/24 scale", null, null, null, new Guid("c0bbcabf-5c24-4ca6-86bc-eca11ae46eb8"), new Guid("6e1f7be8-13dc-4c6b-bb59-d6ee7cec35d8"), "Land Rover Discovery", new Guid("8b5b3b04-bf70-4018-ffbf-08db913996c1"), 3, 1m, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "ItemsCategories",
                columns: new[] { "CategoryId", "ItemId" },
                values: new object[,]
                {
                    { 2, new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92") },
                    { 2, new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb") },
                    { 2, new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45") },
                    { 2, new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37") },
                    { 2, new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73") },
                    { 2, new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2") },
                    { 2, new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee") },
                    { 2, new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0") },
                    { 2, new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c") },
                    { 3, new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92") },
                    { 3, new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb") },
                    { 3, new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45") },
                    { 3, new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37") },
                    { 3, new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73") },
                    { 3, new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2") },
                    { 3, new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee") },
                    { 3, new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0") },
                    { 3, new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c") },
                    { 5, new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37") },
                    { 5, new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73") },
                    { 5, new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2") }
                });

            migrationBuilder.InsertData(
                table: "Pictures",
                columns: new[] { "Id", "IsMain", "IsPrivate", "ItemId", "Uri" },
                values: new object[,]
                {
                    { new Guid("0e1db751-83fd-42e8-8c5d-e9d4a96a9a6c"), true, false, new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"), "https://i5.walmartimages.com/asr/cb1717c7-d4b2-483b-91a9-770f3db40076_1.1f5d5f997641b1adb8323d08d95e6bd6.jpeg" },
                    { new Guid("78f32a40-2d8b-47ed-a424-0f757c4bd0fb"), true, false, new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92"), "https://i5.walmartimages.com/asr/0b26c2b4-5459-424c-ae09-364824104c90_1.642441b6196644f95b66202bb6185285.jpeg?odnWidth=1000&odnHeight=1000&odnBg=ffffff" },
                    { new Guid("7c7daf02-3d4e-4d0d-b42a-52f20f5f6206"), true, false, new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37"), "https://www.kids-room.com/WebRoot/KidsroomDE/Shops/Kidsroom/55B8/CACC/36F4/5060/F31B/4DEB/AE1C/138D/BILD3_E6319/IC_IMAGE/en-hape-knob-puzzle-vehicles.jpg" },
                    { new Guid("85a7cd2b-46d8-4c1f-b931-5b2047891d5b"), true, false, new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73"), "https://jigsawpuzzles.online/king-include/uploads1/auto-cadillac-oldtimer-classic-vehicle-chrome-607938272.jpg" },
                    { new Guid("a109510e-b303-479c-b1fe-a9b92967a057"), true, false, new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2"), "http://www.babylonhobbies.com/ebay/pictures/EDU_14862.jpg" },
                    { new Guid("e63087e2-e37a-4e94-8ba8-e4751568d345"), true, false, new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"), "https://i5.walmartimages.com/asr/19fe13d7-ea2e-47f7-8547-202ce8c88717_1.bc800cefd11bb60ebc07ebdd7fac8ff6.jpeg" },
                    { new Guid("f2f7bd16-e413-4735-a550-0ca57628996d"), true, false, new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45"), "https://i5.walmartimages.com/asr/ea368e4c-f0e3-401b-8cff-2344a05955ed_2.de437c99da79acc1cc2bec706fea7ce4.jpeg" },
                    { new Guid("fe43b7c3-8583-4f87-b6b4-8fa522072a17"), true, false, new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"), "https://static2.redcart.pl/templates/images/thumb/10281/800/9999/pl/0/templates/images/products/10281/067a782229f0ab90838b869e943673ca.jpg" },
                    { new Guid("ffb2c420-acca-4346-9e99-0e52d44f9f50"), true, false, new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"), "https://image.pushauction.com/0/0/77191e32-26bc-45d1-b916-1425f6513281/4533eb18-a6eb-4783-b444-aad16f842869.jpg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ItemsCategories",
                keyColumns: new[] { "CategoryId", "ItemId" },
                keyValues: new object[] { 2, new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92") });

            migrationBuilder.DeleteData(
                table: "ItemsCategories",
                keyColumns: new[] { "CategoryId", "ItemId" },
                keyValues: new object[] { 2, new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb") });

            migrationBuilder.DeleteData(
                table: "ItemsCategories",
                keyColumns: new[] { "CategoryId", "ItemId" },
                keyValues: new object[] { 2, new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45") });

            migrationBuilder.DeleteData(
                table: "ItemsCategories",
                keyColumns: new[] { "CategoryId", "ItemId" },
                keyValues: new object[] { 2, new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37") });

            migrationBuilder.DeleteData(
                table: "ItemsCategories",
                keyColumns: new[] { "CategoryId", "ItemId" },
                keyValues: new object[] { 2, new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73") });

            migrationBuilder.DeleteData(
                table: "ItemsCategories",
                keyColumns: new[] { "CategoryId", "ItemId" },
                keyValues: new object[] { 2, new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2") });

            migrationBuilder.DeleteData(
                table: "ItemsCategories",
                keyColumns: new[] { "CategoryId", "ItemId" },
                keyValues: new object[] { 2, new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee") });

            migrationBuilder.DeleteData(
                table: "ItemsCategories",
                keyColumns: new[] { "CategoryId", "ItemId" },
                keyValues: new object[] { 2, new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0") });

            migrationBuilder.DeleteData(
                table: "ItemsCategories",
                keyColumns: new[] { "CategoryId", "ItemId" },
                keyValues: new object[] { 2, new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c") });

            migrationBuilder.DeleteData(
                table: "ItemsCategories",
                keyColumns: new[] { "CategoryId", "ItemId" },
                keyValues: new object[] { 3, new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92") });

            migrationBuilder.DeleteData(
                table: "ItemsCategories",
                keyColumns: new[] { "CategoryId", "ItemId" },
                keyValues: new object[] { 3, new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb") });

            migrationBuilder.DeleteData(
                table: "ItemsCategories",
                keyColumns: new[] { "CategoryId", "ItemId" },
                keyValues: new object[] { 3, new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45") });

            migrationBuilder.DeleteData(
                table: "ItemsCategories",
                keyColumns: new[] { "CategoryId", "ItemId" },
                keyValues: new object[] { 3, new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37") });

            migrationBuilder.DeleteData(
                table: "ItemsCategories",
                keyColumns: new[] { "CategoryId", "ItemId" },
                keyValues: new object[] { 3, new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73") });

            migrationBuilder.DeleteData(
                table: "ItemsCategories",
                keyColumns: new[] { "CategoryId", "ItemId" },
                keyValues: new object[] { 3, new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2") });

            migrationBuilder.DeleteData(
                table: "ItemsCategories",
                keyColumns: new[] { "CategoryId", "ItemId" },
                keyValues: new object[] { 3, new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee") });

            migrationBuilder.DeleteData(
                table: "ItemsCategories",
                keyColumns: new[] { "CategoryId", "ItemId" },
                keyValues: new object[] { 3, new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0") });

            migrationBuilder.DeleteData(
                table: "ItemsCategories",
                keyColumns: new[] { "CategoryId", "ItemId" },
                keyValues: new object[] { 3, new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c") });

            migrationBuilder.DeleteData(
                table: "ItemsCategories",
                keyColumns: new[] { "CategoryId", "ItemId" },
                keyValues: new object[] { 5, new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37") });

            migrationBuilder.DeleteData(
                table: "ItemsCategories",
                keyColumns: new[] { "CategoryId", "ItemId" },
                keyValues: new object[] { 5, new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73") });

            migrationBuilder.DeleteData(
                table: "ItemsCategories",
                keyColumns: new[] { "CategoryId", "ItemId" },
                keyValues: new object[] { 5, new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2") });

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("0e1db751-83fd-42e8-8c5d-e9d4a96a9a6c"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("78f32a40-2d8b-47ed-a424-0f757c4bd0fb"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("7c7daf02-3d4e-4d0d-b42a-52f20f5f6206"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("85a7cd2b-46d8-4c1f-b931-5b2047891d5b"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("a109510e-b303-479c-b1fe-a9b92967a057"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("e63087e2-e37a-4e94-8ba8-e4751568d345"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("f2f7bd16-e413-4735-a550-0ca57628996d"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("fe43b7c3-8583-4f87-b6b4-8fa522072a17"));

            migrationBuilder.DeleteData(
                table: "Pictures",
                keyColumn: "Id",
                keyValue: new Guid("ffb2c420-acca-4346-9e99-0e52d44f9f50"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"));

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"));

            migrationBuilder.DeleteData(
                table: "ItemVisibilities",
                keyColumn: "Id",
                keyValue: new Guid("0fb06c25-8e6f-4fd2-a1d9-3cebb4621d2e"));

            migrationBuilder.DeleteData(
                table: "ItemVisibilities",
                keyColumn: "Id",
                keyValue: new Guid("49abfa42-69f7-4240-a2ef-4e1b3ef7c16c"));

            migrationBuilder.DeleteData(
                table: "ItemVisibilities",
                keyColumn: "Id",
                keyValue: new Guid("61c89a18-8bda-4d12-9a70-cdb17aedd752"));

            migrationBuilder.DeleteData(
                table: "ItemVisibilities",
                keyColumn: "Id",
                keyValue: new Guid("8d725141-2b5a-468f-9e1e-61ab0c7f8f5e"));

            migrationBuilder.DeleteData(
                table: "ItemVisibilities",
                keyColumn: "Id",
                keyValue: new Guid("a33dd8ed-4619-4d18-a25c-2bb25b7bb456"));

            migrationBuilder.DeleteData(
                table: "ItemVisibilities",
                keyColumn: "Id",
                keyValue: new Guid("a78c2eda-79cb-4acc-a7e4-92e0b45e20eb"));

            migrationBuilder.DeleteData(
                table: "ItemVisibilities",
                keyColumn: "Id",
                keyValue: new Guid("c0bbcabf-5c24-4ca6-86bc-eca11ae46eb8"));

            migrationBuilder.DeleteData(
                table: "ItemVisibilities",
                keyColumn: "Id",
                keyValue: new Guid("cbd7bd12-aa21-4e33-95cf-fd9c342db010"));

            migrationBuilder.DeleteData(
                table: "ItemVisibilities",
                keyColumn: "Id",
                keyValue: new Guid("d009129e-5655-4cd2-ba67-114e2e792b8c"));

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("6e1f7be8-13dc-4c6b-bb59-d6ee7cec35d8"));

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: new Guid("f9182575-b31f-4d24-bb44-17a062dfe6fe"));

            migrationBuilder.DeleteData(
                table: "LocationVisibilities",
                keyColumn: "Id",
                keyValue: new Guid("21bb8f90-6e2a-4464-b97f-d051e697c278"));

            migrationBuilder.DeleteData(
                table: "LocationVisibilities",
                keyColumn: "Id",
                keyValue: new Guid("bcf0602c-9f4d-4ca0-8403-460e9dbd6a75"));

            migrationBuilder.DropColumn(
                name: "IsMain",
                table: "Pictures");

            migrationBuilder.AlterColumn<bool>(
                name: "IsAuction",
                table: "Items",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "MainPictureId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Items_MainPictureId",
                table: "Items",
                column: "MainPictureId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Pictures_MainPictureId",
                table: "Items",
                column: "MainPictureId",
                principalTable: "Pictures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
