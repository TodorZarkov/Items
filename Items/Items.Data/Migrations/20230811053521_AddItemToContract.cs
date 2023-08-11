using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Items.Data.Migrations
{
    public partial class AddItemToContract : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ItemId",
                table: "Contracts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 11, 5, 35, 19, 984, DateTimeKind.Utc).AddTicks(9986), new DateTime(2023, 8, 11, 5, 35, 19, 984, DateTimeKind.Utc).AddTicks(9986) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 11, 5, 35, 19, 984, DateTimeKind.Utc).AddTicks(9831), new DateTime(2023, 8, 11, 5, 35, 19, 984, DateTimeKind.Utc).AddTicks(9834) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 11, 5, 35, 19, 984, DateTimeKind.Utc).AddTicks(9998), new DateTime(2023, 8, 11, 5, 35, 19, 984, DateTimeKind.Utc).AddTicks(9999) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 11, 5, 35, 19, 985, DateTimeKind.Utc).AddTicks(64), new DateTime(2023, 8, 11, 5, 35, 19, 985, DateTimeKind.Utc).AddTicks(64) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 11, 5, 35, 19, 985, DateTimeKind.Utc).AddTicks(74), new DateTime(2023, 8, 11, 5, 35, 19, 985, DateTimeKind.Utc).AddTicks(75) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 11, 5, 35, 19, 985, DateTimeKind.Utc).AddTicks(46), new DateTime(2023, 8, 11, 5, 35, 19, 985, DateTimeKind.Utc).AddTicks(46) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 11, 5, 35, 19, 984, DateTimeKind.Utc).AddTicks(9948), new DateTime(2023, 8, 11, 5, 35, 19, 984, DateTimeKind.Utc).AddTicks(9948) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 11, 5, 35, 19, 984, DateTimeKind.Utc).AddTicks(9969), new DateTime(2023, 8, 11, 5, 35, 19, 984, DateTimeKind.Utc).AddTicks(9969) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 11, 5, 35, 19, 985, DateTimeKind.Utc).AddTicks(26), new DateTime(2023, 8, 11, 5, 35, 19, 985, DateTimeKind.Utc).AddTicks(27) });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_ItemId",
                table: "Contracts",
                column: "ItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Items_ItemId",
                table: "Contracts",
                column: "ItemId",
                principalTable: "Items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Items_ItemId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_ItemId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "Contracts");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 10, 19, 59, 32, 231, DateTimeKind.Utc).AddTicks(1123), new DateTime(2023, 8, 10, 19, 59, 32, 231, DateTimeKind.Utc).AddTicks(1123) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 10, 19, 59, 32, 231, DateTimeKind.Utc).AddTicks(829), new DateTime(2023, 8, 10, 19, 59, 32, 231, DateTimeKind.Utc).AddTicks(834) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 10, 19, 59, 32, 231, DateTimeKind.Utc).AddTicks(1136), new DateTime(2023, 8, 10, 19, 59, 32, 231, DateTimeKind.Utc).AddTicks(1136) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 10, 19, 59, 32, 231, DateTimeKind.Utc).AddTicks(1193), new DateTime(2023, 8, 10, 19, 59, 32, 231, DateTimeKind.Utc).AddTicks(1193) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 10, 19, 59, 32, 231, DateTimeKind.Utc).AddTicks(1204), new DateTime(2023, 8, 10, 19, 59, 32, 231, DateTimeKind.Utc).AddTicks(1204) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 10, 19, 59, 32, 231, DateTimeKind.Utc).AddTicks(1175), new DateTime(2023, 8, 10, 19, 59, 32, 231, DateTimeKind.Utc).AddTicks(1175) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 10, 19, 59, 32, 231, DateTimeKind.Utc).AddTicks(979), new DateTime(2023, 8, 10, 19, 59, 32, 231, DateTimeKind.Utc).AddTicks(979) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 10, 19, 59, 32, 231, DateTimeKind.Utc).AddTicks(1002), new DateTime(2023, 8, 10, 19, 59, 32, 231, DateTimeKind.Utc).AddTicks(1002) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 8, 10, 19, 59, 32, 231, DateTimeKind.Utc).AddTicks(1151), new DateTime(2023, 8, 10, 19, 59, 32, 231, DateTimeKind.Utc).AddTicks(1151) });
        }
    }
}
