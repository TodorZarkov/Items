using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Items.Data.Migrations
{
    public partial class SeedCategoryInstruments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatorId", "Name" },
                values: new object[] { 6, new Guid("7bee3220-a1a1-4502-efea-08db9037bc59"), "Instruments" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.AlterColumn<Guid>(
                name: "CreatorId",
                table: "Categories",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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
                column: "AddedOn",
                value: new DateTime(2023, 8, 1, 18, 25, 56, 617, DateTimeKind.Utc).AddTicks(6698));

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
                column: "AddedOn",
                value: new DateTime(2023, 8, 1, 18, 25, 56, 617, DateTimeKind.Utc).AddTicks(6903));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 1, 18, 25, 56, 617, DateTimeKind.Utc).AddTicks(6812));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 1, 18, 25, 56, 617, DateTimeKind.Utc).AddTicks(6832));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 1, 18, 25, 56, 617, DateTimeKind.Utc).AddTicks(6881));
        }
    }
}
