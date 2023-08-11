using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Items.Data.Migrations
{
    public partial class SeedRotationPropsToItemAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92"),
                columns: new[] { "AddedOn", "ModifiedOn", "OnRotation" },
                values: new object[] { new DateTime(2023, 8, 11, 20, 9, 28, 606, DateTimeKind.Utc).AddTicks(4582), new DateTime(2023, 8, 11, 20, 9, 28, 606, DateTimeKind.Utc).AddTicks(4582), true });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"),
                columns: new[] { "AddedOn", "ModifiedOn", "OnRotation" },
                values: new object[] { new DateTime(2023, 8, 11, 20, 9, 28, 606, DateTimeKind.Utc).AddTicks(4401), new DateTime(2023, 8, 11, 20, 9, 28, 606, DateTimeKind.Utc).AddTicks(4404), true });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45"),
                columns: new[] { "AddedOn", "ModifiedOn", "OnRotation" },
                values: new object[] { new DateTime(2023, 8, 11, 20, 9, 28, 606, DateTimeKind.Utc).AddTicks(4597), new DateTime(2023, 8, 11, 20, 9, 28, 606, DateTimeKind.Utc).AddTicks(4597), true });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37"),
                columns: new[] { "AddedOn", "ModifiedOn", "OnRotation" },
                values: new object[] { new DateTime(2023, 8, 11, 20, 9, 28, 606, DateTimeKind.Utc).AddTicks(4653), new DateTime(2023, 8, 11, 20, 9, 28, 606, DateTimeKind.Utc).AddTicks(4653), true });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73"),
                columns: new[] { "AddedOn", "ModifiedOn", "OnRotation" },
                values: new object[] { new DateTime(2023, 8, 11, 20, 9, 28, 606, DateTimeKind.Utc).AddTicks(4791), new DateTime(2023, 8, 11, 20, 9, 28, 606, DateTimeKind.Utc).AddTicks(4791), true });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2"),
                columns: new[] { "AddedOn", "ModifiedOn", "OnRotation" },
                values: new object[] { new DateTime(2023, 8, 11, 20, 9, 28, 606, DateTimeKind.Utc).AddTicks(4631), new DateTime(2023, 8, 11, 20, 9, 28, 606, DateTimeKind.Utc).AddTicks(4631), true });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"),
                columns: new[] { "AddedOn", "ModifiedOn", "OnRotation" },
                values: new object[] { new DateTime(2023, 8, 11, 20, 9, 28, 606, DateTimeKind.Utc).AddTicks(4538), new DateTime(2023, 8, 11, 20, 9, 28, 606, DateTimeKind.Utc).AddTicks(4539), true });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"),
                columns: new[] { "AddedOn", "ModifiedOn", "OnRotation" },
                values: new object[] { new DateTime(2023, 8, 11, 20, 9, 28, 606, DateTimeKind.Utc).AddTicks(4562), new DateTime(2023, 8, 11, 20, 9, 28, 606, DateTimeKind.Utc).AddTicks(4562), true });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"),
                columns: new[] { "AddedOn", "ModifiedOn", "OnRotation" },
                values: new object[] { new DateTime(2023, 8, 11, 20, 9, 28, 606, DateTimeKind.Utc).AddTicks(4611), new DateTime(2023, 8, 11, 20, 9, 28, 606, DateTimeKind.Utc).AddTicks(4611), true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92"),
                columns: new[] { "AddedOn", "ModifiedOn", "OnRotation" },
                values: new object[] { new DateTime(2023, 8, 11, 20, 1, 49, 405, DateTimeKind.Utc).AddTicks(5519), new DateTime(2023, 8, 11, 20, 1, 49, 405, DateTimeKind.Utc).AddTicks(5520), false });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"),
                columns: new[] { "AddedOn", "ModifiedOn", "OnRotation" },
                values: new object[] { new DateTime(2023, 8, 11, 20, 1, 49, 405, DateTimeKind.Utc).AddTicks(5217), new DateTime(2023, 8, 11, 20, 1, 49, 405, DateTimeKind.Utc).AddTicks(5222), false });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45"),
                columns: new[] { "AddedOn", "ModifiedOn", "OnRotation" },
                values: new object[] { new DateTime(2023, 8, 11, 20, 1, 49, 405, DateTimeKind.Utc).AddTicks(5534), new DateTime(2023, 8, 11, 20, 1, 49, 405, DateTimeKind.Utc).AddTicks(5534), false });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37"),
                columns: new[] { "AddedOn", "ModifiedOn", "OnRotation" },
                values: new object[] { new DateTime(2023, 8, 11, 20, 1, 49, 405, DateTimeKind.Utc).AddTicks(5592), new DateTime(2023, 8, 11, 20, 1, 49, 405, DateTimeKind.Utc).AddTicks(5592), false });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73"),
                columns: new[] { "AddedOn", "ModifiedOn", "OnRotation" },
                values: new object[] { new DateTime(2023, 8, 11, 20, 1, 49, 405, DateTimeKind.Utc).AddTicks(5603), new DateTime(2023, 8, 11, 20, 1, 49, 405, DateTimeKind.Utc).AddTicks(5603), false });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2"),
                columns: new[] { "AddedOn", "ModifiedOn", "OnRotation" },
                values: new object[] { new DateTime(2023, 8, 11, 20, 1, 49, 405, DateTimeKind.Utc).AddTicks(5571), new DateTime(2023, 8, 11, 20, 1, 49, 405, DateTimeKind.Utc).AddTicks(5572), false });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"),
                columns: new[] { "AddedOn", "ModifiedOn", "OnRotation" },
                values: new object[] { new DateTime(2023, 8, 11, 20, 1, 49, 405, DateTimeKind.Utc).AddTicks(5390), new DateTime(2023, 8, 11, 20, 1, 49, 405, DateTimeKind.Utc).AddTicks(5391), false });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"),
                columns: new[] { "AddedOn", "ModifiedOn", "OnRotation" },
                values: new object[] { new DateTime(2023, 8, 11, 20, 1, 49, 405, DateTimeKind.Utc).AddTicks(5426), new DateTime(2023, 8, 11, 20, 1, 49, 405, DateTimeKind.Utc).AddTicks(5427), false });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"),
                columns: new[] { "AddedOn", "ModifiedOn", "OnRotation" },
                values: new object[] { new DateTime(2023, 8, 11, 20, 1, 49, 405, DateTimeKind.Utc).AddTicks(5549), new DateTime(2023, 8, 11, 20, 1, 49, 405, DateTimeKind.Utc).AddTicks(5549), false });
        }
    }
}
