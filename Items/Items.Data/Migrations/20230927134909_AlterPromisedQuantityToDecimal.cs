using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Items.Data.Migrations
{
    public partial class AlterPromisedQuantityToDecimal : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "PromisedQuantity",
                table: "Items",
                type: "decimal(18,3)",
                precision: 18,
                scale: 3,
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float(18)",
                oldPrecision: 18,
                oldScale: 3);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92"),
                columns: new[] { "AddedOn", "ModifiedOn", "PromisedQuantity" },
                values: new object[] { new DateTime(2023, 9, 27, 13, 49, 7, 740, DateTimeKind.Utc).AddTicks(9262), new DateTime(2023, 9, 27, 13, 49, 7, 740, DateTimeKind.Utc).AddTicks(9262), 0m });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"),
                columns: new[] { "AddedOn", "ModifiedOn", "PromisedQuantity" },
                values: new object[] { new DateTime(2023, 9, 27, 13, 49, 7, 740, DateTimeKind.Utc).AddTicks(9074), new DateTime(2023, 9, 27, 13, 49, 7, 740, DateTimeKind.Utc).AddTicks(9079), 0m });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45"),
                columns: new[] { "AddedOn", "ModifiedOn", "PromisedQuantity" },
                values: new object[] { new DateTime(2023, 9, 27, 13, 49, 7, 740, DateTimeKind.Utc).AddTicks(9274), new DateTime(2023, 9, 27, 13, 49, 7, 740, DateTimeKind.Utc).AddTicks(9275), 0m });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37"),
                columns: new[] { "AddedOn", "ModifiedOn", "PromisedQuantity" },
                values: new object[] { new DateTime(2023, 9, 27, 13, 49, 7, 740, DateTimeKind.Utc).AddTicks(9403), new DateTime(2023, 9, 27, 13, 49, 7, 740, DateTimeKind.Utc).AddTicks(9403), 0m });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73"),
                columns: new[] { "AddedOn", "ModifiedOn", "PromisedQuantity" },
                values: new object[] { new DateTime(2023, 9, 27, 13, 49, 7, 740, DateTimeKind.Utc).AddTicks(9417), new DateTime(2023, 9, 27, 13, 49, 7, 740, DateTimeKind.Utc).AddTicks(9417), 0m });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2"),
                columns: new[] { "AddedOn", "ModifiedOn", "PromisedQuantity" },
                values: new object[] { new DateTime(2023, 9, 27, 13, 49, 7, 740, DateTimeKind.Utc).AddTicks(9383), new DateTime(2023, 9, 27, 13, 49, 7, 740, DateTimeKind.Utc).AddTicks(9383), 0m });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"),
                columns: new[] { "AddedOn", "ModifiedOn", "PromisedQuantity" },
                values: new object[] { new DateTime(2023, 9, 27, 13, 49, 7, 740, DateTimeKind.Utc).AddTicks(9205), new DateTime(2023, 9, 27, 13, 49, 7, 740, DateTimeKind.Utc).AddTicks(9205), 0m });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"),
                columns: new[] { "AddedOn", "ModifiedOn", "PromisedQuantity" },
                values: new object[] { new DateTime(2023, 9, 27, 13, 49, 7, 740, DateTimeKind.Utc).AddTicks(9241), new DateTime(2023, 9, 27, 13, 49, 7, 740, DateTimeKind.Utc).AddTicks(9241), 0m });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"),
                columns: new[] { "AddedOn", "ModifiedOn", "PromisedQuantity" },
                values: new object[] { new DateTime(2023, 9, 27, 13, 49, 7, 740, DateTimeKind.Utc).AddTicks(9287), new DateTime(2023, 9, 27, 13, 49, 7, 740, DateTimeKind.Utc).AddTicks(9288), 0m });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "PromisedQuantity",
                table: "Items",
                type: "float(18)",
                precision: 18,
                scale: 3,
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,3)",
                oldPrecision: 18,
                oldScale: 3);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92"),
                columns: new[] { "AddedOn", "ModifiedOn", "PromisedQuantity" },
                values: new object[] { new DateTime(2023, 9, 27, 8, 51, 14, 836, DateTimeKind.Utc).AddTicks(5758), new DateTime(2023, 9, 27, 8, 51, 14, 836, DateTimeKind.Utc).AddTicks(5758), 0.0 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"),
                columns: new[] { "AddedOn", "ModifiedOn", "PromisedQuantity" },
                values: new object[] { new DateTime(2023, 9, 27, 8, 51, 14, 836, DateTimeKind.Utc).AddTicks(5523), new DateTime(2023, 9, 27, 8, 51, 14, 836, DateTimeKind.Utc).AddTicks(5526), 0.0 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45"),
                columns: new[] { "AddedOn", "ModifiedOn", "PromisedQuantity" },
                values: new object[] { new DateTime(2023, 9, 27, 8, 51, 14, 836, DateTimeKind.Utc).AddTicks(5786), new DateTime(2023, 9, 27, 8, 51, 14, 836, DateTimeKind.Utc).AddTicks(5787), 0.0 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37"),
                columns: new[] { "AddedOn", "ModifiedOn", "PromisedQuantity" },
                values: new object[] { new DateTime(2023, 9, 27, 8, 51, 14, 836, DateTimeKind.Utc).AddTicks(5837), new DateTime(2023, 9, 27, 8, 51, 14, 836, DateTimeKind.Utc).AddTicks(5837), 0.0 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73"),
                columns: new[] { "AddedOn", "ModifiedOn", "PromisedQuantity" },
                values: new object[] { new DateTime(2023, 9, 27, 8, 51, 14, 836, DateTimeKind.Utc).AddTicks(5847), new DateTime(2023, 9, 27, 8, 51, 14, 836, DateTimeKind.Utc).AddTicks(5847), 0.0 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2"),
                columns: new[] { "AddedOn", "ModifiedOn", "PromisedQuantity" },
                values: new object[] { new DateTime(2023, 9, 27, 8, 51, 14, 836, DateTimeKind.Utc).AddTicks(5819), new DateTime(2023, 9, 27, 8, 51, 14, 836, DateTimeKind.Utc).AddTicks(5820), 0.0 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"),
                columns: new[] { "AddedOn", "ModifiedOn", "PromisedQuantity" },
                values: new object[] { new DateTime(2023, 9, 27, 8, 51, 14, 836, DateTimeKind.Utc).AddTicks(5653), new DateTime(2023, 9, 27, 8, 51, 14, 836, DateTimeKind.Utc).AddTicks(5654), 0.0 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"),
                columns: new[] { "AddedOn", "ModifiedOn", "PromisedQuantity" },
                values: new object[] { new DateTime(2023, 9, 27, 8, 51, 14, 836, DateTimeKind.Utc).AddTicks(5675), new DateTime(2023, 9, 27, 8, 51, 14, 836, DateTimeKind.Utc).AddTicks(5675), 0.0 });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"),
                columns: new[] { "AddedOn", "ModifiedOn", "PromisedQuantity" },
                values: new object[] { new DateTime(2023, 9, 27, 8, 51, 14, 836, DateTimeKind.Utc).AddTicks(5801), new DateTime(2023, 9, 27, 8, 51, 14, 836, DateTimeKind.Utc).AddTicks(5801), 0.0 });
        }
    }
}
