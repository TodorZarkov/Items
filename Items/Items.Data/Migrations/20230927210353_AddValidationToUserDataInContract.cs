using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Items.Data.Migrations
{
    public partial class AddValidationToUserDataInContract : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SellerPhone",
                table: "Contracts",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SellerName",
                table: "Contracts",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SellerEmail",
                table: "Contracts",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BuyerPhone",
                table: "Contracts",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BuyerName",
                table: "Contracts",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BuyerEmail",
                table: "Contracts",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("2aa8b934-59f3-473b-842e-3df2a3590b92"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 27, 21, 3, 51, 890, DateTimeKind.Utc).AddTicks(2682), new DateTime(2023, 9, 27, 21, 3, 51, 890, DateTimeKind.Utc).AddTicks(2683) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("70ab6375-3da7-41cb-b80c-dcee2ba4fbbb"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 27, 21, 3, 51, 890, DateTimeKind.Utc).AddTicks(2493), new DateTime(2023, 9, 27, 21, 3, 51, 890, DateTimeKind.Utc).AddTicks(2497) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("7ec3d946-d2ef-4d54-a98e-00ea2b2e8b45"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 27, 21, 3, 51, 890, DateTimeKind.Utc).AddTicks(2844), new DateTime(2023, 9, 27, 21, 3, 51, 890, DateTimeKind.Utc).AddTicks(2845) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a0f0c44b-1ba4-484d-9c36-498579b61d37"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 27, 21, 3, 51, 890, DateTimeKind.Utc).AddTicks(2904), new DateTime(2023, 9, 27, 21, 3, 51, 890, DateTimeKind.Utc).AddTicks(2904) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("a676af29-2fd2-4e17-918d-73ec948cdc73"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 27, 21, 3, 51, 890, DateTimeKind.Utc).AddTicks(2915), new DateTime(2023, 9, 27, 21, 3, 51, 890, DateTimeKind.Utc).AddTicks(2916) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("cc1a92ff-e773-4d37-8d66-ddb31ab612b2"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 27, 21, 3, 51, 890, DateTimeKind.Utc).AddTicks(2883), new DateTime(2023, 9, 27, 21, 3, 51, 890, DateTimeKind.Utc).AddTicks(2883) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("e4d2697e-8edf-49f5-bac0-bc76dfbb43ee"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 27, 21, 3, 51, 890, DateTimeKind.Utc).AddTicks(2624), new DateTime(2023, 9, 27, 21, 3, 51, 890, DateTimeKind.Utc).AddTicks(2624) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea486471-25ca-40c5-bdce-c7c4157eb1b0"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 27, 21, 3, 51, 890, DateTimeKind.Utc).AddTicks(2646), new DateTime(2023, 9, 27, 21, 3, 51, 890, DateTimeKind.Utc).AddTicks(2646) });

            migrationBuilder.UpdateData(
                table: "Items",
                keyColumn: "Id",
                keyValue: new Guid("ea9141c8-8c5b-4126-9a30-7a82796e922c"),
                columns: new[] { "AddedOn", "ModifiedOn" },
                values: new object[] { new DateTime(2023, 9, 27, 21, 3, 51, 890, DateTimeKind.Utc).AddTicks(2862), new DateTime(2023, 9, 27, 21, 3, 51, 890, DateTimeKind.Utc).AddTicks(2863) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "SellerPhone",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SellerName",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "SellerEmail",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BuyerPhone",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BuyerName",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "BuyerEmail",
                table: "Contracts",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200,
                oldNullable: true);

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
    }
}
