using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Items.Data.Migrations
{
    public partial class AddedOwnerIdAndIsPublicToFileIdentifier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<Guid>(
                name: "ItemId",
                table: "FileIdentifiers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<bool>(
                name: "IsPublic",
                table: "FileIdentifiers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<Guid>(
                name: "OwnerId",
                table: "FileIdentifiers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "FileIdentifiers",
                type: "uniqueidentifier",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_FileIdentifiers_UserId",
                table: "FileIdentifiers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileIdentifiers_AspNetUsers_UserId",
                table: "FileIdentifiers",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileIdentifiers_AspNetUsers_UserId",
                table: "FileIdentifiers");

            migrationBuilder.DropIndex(
                name: "IX_FileIdentifiers_UserId",
                table: "FileIdentifiers");

            migrationBuilder.DropColumn(
                name: "IsPublic",
                table: "FileIdentifiers");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "FileIdentifiers");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "FileIdentifiers");

            migrationBuilder.AlterColumn<Guid>(
                name: "ItemId",
                table: "FileIdentifiers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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
    }
}
