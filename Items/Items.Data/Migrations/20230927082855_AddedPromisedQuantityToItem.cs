using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Items.Data.Migrations
{
    public partial class AddedPromisedQuantityToItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "PromisedQuantity",
                table: "Items",
                type: "float(18)",
                precision: 18,
                scale: 3,
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 27, 8, 28, 54, 362, DateTimeKind.Utc).AddTicks(8840), new DateTime(2023, 9, 27, 8, 28, 54, 362, DateTimeKind.Utc).AddTicks(8840) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 27, 8, 28, 54, 362, DateTimeKind.Utc).AddTicks(8673), new DateTime(2023, 9, 27, 8, 28, 54, 362, DateTimeKind.Utc).AddTicks(8676) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 27, 8, 28, 54, 362, DateTimeKind.Utc).AddTicks(8851), new DateTime(2023, 9, 27, 8, 28, 54, 362, DateTimeKind.Utc).AddTicks(8851) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 27, 8, 28, 54, 362, DateTimeKind.Utc).AddTicks(8911), new DateTime(2023, 9, 27, 8, 28, 54, 362, DateTimeKind.Utc).AddTicks(8911) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 27, 8, 28, 54, 362, DateTimeKind.Utc).AddTicks(8922), new DateTime(2023, 9, 27, 8, 28, 54, 362, DateTimeKind.Utc).AddTicks(8923) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 27, 8, 28, 54, 362, DateTimeKind.Utc).AddTicks(8882), new DateTime(2023, 9, 27, 8, 28, 54, 362, DateTimeKind.Utc).AddTicks(8882) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 27, 8, 28, 54, 362, DateTimeKind.Utc).AddTicks(8800), new DateTime(2023, 9, 27, 8, 28, 54, 362, DateTimeKind.Utc).AddTicks(8801) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 27, 8, 28, 54, 362, DateTimeKind.Utc).AddTicks(8821), new DateTime(2023, 9, 27, 8, 28, 54, 362, DateTimeKind.Utc).AddTicks(8822) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 27, 8, 28, 54, 362, DateTimeKind.Utc).AddTicks(8864), new DateTime(2023, 9, 27, 8, 28, 54, 362, DateTimeKind.Utc).AddTicks(8864) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PromisedQuantity",
                table: "Items");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 26, 21, 58, 16, 554, DateTimeKind.Utc).AddTicks(7886), new DateTime(2023, 9, 26, 21, 58, 16, 554, DateTimeKind.Utc).AddTicks(7886) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 26, 21, 58, 16, 554, DateTimeKind.Utc).AddTicks(7724), new DateTime(2023, 9, 26, 21, 58, 16, 554, DateTimeKind.Utc).AddTicks(7727) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 26, 21, 58, 16, 554, DateTimeKind.Utc).AddTicks(7898), new DateTime(2023, 9, 26, 21, 58, 16, 554, DateTimeKind.Utc).AddTicks(7898) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 26, 21, 58, 16, 554, DateTimeKind.Utc).AddTicks(8056), new DateTime(2023, 9, 26, 21, 58, 16, 554, DateTimeKind.Utc).AddTicks(8057) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 26, 21, 58, 16, 554, DateTimeKind.Utc).AddTicks(8070), new DateTime(2023, 9, 26, 21, 58, 16, 554, DateTimeKind.Utc).AddTicks(8070) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 26, 21, 58, 16, 554, DateTimeKind.Utc).AddTicks(7944), new DateTime(2023, 9, 26, 21, 58, 16, 554, DateTimeKind.Utc).AddTicks(7944) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 26, 21, 58, 16, 554, DateTimeKind.Utc).AddTicks(7844), new DateTime(2023, 9, 26, 21, 58, 16, 554, DateTimeKind.Utc).AddTicks(7844) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 26, 21, 58, 16, 554, DateTimeKind.Utc).AddTicks(7866), new DateTime(2023, 9, 26, 21, 58, 16, 554, DateTimeKind.Utc).AddTicks(7866) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 26, 21, 58, 16, 554, DateTimeKind.Utc).AddTicks(7912), new DateTime(2023, 9, 26, 21, 58, 16, 554, DateTimeKind.Utc).AddTicks(7912) });
        }
    }
}
