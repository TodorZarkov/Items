using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Items.Data.Migrations
{
    public partial class CangedContractEntityRenamedColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuyerConfirm",
                table: "Contracts");

            migrationBuilder.RenameColumn(
                name: "Fulfilled",
                table: "Contracts",
                newName: "SellerReceived");

            migrationBuilder.AddColumn<bool>(
                name: "BuyerReceived",
                table: "Contracts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 18, 21, 18, 18, 882, DateTimeKind.Utc).AddTicks(3599), new DateTime(2023, 8, 18, 21, 18, 18, 882, DateTimeKind.Utc).AddTicks(3599) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 18, 21, 18, 18, 882, DateTimeKind.Utc).AddTicks(3403), new DateTime(2023, 8, 18, 21, 18, 18, 882, DateTimeKind.Utc).AddTicks(3407) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 18, 21, 18, 18, 882, DateTimeKind.Utc).AddTicks(3623), new DateTime(2023, 8, 18, 21, 18, 18, 882, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 18, 21, 18, 18, 882, DateTimeKind.Utc).AddTicks(3752), new DateTime(2023, 8, 18, 21, 18, 18, 882, DateTimeKind.Utc).AddTicks(3752) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 18, 21, 18, 18, 882, DateTimeKind.Utc).AddTicks(3764), new DateTime(2023, 8, 18, 21, 18, 18, 882, DateTimeKind.Utc).AddTicks(3764) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 18, 21, 18, 18, 882, DateTimeKind.Utc).AddTicks(3734), new DateTime(2023, 8, 18, 21, 18, 18, 882, DateTimeKind.Utc).AddTicks(3734) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 18, 21, 18, 18, 882, DateTimeKind.Utc).AddTicks(3542), new DateTime(2023, 8, 18, 21, 18, 18, 882, DateTimeKind.Utc).AddTicks(3543) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 18, 21, 18, 18, 882, DateTimeKind.Utc).AddTicks(3565), new DateTime(2023, 8, 18, 21, 18, 18, 882, DateTimeKind.Utc).AddTicks(3565) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 18, 21, 18, 18, 882, DateTimeKind.Utc).AddTicks(3710), new DateTime(2023, 8, 18, 21, 18, 18, 882, DateTimeKind.Utc).AddTicks(3710) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BuyerReceived",
                table: "Contracts");

            migrationBuilder.RenameColumn(
                name: "SellerReceived",
                table: "Contracts",
                newName: "Fulfilled");

            migrationBuilder.AddColumn<bool>(
                name: "BuyerConfirm",
                table: "Contracts",
                type: "bit",
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
    }
}
