using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Items.Data.Migrations
{
    public partial class ModifyContractRemoveUserContract : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UsersContracts");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_BuyerId",
                table: "Contracts",
                column: "BuyerId");

            migrationBuilder.CreateIndex(
                name: "IX_Contracts_SellerId",
                table: "Contracts",
                column: "SellerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_AspNetUsers_BuyerId",
                table: "Contracts",
                column: "BuyerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contracts_AspNetUsers_SellerId",
                table: "Contracts",
                column: "SellerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_AspNetUsers_BuyerId",
                table: "Contracts");

            migrationBuilder.DropForeignKey(
                name: "FK_Contracts_AspNetUsers_SellerId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_BuyerId",
                table: "Contracts");

            migrationBuilder.DropIndex(
                name: "IX_Contracts_SellerId",
                table: "Contracts");

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
                name: "IX_UsersContracts_ContractId",
                table: "UsersContracts",
                column: "ContractId");
        }
    }
}
