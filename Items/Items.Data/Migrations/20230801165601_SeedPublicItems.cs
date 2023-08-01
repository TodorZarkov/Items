using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Items.Data.Migrations
{
    public partial class SeedPublicItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 1, 16, 56, 0, 111, DateTimeKind.Utc).AddTicks(6005));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"),
                columns: new[] { "Access", "AddedOn", "EndSell", "StartSell" },
                values: new object[] { 2, new DateTime(2023, 8, 1, 16, 56, 0, 111, DateTimeKind.Utc).AddTicks(5756), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 1, 16, 56, 0, 111, DateTimeKind.Utc).AddTicks(6024));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37"),
                columns: new[] { "Access", "AddedOn", "EndSell", "StartSell" },
                values: new object[] { 2, new DateTime(2023, 8, 1, 16, 56, 0, 111, DateTimeKind.Utc).AddTicks(6188), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 1, 16, 56, 0, 111, DateTimeKind.Utc).AddTicks(6206));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2"),
                columns: new[] { "Access", "AddedOn", "EndSell", "StartSell" },
                values: new object[] { 2, new DateTime(2023, 8, 1, 16, 56, 0, 111, DateTimeKind.Utc).AddTicks(6169), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"),
                columns: new[] { "Access", "AddedOn", "EndSell", "StartSell" },
                values: new object[] { 2, new DateTime(2023, 8, 1, 16, 56, 0, 111, DateTimeKind.Utc).AddTicks(5953), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"),
                columns: new[] { "Access", "AddedOn", "EndSell", "StartSell" },
                values: new object[] { 2, new DateTime(2023, 8, 1, 16, 56, 0, 111, DateTimeKind.Utc).AddTicks(5975), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"),
                columns: new[] { "Access", "AddedOn", "EndSell", "StartSell" },
                values: new object[] { 2, new DateTime(2023, 8, 1, 16, 56, 0, 111, DateTimeKind.Utc).AddTicks(6039), new DateTime(2024, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2023, 1, 8, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 1, 15, 33, 47, 931, DateTimeKind.Utc).AddTicks(1632));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"),
                columns: new[] { "Access", "AddedOn", "EndSell", "StartSell" },
                values: new object[] { 1, new DateTime(2023, 8, 1, 15, 33, 47, 931, DateTimeKind.Utc).AddTicks(1496), null, null });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 1, 15, 33, 47, 931, DateTimeKind.Utc).AddTicks(1644));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37"),
                columns: new[] { "Access", "AddedOn", "EndSell", "StartSell" },
                values: new object[] { 1, new DateTime(2023, 8, 1, 15, 33, 47, 931, DateTimeKind.Utc).AddTicks(1744), null, null });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 1, 15, 33, 47, 931, DateTimeKind.Utc).AddTicks(1757));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2"),
                columns: new[] { "Access", "AddedOn", "EndSell", "StartSell" },
                values: new object[] { 1, new DateTime(2023, 8, 1, 15, 33, 47, 931, DateTimeKind.Utc).AddTicks(1734), null, null });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"),
                columns: new[] { "Access", "AddedOn", "EndSell", "StartSell" },
                values: new object[] { 1, new DateTime(2023, 8, 1, 15, 33, 47, 931, DateTimeKind.Utc).AddTicks(1608), null, null });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"),
                columns: new[] { "Access", "AddedOn", "EndSell", "StartSell" },
                values: new object[] { 1, new DateTime(2023, 8, 1, 15, 33, 47, 931, DateTimeKind.Utc).AddTicks(1622), null, null });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"),
                columns: new[] { "Access", "AddedOn", "EndSell", "StartSell" },
                values: new object[] { 1, new DateTime(2023, 8, 1, 15, 33, 47, 931, DateTimeKind.Utc).AddTicks(1657), null, null });
        }
    }
}
