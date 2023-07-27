using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Items.Data.Migrations
{
    public partial class AddedContract : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Quantity",
                table: "Offers",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "AddedOn",
                table: "ItemVisibilities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "CurrentPrice",
                table: "ItemVisibilities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedOn",
                table: "Items",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "CurrentPrice",
                table: "Items",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndSell",
                table: "Items",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartSell",
                table: "Items",
                type: "datetime2",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BuyerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SellerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    CurrencyId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<decimal>(type: "decimal(18,6)", precision: 18, scale: 6, nullable: false),
                    SendDue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeliverDue = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContractDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SellerOk = table.Column<bool>(type: "bit", nullable: false),
                    BuyerOk = table.Column<bool>(type: "bit", nullable: false),
                    Fulfilled = table.Column<bool>(type: "bit", nullable: false),
                    SellerComment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    BuyerComment = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    BuyerConfirm = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contracts_Currencies_CurrencyId",
                        column: x => x.CurrencyId,
                        principalTable: "Currencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsersContracts",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ContractId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersContracts", x => new { x.UserId, x.ContractId });
                    table.ForeignKey(
                        name: "FK_UsersContracts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsersContracts_Contracts_ContractId",
                        column: x => x.ContractId,
                        principalTable: "Contracts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_CurrencyId",
                table: "Contracts",
                column: "CurrencyId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersContracts_ContractId",
                table: "UsersContracts",
                column: "ContractId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersContracts");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "AddedOn",
                table: "ItemVisibilities");

            migrationBuilder.DropColumn(
                name: "CurrentPrice",
                table: "ItemVisibilities");

            migrationBuilder.DropColumn(
                name: "AddedOn",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "CurrentPrice",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "EndSell",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "StartSell",
                table: "Items");
        }
    }
}
