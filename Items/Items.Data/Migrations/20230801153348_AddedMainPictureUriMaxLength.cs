using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Items.Data.Migrations
{
    public partial class AddedMainPictureUriMaxLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MainPictureUri",
                table: "Items",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

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
                column: "AddedOn",
                value: new DateTime(2023, 8, 1, 15, 33, 47, 931, DateTimeKind.Utc).AddTicks(1496));

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
                column: "AddedOn",
                value: new DateTime(2023, 8, 1, 15, 33, 47, 931, DateTimeKind.Utc).AddTicks(1744));

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
                column: "AddedOn",
                value: new DateTime(2023, 8, 1, 15, 33, 47, 931, DateTimeKind.Utc).AddTicks(1734));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 1, 15, 33, 47, 931, DateTimeKind.Utc).AddTicks(1608));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 1, 15, 33, 47, 931, DateTimeKind.Utc).AddTicks(1622));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 1, 15, 33, 47, 931, DateTimeKind.Utc).AddTicks(1657));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MainPictureUri",
                table: "Items",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(2048)",
                oldMaxLength: 2048);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 1, 15, 29, 3, 512, DateTimeKind.Utc).AddTicks(7591));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 1, 15, 29, 3, 512, DateTimeKind.Utc).AddTicks(7300));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 1, 15, 29, 3, 512, DateTimeKind.Utc).AddTicks(7606));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 1, 15, 29, 3, 512, DateTimeKind.Utc).AddTicks(7721));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 1, 15, 29, 3, 512, DateTimeKind.Utc).AddTicks(7737));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 1, 15, 29, 3, 512, DateTimeKind.Utc).AddTicks(7638));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 1, 15, 29, 3, 512, DateTimeKind.Utc).AddTicks(7559));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 1, 15, 29, 3, 512, DateTimeKind.Utc).AddTicks(7578));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"),
                column: "AddedOn",
                value: new DateTime(2023, 8, 1, 15, 29, 3, 512, DateTimeKind.Utc).AddTicks(7621));
        }
    }
}
