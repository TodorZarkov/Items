using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Items.Data.Migrations
{
    public partial class AddedMainPictureUri : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MainPictureUri",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92"),
                columns: new[] { "AddedOn", "MainPictureUri" },
                values: new object[] { new DateTime(2023, 8, 1, 15, 29, 3, 512, DateTimeKind.Utc).AddTicks(7591), "https://i5.walmartimages.com/asr/0b26c2b4-5459-424c-ae09-364824104c90_1.642441b6196644f95b66202bb6185285.jpeg?odnWidth=1000&odnHeight=1000&odnBg=ffffff" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"),
                columns: new[] { "AddedOn", "MainPictureUri" },
                values: new object[] { new DateTime(2023, 8, 1, 15, 29, 3, 512, DateTimeKind.Utc).AddTicks(7300), "https://i5.walmartimages.com/asr/19fe13d7-ea2e-47f7-8547-202ce8c88717_1.bc800cefd11bb60ebc07ebdd7fac8ff6.jpeg" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45"),
                columns: new[] { "AddedOn", "MainPictureUri" },
                values: new object[] { new DateTime(2023, 8, 1, 15, 29, 3, 512, DateTimeKind.Utc).AddTicks(7606), "https://i5.walmartimages.com/asr/ea368e4c-f0e3-401b-8cff-2344a05955ed_2.de437c99da79acc1cc2bec706fea7ce4.jpeg" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37"),
                columns: new[] { "AddedOn", "MainPictureUri" },
                values: new object[] { new DateTime(2023, 8, 1, 15, 29, 3, 512, DateTimeKind.Utc).AddTicks(7721), "https://www.kids-room.com/WebRoot/KidsroomDE/Shops/Kidsroom/55B8/CACC/36F4/5060/F31B/4DEB/AE1C/138D/BILD3_E6319/IC_IMAGE/en-hape-knob-puzzle-vehicles.jpg" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73"),
                columns: new[] { "AddedOn", "MainPictureUri" },
                values: new object[] { new DateTime(2023, 8, 1, 15, 29, 3, 512, DateTimeKind.Utc).AddTicks(7737), "https://jigsawpuzzles.online/king-include/uploads1/auto-cadillac-oldtimer-classic-vehicle-chrome-607938272.jpg" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2"),
                columns: new[] { "AddedOn", "MainPictureUri" },
                values: new object[] { new DateTime(2023, 8, 1, 15, 29, 3, 512, DateTimeKind.Utc).AddTicks(7638), "http://www.babylonhobbies.com/ebay/pictures/EDU_14862.jpg" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"),
                columns: new[] { "AddedOn", "MainPictureUri" },
                values: new object[] { new DateTime(2023, 8, 1, 15, 29, 3, 512, DateTimeKind.Utc).AddTicks(7559), "https://image.pushauction.com/0/0/77191e32-26bc-45d1-b916-1425f6513281/4533eb18-a6eb-4783-b444-aad16f842869.jpg" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"),
                columns: new[] { "AddedOn", "MainPictureUri" },
                values: new object[] { new DateTime(2023, 8, 1, 15, 29, 3, 512, DateTimeKind.Utc).AddTicks(7578), "https://static2.redcart.pl/templates/images/thumb/10281/800/9999/pl/0/templates/images/products/10281/067a782229f0ab90838b869e943673ca.jpg" });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"),
                columns: new[] { "AddedOn", "MainPictureUri" },
                values: new object[] { new DateTime(2023, 8, 1, 15, 29, 3, 512, DateTimeKind.Utc).AddTicks(7621), "https://i5.walmartimages.com/asr/cb1717c7-d4b2-483b-91a9-770f3db40076_1.1f5d5f997641b1adb8323d08d95e6bd6.jpeg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainPictureUri",
                table: "Items");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 1, 14, 35, 42, 349, DateTimeKind.Utc).AddTicks(5147));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 1, 14, 35, 42, 349, DateTimeKind.Utc).AddTicks(5017));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 1, 14, 35, 42, 349, DateTimeKind.Utc).AddTicks(5159));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 1, 14, 35, 42, 349, DateTimeKind.Utc).AddTicks(5203));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 1, 14, 35, 42, 349, DateTimeKind.Utc).AddTicks(5213));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 1, 14, 35, 42, 349, DateTimeKind.Utc).AddTicks(5181));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 1, 14, 35, 42, 349, DateTimeKind.Utc).AddTicks(5123));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 1, 14, 35, 42, 349, DateTimeKind.Utc).AddTicks(5136));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 1, 14, 35, 42, 349, DateTimeKind.Utc).AddTicks(5171));
        }
    }
}
