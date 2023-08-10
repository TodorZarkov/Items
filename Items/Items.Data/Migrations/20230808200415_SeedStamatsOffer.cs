using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Items.Data.Migrations
{
    public partial class SeedStamatsOffer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 8, 20, 4, 14, 281, DateTimeKind.Utc).AddTicks(7097), new DateTime(2023, 8, 8, 20, 4, 14, 281, DateTimeKind.Utc).AddTicks(7097) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 8, 20, 4, 14, 281, DateTimeKind.Utc).AddTicks(6914), new DateTime(2023, 8, 8, 20, 4, 14, 281, DateTimeKind.Utc).AddTicks(6917) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 8, 20, 4, 14, 281, DateTimeKind.Utc).AddTicks(7185), new DateTime(2023, 8, 8, 20, 4, 14, 281, DateTimeKind.Utc).AddTicks(7186) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 8, 20, 4, 14, 281, DateTimeKind.Utc).AddTicks(7237), new DateTime(2023, 8, 8, 20, 4, 14, 281, DateTimeKind.Utc).AddTicks(7238) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 8, 20, 4, 14, 281, DateTimeKind.Utc).AddTicks(7247), new DateTime(2023, 8, 8, 20, 4, 14, 281, DateTimeKind.Utc).AddTicks(7248) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 8, 20, 4, 14, 281, DateTimeKind.Utc).AddTicks(7220), new DateTime(2023, 8, 8, 20, 4, 14, 281, DateTimeKind.Utc).AddTicks(7221) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 8, 20, 4, 14, 281, DateTimeKind.Utc).AddTicks(7054), new DateTime(2023, 8, 8, 20, 4, 14, 281, DateTimeKind.Utc).AddTicks(7055) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 8, 20, 4, 14, 281, DateTimeKind.Utc).AddTicks(7079), new DateTime(2023, 8, 8, 20, 4, 14, 281, DateTimeKind.Utc).AddTicks(7079) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 8, 20, 4, 14, 281, DateTimeKind.Utc).AddTicks(7201), new DateTime(2023, 8, 8, 20, 4, 14, 281, DateTimeKind.Utc).AddTicks(7201) });

            migrationBuilder.InsertData(
                table: "Offers",
                columns: new[] { "Id", "BarterItemId", "BarterQuantity", "BuyerId", "CurrencyId", "Expires", "ItemId", "LocationId", "Message", "Quantity", "Value" },
                values: new object[] { new Guid("71f73811-33dc-45a8-a3fe-a7d5a2363833"), null, null, new Guid("8b5b3b04-bf70-4018-ffbf-08db913996c1"), 1, new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"), null, null, 1m, 60m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Offers",
                keyColumn: "Id",
                keyValue: new Guid("71f73811-33dc-45a8-a3fe-a7d5a2363833"));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 7, 22, 0, 45, 346, DateTimeKind.Utc).AddTicks(4161), new DateTime(2023, 8, 7, 22, 0, 45, 346, DateTimeKind.Utc).AddTicks(4161) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 7, 22, 0, 45, 346, DateTimeKind.Utc).AddTicks(3897), new DateTime(2023, 8, 7, 22, 0, 45, 346, DateTimeKind.Utc).AddTicks(3900) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 7, 22, 0, 45, 346, DateTimeKind.Utc).AddTicks(4173), new DateTime(2023, 8, 7, 22, 0, 45, 346, DateTimeKind.Utc).AddTicks(4173) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 7, 22, 0, 45, 346, DateTimeKind.Utc).AddTicks(4234), new DateTime(2023, 8, 7, 22, 0, 45, 346, DateTimeKind.Utc).AddTicks(4234) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 7, 22, 0, 45, 346, DateTimeKind.Utc).AddTicks(4244), new DateTime(2023, 8, 7, 22, 0, 45, 346, DateTimeKind.Utc).AddTicks(4244) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 7, 22, 0, 45, 346, DateTimeKind.Utc).AddTicks(4217), new DateTime(2023, 8, 7, 22, 0, 45, 346, DateTimeKind.Utc).AddTicks(4217) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 7, 22, 0, 45, 346, DateTimeKind.Utc).AddTicks(4121), new DateTime(2023, 8, 7, 22, 0, 45, 346, DateTimeKind.Utc).AddTicks(4122) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 7, 22, 0, 45, 346, DateTimeKind.Utc).AddTicks(4144), new DateTime(2023, 8, 7, 22, 0, 45, 346, DateTimeKind.Utc).AddTicks(4145) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 7, 22, 0, 45, 346, DateTimeKind.Utc).AddTicks(4187), new DateTime(2023, 8, 7, 22, 0, 45, 346, DateTimeKind.Utc).AddTicks(4187) });
        }
    }
}
