using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Items.Data.Migrations
{
    public partial class AddRotationPropsToItemAndUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "OnRotation",
                table: "Items",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "OnRotationNow",
                table: "Items",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "RotationItemsDate",
                table: "AspNetUsers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 11, 20, 1, 49, 405, DateTimeKind.Utc).AddTicks(5519), new DateTime(2023, 8, 11, 20, 1, 49, 405, DateTimeKind.Utc).AddTicks(5520) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 11, 20, 1, 49, 405, DateTimeKind.Utc).AddTicks(5217), new DateTime(2023, 8, 11, 20, 1, 49, 405, DateTimeKind.Utc).AddTicks(5222) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 11, 20, 1, 49, 405, DateTimeKind.Utc).AddTicks(5534), new DateTime(2023, 8, 11, 20, 1, 49, 405, DateTimeKind.Utc).AddTicks(5534) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 11, 20, 1, 49, 405, DateTimeKind.Utc).AddTicks(5592), new DateTime(2023, 8, 11, 20, 1, 49, 405, DateTimeKind.Utc).AddTicks(5592) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 11, 20, 1, 49, 405, DateTimeKind.Utc).AddTicks(5603), new DateTime(2023, 8, 11, 20, 1, 49, 405, DateTimeKind.Utc).AddTicks(5603) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 11, 20, 1, 49, 405, DateTimeKind.Utc).AddTicks(5571), new DateTime(2023, 8, 11, 20, 1, 49, 405, DateTimeKind.Utc).AddTicks(5572) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 11, 20, 1, 49, 405, DateTimeKind.Utc).AddTicks(5390), new DateTime(2023, 8, 11, 20, 1, 49, 405, DateTimeKind.Utc).AddTicks(5391) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 11, 20, 1, 49, 405, DateTimeKind.Utc).AddTicks(5426), new DateTime(2023, 8, 11, 20, 1, 49, 405, DateTimeKind.Utc).AddTicks(5427) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 11, 20, 1, 49, 405, DateTimeKind.Utc).AddTicks(5549), new DateTime(2023, 8, 11, 20, 1, 49, 405, DateTimeKind.Utc).AddTicks(5549) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OnRotation",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "OnRotationNow",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "RotationItemsDate",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 11, 14, 33, 1, 52, DateTimeKind.Utc).AddTicks(9032), new DateTime(2023, 8, 11, 14, 33, 1, 52, DateTimeKind.Utc).AddTicks(9032) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 11, 14, 33, 1, 52, DateTimeKind.Utc).AddTicks(8798), new DateTime(2023, 8, 11, 14, 33, 1, 52, DateTimeKind.Utc).AddTicks(8806) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 11, 14, 33, 1, 52, DateTimeKind.Utc).AddTicks(9046), new DateTime(2023, 8, 11, 14, 33, 1, 52, DateTimeKind.Utc).AddTicks(9047) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 11, 14, 33, 1, 52, DateTimeKind.Utc).AddTicks(9101), new DateTime(2023, 8, 11, 14, 33, 1, 52, DateTimeKind.Utc).AddTicks(9101) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 11, 14, 33, 1, 52, DateTimeKind.Utc).AddTicks(9112), new DateTime(2023, 8, 11, 14, 33, 1, 52, DateTimeKind.Utc).AddTicks(9113) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 11, 14, 33, 1, 52, DateTimeKind.Utc).AddTicks(9081), new DateTime(2023, 8, 11, 14, 33, 1, 52, DateTimeKind.Utc).AddTicks(9082) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 11, 14, 33, 1, 52, DateTimeKind.Utc).AddTicks(8987), new DateTime(2023, 8, 11, 14, 33, 1, 52, DateTimeKind.Utc).AddTicks(8987) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 11, 14, 33, 1, 52, DateTimeKind.Utc).AddTicks(9012), new DateTime(2023, 8, 11, 14, 33, 1, 52, DateTimeKind.Utc).AddTicks(9012) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 11, 14, 33, 1, 52, DateTimeKind.Utc).AddTicks(9061), new DateTime(2023, 8, 11, 14, 33, 1, 52, DateTimeKind.Utc).AddTicks(9062) });
        }
    }
}
