using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Items.Data.Migrations
{
    public partial class RemPictureAddFileIdentifier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pictures");

            migrationBuilder.CreateTable(
                name: "FileIdentifiers",
                columns: table => new
                {
                    FileId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FileIdentifiers", x => x.FileId);
                    table.ForeignKey(
                        name: "FK_FileIdentifiers_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 2, 25, 8, 18, 22, 812, DateTimeKind.Utc).AddTicks(1239), new DateTime(2024, 2, 25, 8, 18, 22, 812, DateTimeKind.Utc).AddTicks(1239) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 2, 25, 8, 18, 22, 812, DateTimeKind.Utc).AddTicks(1077), new DateTime(2024, 2, 25, 8, 18, 22, 812, DateTimeKind.Utc).AddTicks(1079) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 2, 25, 8, 18, 22, 812, DateTimeKind.Utc).AddTicks(1251), new DateTime(2024, 2, 25, 8, 18, 22, 812, DateTimeKind.Utc).AddTicks(1251) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 2, 25, 8, 18, 22, 812, DateTimeKind.Utc).AddTicks(1308), new DateTime(2024, 2, 25, 8, 18, 22, 812, DateTimeKind.Utc).AddTicks(1308) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 2, 25, 8, 18, 22, 812, DateTimeKind.Utc).AddTicks(1317), new DateTime(2024, 2, 25, 8, 18, 22, 812, DateTimeKind.Utc).AddTicks(1317) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 2, 25, 8, 18, 22, 812, DateTimeKind.Utc).AddTicks(1292), new DateTime(2024, 2, 25, 8, 18, 22, 812, DateTimeKind.Utc).AddTicks(1293) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 2, 25, 8, 18, 22, 812, DateTimeKind.Utc).AddTicks(1202), new DateTime(2024, 2, 25, 8, 18, 22, 812, DateTimeKind.Utc).AddTicks(1202) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 2, 25, 8, 18, 22, 812, DateTimeKind.Utc).AddTicks(1222), new DateTime(2024, 2, 25, 8, 18, 22, 812, DateTimeKind.Utc).AddTicks(1222) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 2, 25, 8, 18, 22, 812, DateTimeKind.Utc).AddTicks(1274), new DateTime(2024, 2, 25, 8, 18, 22, 812, DateTimeKind.Utc).AddTicks(1274) });

            migrationBuilder.CreateIndex(
                name: "IX_FileIdentifiers_ItemId",
                table: "FileIdentifiers",
                column: "ItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FileIdentifiers");

            migrationBuilder.CreateTable(
                name: "Pictures",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ItemId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IsMain = table.Column<bool>(type: "bit", nullable: false),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: false),
                    Uri = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pictures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pictures_Items_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Items",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 2, 24, 21, 14, 31, 97, DateTimeKind.Utc).AddTicks(8493), new DateTime(2024, 2, 24, 21, 14, 31, 97, DateTimeKind.Utc).AddTicks(8493) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 2, 24, 21, 14, 31, 97, DateTimeKind.Utc).AddTicks(8310), new DateTime(2024, 2, 24, 21, 14, 31, 97, DateTimeKind.Utc).AddTicks(8313) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 2, 24, 21, 14, 31, 97, DateTimeKind.Utc).AddTicks(8505), new DateTime(2024, 2, 24, 21, 14, 31, 97, DateTimeKind.Utc).AddTicks(8505) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 2, 24, 21, 14, 31, 97, DateTimeKind.Utc).AddTicks(8553), new DateTime(2024, 2, 24, 21, 14, 31, 97, DateTimeKind.Utc).AddTicks(8554) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 2, 24, 21, 14, 31, 97, DateTimeKind.Utc).AddTicks(8565), new DateTime(2024, 2, 24, 21, 14, 31, 97, DateTimeKind.Utc).AddTicks(8565) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 2, 24, 21, 14, 31, 97, DateTimeKind.Utc).AddTicks(8537), new DateTime(2024, 2, 24, 21, 14, 31, 97, DateTimeKind.Utc).AddTicks(8538) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 2, 24, 21, 14, 31, 97, DateTimeKind.Utc).AddTicks(8440), new DateTime(2024, 2, 24, 21, 14, 31, 97, DateTimeKind.Utc).AddTicks(8440) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 2, 24, 21, 14, 31, 97, DateTimeKind.Utc).AddTicks(8473), new DateTime(2024, 2, 24, 21, 14, 31, 97, DateTimeKind.Utc).AddTicks(8474) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 2, 24, 21, 14, 31, 97, DateTimeKind.Utc).AddTicks(8518), new DateTime(2024, 2, 24, 21, 14, 31, 97, DateTimeKind.Utc).AddTicks(8519) });

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

            migrationBuilder.CreateIndex(
                name: "IX_Pictures_ItemId",
                table: "Pictures",
                column: "ItemId");
        }
    }
}
