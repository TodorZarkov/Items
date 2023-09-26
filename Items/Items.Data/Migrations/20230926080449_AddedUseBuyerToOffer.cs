using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Items.Data.Migrations
{
    public partial class AddedUseBuyerToOffer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "UseBuyerEmail",
                table: "Offers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "UseBuyerName",
                table: "Offers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "UseBuyerPhone",
                table: "Offers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 26, 8, 4, 48, 112, DateTimeKind.Utc).AddTicks(3577), new DateTime(2023, 9, 26, 8, 4, 48, 112, DateTimeKind.Utc).AddTicks(3577) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 26, 8, 4, 48, 112, DateTimeKind.Utc).AddTicks(3438), new DateTime(2023, 9, 26, 8, 4, 48, 112, DateTimeKind.Utc).AddTicks(3440) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 26, 8, 4, 48, 112, DateTimeKind.Utc).AddTicks(3591), new DateTime(2023, 9, 26, 8, 4, 48, 112, DateTimeKind.Utc).AddTicks(3591) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 26, 8, 4, 48, 112, DateTimeKind.Utc).AddTicks(3634), new DateTime(2023, 9, 26, 8, 4, 48, 112, DateTimeKind.Utc).AddTicks(3635) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 26, 8, 4, 48, 112, DateTimeKind.Utc).AddTicks(3648), new DateTime(2023, 9, 26, 8, 4, 48, 112, DateTimeKind.Utc).AddTicks(3648) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 26, 8, 4, 48, 112, DateTimeKind.Utc).AddTicks(3619), new DateTime(2023, 9, 26, 8, 4, 48, 112, DateTimeKind.Utc).AddTicks(3619) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 26, 8, 4, 48, 112, DateTimeKind.Utc).AddTicks(3540), new DateTime(2023, 9, 26, 8, 4, 48, 112, DateTimeKind.Utc).AddTicks(3540) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 26, 8, 4, 48, 112, DateTimeKind.Utc).AddTicks(3559), new DateTime(2023, 9, 26, 8, 4, 48, 112, DateTimeKind.Utc).AddTicks(3560) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 26, 8, 4, 48, 112, DateTimeKind.Utc).AddTicks(3602), new DateTime(2023, 9, 26, 8, 4, 48, 112, DateTimeKind.Utc).AddTicks(3603) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UseBuyerEmail",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "UseBuyerName",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "UseBuyerPhone",
                table: "Offers");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 15, 12, 57, 2, 779, DateTimeKind.Utc).AddTicks(6154), new DateTime(2023, 9, 15, 12, 57, 2, 779, DateTimeKind.Utc).AddTicks(6155) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 15, 12, 57, 2, 779, DateTimeKind.Utc).AddTicks(6001), new DateTime(2023, 9, 15, 12, 57, 2, 779, DateTimeKind.Utc).AddTicks(6003) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 15, 12, 57, 2, 779, DateTimeKind.Utc).AddTicks(6166), new DateTime(2023, 9, 15, 12, 57, 2, 779, DateTimeKind.Utc).AddTicks(6166) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 15, 12, 57, 2, 779, DateTimeKind.Utc).AddTicks(6280), new DateTime(2023, 9, 15, 12, 57, 2, 779, DateTimeKind.Utc).AddTicks(6281) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 15, 12, 57, 2, 779, DateTimeKind.Utc).AddTicks(6291), new DateTime(2023, 9, 15, 12, 57, 2, 779, DateTimeKind.Utc).AddTicks(6291) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 15, 12, 57, 2, 779, DateTimeKind.Utc).AddTicks(6261), new DateTime(2023, 9, 15, 12, 57, 2, 779, DateTimeKind.Utc).AddTicks(6261) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 15, 12, 57, 2, 779, DateTimeKind.Utc).AddTicks(6106), new DateTime(2023, 9, 15, 12, 57, 2, 779, DateTimeKind.Utc).AddTicks(6106) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 15, 12, 57, 2, 779, DateTimeKind.Utc).AddTicks(6126), new DateTime(2023, 9, 15, 12, 57, 2, 779, DateTimeKind.Utc).AddTicks(6126) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 15, 12, 57, 2, 779, DateTimeKind.Utc).AddTicks(6241), new DateTime(2023, 9, 15, 12, 57, 2, 779, DateTimeKind.Utc).AddTicks(6241) });
        }
    }
}
