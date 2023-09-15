using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Items.Data.Migrations
{
    public partial class FixOfferPrecisionAndScale : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                table: "Offers",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)",
                oldPrecision: 18,
                oldScale: 6);

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "Offers",
                type: "decimal(18,3)",
                precision: 18,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)",
                oldPrecision: 18,
                oldScale: 6);

            migrationBuilder.AlterColumn<decimal>(
                name: "BarterQuantity",
                table: "Offers",
                type: "decimal(18,3)",
                precision: 18,
                scale: 3,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,6)",
                oldPrecision: 18,
                oldScale: 6,
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "Value",
                table: "Offers",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)",
                oldPrecision: 18,
                oldScale: 2);

            migrationBuilder.AlterColumn<decimal>(
                name: "Quantity",
                table: "Offers",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,3)",
                oldPrecision: 18,
                oldScale: 3);

            migrationBuilder.AlterColumn<decimal>(
                name: "BarterQuantity",
                table: "Offers",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,3)",
                oldPrecision: 18,
                oldScale: 3,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 27, 14, 57, 11, 293, DateTimeKind.Utc).AddTicks(20), new DateTime(2023, 8, 27, 14, 57, 11, 293, DateTimeKind.Utc).AddTicks(20) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 27, 14, 57, 11, 292, DateTimeKind.Utc).AddTicks(9793), new DateTime(2023, 8, 27, 14, 57, 11, 292, DateTimeKind.Utc).AddTicks(9798) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 27, 14, 57, 11, 293, DateTimeKind.Utc).AddTicks(30), new DateTime(2023, 8, 27, 14, 57, 11, 293, DateTimeKind.Utc).AddTicks(31) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 27, 14, 57, 11, 293, DateTimeKind.Utc).AddTicks(79), new DateTime(2023, 8, 27, 14, 57, 11, 293, DateTimeKind.Utc).AddTicks(80) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 27, 14, 57, 11, 293, DateTimeKind.Utc).AddTicks(91), new DateTime(2023, 8, 27, 14, 57, 11, 293, DateTimeKind.Utc).AddTicks(91) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 27, 14, 57, 11, 293, DateTimeKind.Utc).AddTicks(63), new DateTime(2023, 8, 27, 14, 57, 11, 293, DateTimeKind.Utc).AddTicks(63) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 27, 14, 57, 11, 292, DateTimeKind.Utc).AddTicks(9977), new DateTime(2023, 8, 27, 14, 57, 11, 292, DateTimeKind.Utc).AddTicks(9978) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 27, 14, 57, 11, 293, DateTimeKind.Utc).AddTicks(2), new DateTime(2023, 8, 27, 14, 57, 11, 293, DateTimeKind.Utc).AddTicks(3) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 27, 14, 57, 11, 293, DateTimeKind.Utc).AddTicks(43), new DateTime(2023, 8, 27, 14, 57, 11, 293, DateTimeKind.Utc).AddTicks(43) });
        }
    }
}
