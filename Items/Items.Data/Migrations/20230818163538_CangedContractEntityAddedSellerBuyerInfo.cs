using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Items.Data.Migrations
{
    public partial class CangedContractEntityAddedSellerBuyerInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ItemId",
                table: "Contracts",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ContractDate",
                table: "Contracts",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "BuyerEmail",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuyerName",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BuyerPhone",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SellerEmail",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SellerName",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SellerPhone",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 18, 16, 35, 37, 155, DateTimeKind.Utc).AddTicks(3609), new DateTime(2023, 8, 18, 16, 35, 37, 155, DateTimeKind.Utc).AddTicks(3609) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 18, 16, 35, 37, 155, DateTimeKind.Utc).AddTicks(3328), new DateTime(2023, 8, 18, 16, 35, 37, 155, DateTimeKind.Utc).AddTicks(3331) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 18, 16, 35, 37, 155, DateTimeKind.Utc).AddTicks(3621), new DateTime(2023, 8, 18, 16, 35, 37, 155, DateTimeKind.Utc).AddTicks(3622) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 18, 16, 35, 37, 155, DateTimeKind.Utc).AddTicks(3678), new DateTime(2023, 8, 18, 16, 35, 37, 155, DateTimeKind.Utc).AddTicks(3678) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 18, 16, 35, 37, 155, DateTimeKind.Utc).AddTicks(3690), new DateTime(2023, 8, 18, 16, 35, 37, 155, DateTimeKind.Utc).AddTicks(3690) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 18, 16, 35, 37, 155, DateTimeKind.Utc).AddTicks(3657), new DateTime(2023, 8, 18, 16, 35, 37, 155, DateTimeKind.Utc).AddTicks(3657) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 18, 16, 35, 37, 155, DateTimeKind.Utc).AddTicks(3465), new DateTime(2023, 8, 18, 16, 35, 37, 155, DateTimeKind.Utc).AddTicks(3465) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 18, 16, 35, 37, 155, DateTimeKind.Utc).AddTicks(3508), new DateTime(2023, 8, 18, 16, 35, 37, 155, DateTimeKind.Utc).AddTicks(3508) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 18, 16, 35, 37, 155, DateTimeKind.Utc).AddTicks(3637), new DateTime(2023, 8, 18, 16, 35, 37, 155, DateTimeKind.Utc).AddTicks(3637) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuyerEmail",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "BuyerName",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "BuyerPhone",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "SellerEmail",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "SellerName",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "SellerPhone",
                table: "Contracts");

            migrationBuilder.AlterColumn<Guid>(
                name: "ItemId",
                table: "Contracts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ContractDate",
                table: "Contracts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

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
        }
    }
}
