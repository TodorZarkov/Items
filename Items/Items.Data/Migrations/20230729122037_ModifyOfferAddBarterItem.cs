using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Items.Data.Migrations
{
    public partial class ModifyOfferAddBarterItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BarterItemId",
                table: "Offers",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "BarterQuantity",
                table: "Offers",
                type: "decimal(18,6)",
                precision: 18,
                scale: 6,
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Offers_BarterItemId",
                table: "Offers",
                column: "BarterItemId");

            migrationBuilder.AddForeignKey(
                name: "FK_Offers_Items_BarterItemId",
                table: "Offers",
                column: "BarterItemId",
                principalTable: "Items",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Offers_Items_BarterItemId",
                table: "Offers");

            migrationBuilder.DropIndex(
                name: "IX_Offers_BarterItemId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "BarterItemId",
                table: "Offers");

            migrationBuilder.DropColumn(
                name: "BarterQuantity",
                table: "Offers");
        }
    }
}
