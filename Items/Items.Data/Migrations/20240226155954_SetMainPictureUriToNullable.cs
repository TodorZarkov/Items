using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Items.Data.Migrations
{
    public partial class SetMainPictureUriToNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MainPictureUri",
                table: "Items",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2048)",
                oldMaxLength: 2048);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 2, 26, 15, 59, 53, 744, DateTimeKind.Utc).AddTicks(366), new DateTime(2024, 2, 26, 15, 59, 53, 744, DateTimeKind.Utc).AddTicks(367) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 2, 26, 15, 59, 53, 744, DateTimeKind.Utc).AddTicks(175), new DateTime(2024, 2, 26, 15, 59, 53, 744, DateTimeKind.Utc).AddTicks(178) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 2, 26, 15, 59, 53, 744, DateTimeKind.Utc).AddTicks(387), new DateTime(2024, 2, 26, 15, 59, 53, 744, DateTimeKind.Utc).AddTicks(388) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 2, 26, 15, 59, 53, 744, DateTimeKind.Utc).AddTicks(572), new DateTime(2024, 2, 26, 15, 59, 53, 744, DateTimeKind.Utc).AddTicks(572) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 2, 26, 15, 59, 53, 744, DateTimeKind.Utc).AddTicks(583), new DateTime(2024, 2, 26, 15, 59, 53, 744, DateTimeKind.Utc).AddTicks(584) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 2, 26, 15, 59, 53, 744, DateTimeKind.Utc).AddTicks(424), new DateTime(2024, 2, 26, 15, 59, 53, 744, DateTimeKind.Utc).AddTicks(425) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 2, 26, 15, 59, 53, 744, DateTimeKind.Utc).AddTicks(317), new DateTime(2024, 2, 26, 15, 59, 53, 744, DateTimeKind.Utc).AddTicks(317) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 2, 26, 15, 59, 53, 744, DateTimeKind.Utc).AddTicks(345), new DateTime(2024, 2, 26, 15, 59, 53, 744, DateTimeKind.Utc).AddTicks(346) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 2, 26, 15, 59, 53, 744, DateTimeKind.Utc).AddTicks(403), new DateTime(2024, 2, 26, 15, 59, 53, 744, DateTimeKind.Utc).AddTicks(403) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MainPictureUri",
                table: "Items",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(2048)",
                oldMaxLength: 2048,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 2, 25, 10, 14, 56, 701, DateTimeKind.Utc).AddTicks(6697), new DateTime(2024, 2, 25, 10, 14, 56, 701, DateTimeKind.Utc).AddTicks(6698) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 2, 25, 10, 14, 56, 701, DateTimeKind.Utc).AddTicks(6529), new DateTime(2024, 2, 25, 10, 14, 56, 701, DateTimeKind.Utc).AddTicks(6532) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 2, 25, 10, 14, 56, 701, DateTimeKind.Utc).AddTicks(6709), new DateTime(2024, 2, 25, 10, 14, 56, 701, DateTimeKind.Utc).AddTicks(6709) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 2, 25, 10, 14, 56, 701, DateTimeKind.Utc).AddTicks(6776), new DateTime(2024, 2, 25, 10, 14, 56, 701, DateTimeKind.Utc).AddTicks(6776) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 2, 25, 10, 14, 56, 701, DateTimeKind.Utc).AddTicks(6788), new DateTime(2024, 2, 25, 10, 14, 56, 701, DateTimeKind.Utc).AddTicks(6788) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 2, 25, 10, 14, 56, 701, DateTimeKind.Utc).AddTicks(6757), new DateTime(2024, 2, 25, 10, 14, 56, 701, DateTimeKind.Utc).AddTicks(6758) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 2, 25, 10, 14, 56, 701, DateTimeKind.Utc).AddTicks(6656), new DateTime(2024, 2, 25, 10, 14, 56, 701, DateTimeKind.Utc).AddTicks(6656) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 2, 25, 10, 14, 56, 701, DateTimeKind.Utc).AddTicks(6678), new DateTime(2024, 2, 25, 10, 14, 56, 701, DateTimeKind.Utc).AddTicks(6679) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 2, 25, 10, 14, 56, 701, DateTimeKind.Utc).AddTicks(6739), new DateTime(2024, 2, 25, 10, 14, 56, 701, DateTimeKind.Utc).AddTicks(6739) });
        }
    }
}
