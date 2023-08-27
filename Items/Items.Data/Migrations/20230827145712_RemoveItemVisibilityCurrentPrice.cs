using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Items.Data.Migrations
{
    public partial class RemoveItemVisibilityCurrentPrice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CurrentPrice",
                table: "ItemVisibilities");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentPrice",
                table: "ItemVisibilities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "ItemVisibilities",
                keyColumn: "Id",
                keyValue: new Guid("0fb06c25-8e6f-4fd2-a1d9-3cebb4621d2e"),
                column: "CurrentPrice",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ItemVisibilities",
                keyColumn: "Id",
                keyValue: new Guid("49abfa42-69f7-4240-a2ef-4e1b3ef7c16c"),
                column: "CurrentPrice",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ItemVisibilities",
                keyColumn: "Id",
                keyValue: new Guid("61c89a18-8bda-4d12-9a70-cdb17aedd752"),
                column: "CurrentPrice",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ItemVisibilities",
                keyColumn: "Id",
                keyValue: new Guid("8d725141-2b5a-468f-9e1e-61ab0c7f8f5e"),
                column: "CurrentPrice",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ItemVisibilities",
                keyColumn: "Id",
                keyValue: new Guid("a33dd8ed-4619-4d18-a25c-2bb25b7bb456"),
                column: "CurrentPrice",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ItemVisibilities",
                keyColumn: "Id",
                keyValue: new Guid("a78c2eda-79cb-4acc-a7e4-92e0b45e20eb"),
                column: "CurrentPrice",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ItemVisibilities",
                keyColumn: "Id",
                keyValue: new Guid("c0bbcabf-5c24-4ca6-86bc-eca11ae46eb8"),
                column: "CurrentPrice",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ItemVisibilities",
                keyColumn: "Id",
                keyValue: new Guid("cbd7bd12-aa21-4e33-95cf-fd9c342db010"),
                column: "CurrentPrice",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ItemVisibilities",
                keyColumn: "Id",
                keyValue: new Guid("d009129e-5655-4cd2-ba67-114e2e792b8c"),
                column: "CurrentPrice",
                value: 2);

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
    }
}
