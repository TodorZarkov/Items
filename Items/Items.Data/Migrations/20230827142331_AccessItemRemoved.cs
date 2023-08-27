using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Items.Data.Migrations
{
    public partial class AccessItemRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Access",
                table: "Items");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 27, 14, 23, 30, 550, DateTimeKind.Utc).AddTicks(3221), new DateTime(2023, 8, 27, 14, 23, 30, 550, DateTimeKind.Utc).AddTicks(3222) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 27, 14, 23, 30, 550, DateTimeKind.Utc).AddTicks(3058), new DateTime(2023, 8, 27, 14, 23, 30, 550, DateTimeKind.Utc).AddTicks(3060) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 27, 14, 23, 30, 550, DateTimeKind.Utc).AddTicks(3247), new DateTime(2023, 8, 27, 14, 23, 30, 550, DateTimeKind.Utc).AddTicks(3248) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 27, 14, 23, 30, 550, DateTimeKind.Utc).AddTicks(3371), new DateTime(2023, 8, 27, 14, 23, 30, 550, DateTimeKind.Utc).AddTicks(3371) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 27, 14, 23, 30, 550, DateTimeKind.Utc).AddTicks(3381), new DateTime(2023, 8, 27, 14, 23, 30, 550, DateTimeKind.Utc).AddTicks(3381) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 27, 14, 23, 30, 550, DateTimeKind.Utc).AddTicks(3352), new DateTime(2023, 8, 27, 14, 23, 30, 550, DateTimeKind.Utc).AddTicks(3353) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 27, 14, 23, 30, 550, DateTimeKind.Utc).AddTicks(3180), new DateTime(2023, 8, 27, 14, 23, 30, 550, DateTimeKind.Utc).AddTicks(3181) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 27, 14, 23, 30, 550, DateTimeKind.Utc).AddTicks(3203), new DateTime(2023, 8, 27, 14, 23, 30, 550, DateTimeKind.Utc).AddTicks(3203) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 27, 14, 23, 30, 550, DateTimeKind.Utc).AddTicks(3262), new DateTime(2023, 8, 27, 14, 23, 30, 550, DateTimeKind.Utc).AddTicks(3263) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Access",
                table: "Items",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92"),
                columns: new[] { "Access", "AddedOn", "ModifiedOn" },
                values: new object[] { 1, new DateTime(2023, 8, 18, 21, 18, 18, 882, DateTimeKind.Utc).AddTicks(3599), new DateTime(2023, 8, 18, 21, 18, 18, 882, DateTimeKind.Utc).AddTicks(3599) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"),
                columns: new[] { "Access", "AddedOn", "ModifiedOn" },
                values: new object[] { 2, new DateTime(2023, 8, 18, 21, 18, 18, 882, DateTimeKind.Utc).AddTicks(3403), new DateTime(2023, 8, 18, 21, 18, 18, 882, DateTimeKind.Utc).AddTicks(3407) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45"),
                columns: new[] { "Access", "AddedOn", "ModifiedOn" },
                values: new object[] { 1, new DateTime(2023, 8, 18, 21, 18, 18, 882, DateTimeKind.Utc).AddTicks(3623), new DateTime(2023, 8, 18, 21, 18, 18, 882, DateTimeKind.Utc).AddTicks(3624) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37"),
                columns: new[] { "Access", "AddedOn", "ModifiedOn" },
                values: new object[] { 1, new DateTime(2023, 8, 18, 21, 18, 18, 882, DateTimeKind.Utc).AddTicks(3752), new DateTime(2023, 8, 18, 21, 18, 18, 882, DateTimeKind.Utc).AddTicks(3752) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73"),
                columns: new[] { "Access", "AddedOn", "ModifiedOn" },
                values: new object[] { 1, new DateTime(2023, 8, 18, 21, 18, 18, 882, DateTimeKind.Utc).AddTicks(3764), new DateTime(2023, 8, 18, 21, 18, 18, 882, DateTimeKind.Utc).AddTicks(3764) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2"),
                columns: new[] { "Access", "AddedOn", "ModifiedOn" },
                values: new object[] { 2, new DateTime(2023, 8, 18, 21, 18, 18, 882, DateTimeKind.Utc).AddTicks(3734), new DateTime(2023, 8, 18, 21, 18, 18, 882, DateTimeKind.Utc).AddTicks(3734) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"),
                columns: new[] { "Access", "AddedOn", "ModifiedOn" },
                values: new object[] { 2, new DateTime(2023, 8, 18, 21, 18, 18, 882, DateTimeKind.Utc).AddTicks(3542), new DateTime(2023, 8, 18, 21, 18, 18, 882, DateTimeKind.Utc).AddTicks(3543) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"),
                columns: new[] { "Access", "AddedOn", "ModifiedOn" },
                values: new object[] { 2, new DateTime(2023, 8, 18, 21, 18, 18, 882, DateTimeKind.Utc).AddTicks(3565), new DateTime(2023, 8, 18, 21, 18, 18, 882, DateTimeKind.Utc).AddTicks(3565) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"),
                columns: new[] { "Access", "AddedOn", "ModifiedOn" },
                values: new object[] { 2, new DateTime(2023, 8, 18, 21, 18, 18, 882, DateTimeKind.Utc).AddTicks(3710), new DateTime(2023, 8, 18, 21, 18, 18, 882, DateTimeKind.Utc).AddTicks(3710) });
        }
    }
}
