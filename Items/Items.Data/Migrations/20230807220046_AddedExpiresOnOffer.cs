using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Items.Data.Migrations
{
    public partial class AddedExpiresOnOffer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Expires",
                table: "Offers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Expires",
                table: "Offers");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 5, 14, 29, 14, 162, DateTimeKind.Utc).AddTicks(4754), new DateTime(2023, 8, 5, 14, 29, 14, 162, DateTimeKind.Utc).AddTicks(4754) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 5, 14, 29, 14, 162, DateTimeKind.Utc).AddTicks(4613), new DateTime(2023, 8, 5, 14, 29, 14, 162, DateTimeKind.Utc).AddTicks(4615) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 5, 14, 29, 14, 162, DateTimeKind.Utc).AddTicks(4764), new DateTime(2023, 8, 5, 14, 29, 14, 162, DateTimeKind.Utc).AddTicks(4764) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 5, 14, 29, 14, 162, DateTimeKind.Utc).AddTicks(4937), new DateTime(2023, 8, 5, 14, 29, 14, 162, DateTimeKind.Utc).AddTicks(4937) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 5, 14, 29, 14, 162, DateTimeKind.Utc).AddTicks(4947), new DateTime(2023, 8, 5, 14, 29, 14, 162, DateTimeKind.Utc).AddTicks(4947) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 5, 14, 29, 14, 162, DateTimeKind.Utc).AddTicks(4803), new DateTime(2023, 8, 5, 14, 29, 14, 162, DateTimeKind.Utc).AddTicks(4804) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 5, 14, 29, 14, 162, DateTimeKind.Utc).AddTicks(4713), new DateTime(2023, 8, 5, 14, 29, 14, 162, DateTimeKind.Utc).AddTicks(4713) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 5, 14, 29, 14, 162, DateTimeKind.Utc).AddTicks(4737), new DateTime(2023, 8, 5, 14, 29, 14, 162, DateTimeKind.Utc).AddTicks(4737) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 5, 14, 29, 14, 162, DateTimeKind.Utc).AddTicks(4776), new DateTime(2023, 8, 5, 14, 29, 14, 162, DateTimeKind.Utc).AddTicks(4776) });
        }
    }
}
