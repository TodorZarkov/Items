using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Items.Data.Migrations
{
    public partial class SeedStartSellDates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 1, 18, 25, 56, 617, DateTimeKind.Utc).AddTicks(6849));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"),
                columns: new[] { "AddedOn", "StartSell" },
                values: new object[] { new DateTime(2023, 8, 1, 18, 25, 56, 617, DateTimeKind.Utc).AddTicks(6698), new DateTime(2023, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 1, 18, 25, 56, 617, DateTimeKind.Utc).AddTicks(6859));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 1, 18, 25, 56, 617, DateTimeKind.Utc).AddTicks(6918));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 1, 18, 25, 56, 617, DateTimeKind.Utc).AddTicks(6928));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2"),
                columns: new[] { "AddedOn", "StartSell" },
                values: new object[] { new DateTime(2023, 8, 1, 18, 25, 56, 617, DateTimeKind.Utc).AddTicks(6903), new DateTime(2023, 8, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"),
                columns: new[] { "AddedOn", "StartSell" },
                values: new object[] { new DateTime(2023, 8, 1, 18, 25, 56, 617, DateTimeKind.Utc).AddTicks(6812), new DateTime(2023, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"),
                columns: new[] { "AddedOn", "StartSell" },
                values: new object[] { new DateTime(2023, 8, 1, 18, 25, 56, 617, DateTimeKind.Utc).AddTicks(6832), new DateTime(2023, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"),
                columns: new[] { "AddedOn", "StartSell" },
                values: new object[] { new DateTime(2023, 8, 1, 18, 25, 56, 617, DateTimeKind.Utc).AddTicks(6881), new DateTime(2023, 9, 9, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 1, 17, 14, 52, 359, DateTimeKind.Utc).AddTicks(4629));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"),
                columns: new[] { "AddedOn", "StartSell" },
                values: new object[] { new DateTime(2023, 8, 1, 17, 14, 52, 359, DateTimeKind.Utc).AddTicks(4450), new DateTime(2023, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 1, 17, 14, 52, 359, DateTimeKind.Utc).AddTicks(4641));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 1, 17, 14, 52, 359, DateTimeKind.Utc).AddTicks(4790));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 1, 17, 14, 52, 359, DateTimeKind.Utc).AddTicks(4801));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2"),
                columns: new[] { "AddedOn", "StartSell" },
                values: new object[] { new DateTime(2023, 8, 1, 17, 14, 52, 359, DateTimeKind.Utc).AddTicks(4769), new DateTime(2023, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"),
                columns: new[] { "AddedOn", "StartSell" },
                values: new object[] { new DateTime(2023, 8, 1, 17, 14, 52, 359, DateTimeKind.Utc).AddTicks(4574), new DateTime(2023, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"),
                columns: new[] { "AddedOn", "StartSell" },
                values: new object[] { new DateTime(2023, 8, 1, 17, 14, 52, 359, DateTimeKind.Utc).AddTicks(4595), new DateTime(2023, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"),
                columns: new[] { "AddedOn", "StartSell" },
                values: new object[] { new DateTime(2023, 8, 1, 17, 14, 52, 359, DateTimeKind.Utc).AddTicks(4654), new DateTime(2023, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
