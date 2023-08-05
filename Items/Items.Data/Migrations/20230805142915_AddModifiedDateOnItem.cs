using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Items.Data.Migrations
{
    public partial class AddModifiedDateOnItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedOn",
                table: "Items",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ModifiedOn",
                table: "Items");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 3, 15, 8, 20, 388, DateTimeKind.Utc).AddTicks(1843));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 3, 15, 8, 20, 388, DateTimeKind.Utc).AddTicks(1609));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 3, 15, 8, 20, 388, DateTimeKind.Utc).AddTicks(1857));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 3, 15, 8, 20, 388, DateTimeKind.Utc).AddTicks(1918));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 3, 15, 8, 20, 388, DateTimeKind.Utc).AddTicks(1927));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 3, 15, 8, 20, 388, DateTimeKind.Utc).AddTicks(1900));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 3, 15, 8, 20, 388, DateTimeKind.Utc).AddTicks(1734));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 3, 15, 8, 20, 388, DateTimeKind.Utc).AddTicks(1822));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 3, 15, 8, 20, 388, DateTimeKind.Utc).AddTicks(1881));
        }
    }
}
