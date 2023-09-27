using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Items.Data.Migrations
{
    public partial class RemoveLocationFromOffer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Locations_LocationId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_LocationId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Offers");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 27, 20, 15, 5, 363, DateTimeKind.Utc).AddTicks(657), new DateTime(2023, 9, 27, 20, 15, 5, 363, DateTimeKind.Utc).AddTicks(657) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 27, 20, 15, 5, 363, DateTimeKind.Utc).AddTicks(421), new DateTime(2023, 9, 27, 20, 15, 5, 363, DateTimeKind.Utc).AddTicks(425) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 27, 20, 15, 5, 363, DateTimeKind.Utc).AddTicks(671), new DateTime(2023, 9, 27, 20, 15, 5, 363, DateTimeKind.Utc).AddTicks(672) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 27, 20, 15, 5, 363, DateTimeKind.Utc).AddTicks(735), new DateTime(2023, 9, 27, 20, 15, 5, 363, DateTimeKind.Utc).AddTicks(735) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 27, 20, 15, 5, 363, DateTimeKind.Utc).AddTicks(747), new DateTime(2023, 9, 27, 20, 15, 5, 363, DateTimeKind.Utc).AddTicks(747) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 27, 20, 15, 5, 363, DateTimeKind.Utc).AddTicks(704), new DateTime(2023, 9, 27, 20, 15, 5, 363, DateTimeKind.Utc).AddTicks(704) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 27, 20, 15, 5, 363, DateTimeKind.Utc).AddTicks(549), new DateTime(2023, 9, 27, 20, 15, 5, 363, DateTimeKind.Utc).AddTicks(550) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 27, 20, 15, 5, 363, DateTimeKind.Utc).AddTicks(571), new DateTime(2023, 9, 27, 20, 15, 5, 363, DateTimeKind.Utc).AddTicks(572) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 27, 20, 15, 5, 363, DateTimeKind.Utc).AddTicks(684), new DateTime(2023, 9, 27, 20, 15, 5, 363, DateTimeKind.Utc).AddTicks(685) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "LocationId",
                table: "Offers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 27, 13, 49, 7, 740, DateTimeKind.Utc).AddTicks(9262), new DateTime(2023, 9, 27, 13, 49, 7, 740, DateTimeKind.Utc).AddTicks(9262) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 27, 13, 49, 7, 740, DateTimeKind.Utc).AddTicks(9074), new DateTime(2023, 9, 27, 13, 49, 7, 740, DateTimeKind.Utc).AddTicks(9079) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 27, 13, 49, 7, 740, DateTimeKind.Utc).AddTicks(9274), new DateTime(2023, 9, 27, 13, 49, 7, 740, DateTimeKind.Utc).AddTicks(9275) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 27, 13, 49, 7, 740, DateTimeKind.Utc).AddTicks(9403), new DateTime(2023, 9, 27, 13, 49, 7, 740, DateTimeKind.Utc).AddTicks(9403) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 27, 13, 49, 7, 740, DateTimeKind.Utc).AddTicks(9417), new DateTime(2023, 9, 27, 13, 49, 7, 740, DateTimeKind.Utc).AddTicks(9417) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 27, 13, 49, 7, 740, DateTimeKind.Utc).AddTicks(9383), new DateTime(2023, 9, 27, 13, 49, 7, 740, DateTimeKind.Utc).AddTicks(9383) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 27, 13, 49, 7, 740, DateTimeKind.Utc).AddTicks(9205), new DateTime(2023, 9, 27, 13, 49, 7, 740, DateTimeKind.Utc).AddTicks(9205) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 27, 13, 49, 7, 740, DateTimeKind.Utc).AddTicks(9241), new DateTime(2023, 9, 27, 13, 49, 7, 740, DateTimeKind.Utc).AddTicks(9241) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 27, 13, 49, 7, 740, DateTimeKind.Utc).AddTicks(9287), new DateTime(2023, 9, 27, 13, 49, 7, 740, DateTimeKind.Utc).AddTicks(9288) });

            migrationBuilder.CreateIndex(
                name: "IX_Offers_LocationId",
                table: "Offers",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Locations_LocationId",
                table: "Offers",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id");
        }
    }
}
