using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Items.Data.Migrations
{
    public partial class CangedContractEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Contracts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ItemDescription",
                table: "Contracts",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "Contracts",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ItemPictureUri",
                table: "Contracts",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "Contracts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 17, 20, 1, 41, 468, DateTimeKind.Utc).AddTicks(1057), new DateTime(2023, 8, 17, 20, 1, 41, 468, DateTimeKind.Utc).AddTicks(1057) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 17, 20, 1, 41, 468, DateTimeKind.Utc).AddTicks(855), new DateTime(2023, 8, 17, 20, 1, 41, 468, DateTimeKind.Utc).AddTicks(858) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 17, 20, 1, 41, 468, DateTimeKind.Utc).AddTicks(1069), new DateTime(2023, 8, 17, 20, 1, 41, 468, DateTimeKind.Utc).AddTicks(1069) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 17, 20, 1, 41, 468, DateTimeKind.Utc).AddTicks(1123), new DateTime(2023, 8, 17, 20, 1, 41, 468, DateTimeKind.Utc).AddTicks(1123) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 17, 20, 1, 41, 468, DateTimeKind.Utc).AddTicks(1195), new DateTime(2023, 8, 17, 20, 1, 41, 468, DateTimeKind.Utc).AddTicks(1195) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 17, 20, 1, 41, 468, DateTimeKind.Utc).AddTicks(1103), new DateTime(2023, 8, 17, 20, 1, 41, 468, DateTimeKind.Utc).AddTicks(1104) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 17, 20, 1, 41, 468, DateTimeKind.Utc).AddTicks(995), new DateTime(2023, 8, 17, 20, 1, 41, 468, DateTimeKind.Utc).AddTicks(995) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 17, 20, 1, 41, 468, DateTimeKind.Utc).AddTicks(1037), new DateTime(2023, 8, 17, 20, 1, 41, 468, DateTimeKind.Utc).AddTicks(1037) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 17, 20, 1, 41, 468, DateTimeKind.Utc).AddTicks(1083), new DateTime(2023, 8, 17, 20, 1, 41, 468, DateTimeKind.Utc).AddTicks(1083) });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_UnitId",
                table: "Contracts",
                column: "UnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Units_UnitId",
                table: "Contracts",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Units_UnitId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_UnitId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "ItemDescription",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "ItemPictureUri",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "UnitId",
                table: "Contracts");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 16, 23, 39, 44, 711, DateTimeKind.Utc).AddTicks(2528), new DateTime(2023, 8, 16, 23, 39, 44, 711, DateTimeKind.Utc).AddTicks(2528) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 16, 23, 39, 44, 711, DateTimeKind.Utc).AddTicks(2218), new DateTime(2023, 8, 16, 23, 39, 44, 711, DateTimeKind.Utc).AddTicks(2221) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 16, 23, 39, 44, 711, DateTimeKind.Utc).AddTicks(2555), new DateTime(2023, 8, 16, 23, 39, 44, 711, DateTimeKind.Utc).AddTicks(2555) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 16, 23, 39, 44, 711, DateTimeKind.Utc).AddTicks(2607), new DateTime(2023, 8, 16, 23, 39, 44, 711, DateTimeKind.Utc).AddTicks(2607) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 16, 23, 39, 44, 711, DateTimeKind.Utc).AddTicks(2618), new DateTime(2023, 8, 16, 23, 39, 44, 711, DateTimeKind.Utc).AddTicks(2618) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 16, 23, 39, 44, 711, DateTimeKind.Utc).AddTicks(2589), new DateTime(2023, 8, 16, 23, 39, 44, 711, DateTimeKind.Utc).AddTicks(2590) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 16, 23, 39, 44, 711, DateTimeKind.Utc).AddTicks(2486), new DateTime(2023, 8, 16, 23, 39, 44, 711, DateTimeKind.Utc).AddTicks(2487) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 16, 23, 39, 44, 711, DateTimeKind.Utc).AddTicks(2509), new DateTime(2023, 8, 16, 23, 39, 44, 711, DateTimeKind.Utc).AddTicks(2509) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 16, 23, 39, 44, 711, DateTimeKind.Utc).AddTicks(2571), new DateTime(2023, 8, 16, 23, 39, 44, 711, DateTimeKind.Utc).AddTicks(2571) });
        }
    }
}
