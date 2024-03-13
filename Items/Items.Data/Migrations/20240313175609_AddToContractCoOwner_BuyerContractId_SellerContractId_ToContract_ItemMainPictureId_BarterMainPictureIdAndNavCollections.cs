using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Items.Data.Migrations
{
    public partial class AddToContractCoOwner_BuyerContractId_SellerContractId_ToContract_ItemMainPictureId_BarterMainPictureIdAndNavCollections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BuyerContractId",
                table: "FileIdentifiers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "CoOwnerId",
                table: "FileIdentifiers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "SellerContractId",
                table: "FileIdentifiers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "BarterMainPictureId",
                table: "Contracts",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ItemMainPictureId",
                table: "Contracts",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 3, 13, 17, 56, 7, 570, DateTimeKind.Utc).AddTicks(9235), new DateTime(2024, 3, 13, 17, 56, 7, 570, DateTimeKind.Utc).AddTicks(9235) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 3, 13, 17, 56, 7, 570, DateTimeKind.Utc).AddTicks(9066), new DateTime(2024, 3, 13, 17, 56, 7, 570, DateTimeKind.Utc).AddTicks(9068) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 3, 13, 17, 56, 7, 570, DateTimeKind.Utc).AddTicks(9247), new DateTime(2024, 3, 13, 17, 56, 7, 570, DateTimeKind.Utc).AddTicks(9247) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 3, 13, 17, 56, 7, 570, DateTimeKind.Utc).AddTicks(9308), new DateTime(2024, 3, 13, 17, 56, 7, 570, DateTimeKind.Utc).AddTicks(9308) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 3, 13, 17, 56, 7, 570, DateTimeKind.Utc).AddTicks(9385), new DateTime(2024, 3, 13, 17, 56, 7, 570, DateTimeKind.Utc).AddTicks(9385) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 3, 13, 17, 56, 7, 570, DateTimeKind.Utc).AddTicks(9289), new DateTime(2024, 3, 13, 17, 56, 7, 570, DateTimeKind.Utc).AddTicks(9289) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 3, 13, 17, 56, 7, 570, DateTimeKind.Utc).AddTicks(9194), new DateTime(2024, 3, 13, 17, 56, 7, 570, DateTimeKind.Utc).AddTicks(9194) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 3, 13, 17, 56, 7, 570, DateTimeKind.Utc).AddTicks(9216), new DateTime(2024, 3, 13, 17, 56, 7, 570, DateTimeKind.Utc).AddTicks(9216) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 3, 13, 17, 56, 7, 570, DateTimeKind.Utc).AddTicks(9262), new DateTime(2024, 3, 13, 17, 56, 7, 570, DateTimeKind.Utc).AddTicks(9263) });

            migrationBuilder.CreateIndex(
                name: "IX_FileIdentifiers_BuyerContractId",
                table: "FileIdentifiers",
                column: "BuyerContractId");

            migrationBuilder.CreateIndex(
                name: "IX_FileIdentifiers_SellerContractId",
                table: "FileIdentifiers",
                column: "SellerContractId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileIdentifiers_Contracts_BuyerContractId",
                table: "FileIdentifiers",
                column: "BuyerContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FileIdentifiers_Contracts_SellerContractId",
                table: "FileIdentifiers",
                column: "SellerContractId",
                principalTable: "Contracts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileIdentifiers_Contracts_BuyerContractId",
                table: "FileIdentifiers");

            migrationBuilder.DropForeignKey(
                name: "FK_FileIdentifiers_Contracts_SellerContractId",
                table: "FileIdentifiers");

            migrationBuilder.DropIndex(
                name: "IX_FileIdentifiers_BuyerContractId",
                table: "FileIdentifiers");

            migrationBuilder.DropIndex(
                name: "IX_FileIdentifiers_SellerContractId",
                table: "FileIdentifiers");

            migrationBuilder.DropColumn(
                name: "BuyerContractId",
                table: "FileIdentifiers");

            migrationBuilder.DropColumn(
                name: "CoOwnerId",
                table: "FileIdentifiers");

            migrationBuilder.DropColumn(
                name: "SellerContractId",
                table: "FileIdentifiers");

            migrationBuilder.DropColumn(
                name: "BarterMainPictureId",
                table: "Contracts");

            migrationBuilder.DropColumn(
                name: "ItemMainPictureId",
                table: "Contracts");

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 3, 3, 21, 29, 22, 401, DateTimeKind.Utc).AddTicks(3604), new DateTime(2024, 3, 3, 21, 29, 22, 401, DateTimeKind.Utc).AddTicks(3605) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 3, 3, 21, 29, 22, 401, DateTimeKind.Utc).AddTicks(3434), new DateTime(2024, 3, 3, 21, 29, 22, 401, DateTimeKind.Utc).AddTicks(3437) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 3, 3, 21, 29, 22, 401, DateTimeKind.Utc).AddTicks(3615), new DateTime(2024, 3, 3, 21, 29, 22, 401, DateTimeKind.Utc).AddTicks(3615) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 3, 3, 21, 29, 22, 401, DateTimeKind.Utc).AddTicks(3665), new DateTime(2024, 3, 3, 21, 29, 22, 401, DateTimeKind.Utc).AddTicks(3665) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 3, 3, 21, 29, 22, 401, DateTimeKind.Utc).AddTicks(3678), new DateTime(2024, 3, 3, 21, 29, 22, 401, DateTimeKind.Utc).AddTicks(3679) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 3, 3, 21, 29, 22, 401, DateTimeKind.Utc).AddTicks(3648), new DateTime(2024, 3, 3, 21, 29, 22, 401, DateTimeKind.Utc).AddTicks(3649) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 3, 3, 21, 29, 22, 401, DateTimeKind.Utc).AddTicks(3565), new DateTime(2024, 3, 3, 21, 29, 22, 401, DateTimeKind.Utc).AddTicks(3565) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 3, 3, 21, 29, 22, 401, DateTimeKind.Utc).AddTicks(3586), new DateTime(2024, 3, 3, 21, 29, 22, 401, DateTimeKind.Utc).AddTicks(3587) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2024, 3, 3, 21, 29, 22, 401, DateTimeKind.Utc).AddTicks(3628), new DateTime(2024, 3, 3, 21, 29, 22, 401, DateTimeKind.Utc).AddTicks(3628) });
        }
    }
}
