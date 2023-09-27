using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Items.Data.Migrations
{
    public partial class AddedBarterItemToContract : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BarterDescription",
                table: "Contracts",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BarterId",
                table: "Contracts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BarterName",
                table: "Contracts",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BarterPictureUri",
                table: "Contracts",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "BarterQuantity",
                table: "Contracts",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "BarterUnitId",
                table: "Contracts",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 27, 8, 51, 14, 836, DateTimeKind.Utc).AddTicks(5758), new DateTime(2023, 9, 27, 8, 51, 14, 836, DateTimeKind.Utc).AddTicks(5758) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 27, 8, 51, 14, 836, DateTimeKind.Utc).AddTicks(5523), new DateTime(2023, 9, 27, 8, 51, 14, 836, DateTimeKind.Utc).AddTicks(5526) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 27, 8, 51, 14, 836, DateTimeKind.Utc).AddTicks(5786), new DateTime(2023, 9, 27, 8, 51, 14, 836, DateTimeKind.Utc).AddTicks(5787) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 27, 8, 51, 14, 836, DateTimeKind.Utc).AddTicks(5837), new DateTime(2023, 9, 27, 8, 51, 14, 836, DateTimeKind.Utc).AddTicks(5837) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 27, 8, 51, 14, 836, DateTimeKind.Utc).AddTicks(5847), new DateTime(2023, 9, 27, 8, 51, 14, 836, DateTimeKind.Utc).AddTicks(5847) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 27, 8, 51, 14, 836, DateTimeKind.Utc).AddTicks(5819), new DateTime(2023, 9, 27, 8, 51, 14, 836, DateTimeKind.Utc).AddTicks(5820) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 27, 8, 51, 14, 836, DateTimeKind.Utc).AddTicks(5653), new DateTime(2023, 9, 27, 8, 51, 14, 836, DateTimeKind.Utc).AddTicks(5654) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 27, 8, 51, 14, 836, DateTimeKind.Utc).AddTicks(5675), new DateTime(2023, 9, 27, 8, 51, 14, 836, DateTimeKind.Utc).AddTicks(5675) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 27, 8, 51, 14, 836, DateTimeKind.Utc).AddTicks(5801), new DateTime(2023, 9, 27, 8, 51, 14, 836, DateTimeKind.Utc).AddTicks(5801) });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_BarterId",
                table: "Contracts",
                column: "BarterId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_BarterUnitId",
                table: "Contracts",
                column: "BarterUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Items_BarterId",
                table: "Contracts",
                column: "BarterId",
                principalTable: "Items",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_Units_BarterUnitId",
                table: "Contracts",
                column: "BarterUnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Items_BarterId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_Units_BarterUnitId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_BarterId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_BarterUnitId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "BarterDescription",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "BarterId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "BarterName",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "BarterPictureUri",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "BarterQuantity",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "BarterUnitId",
                table: "Contracts");

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
    }
}
