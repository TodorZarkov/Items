using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Items.Data.Migrations
{
    public partial class ModifyItemAddedMainPicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsMain",
                table: "Pictures");

            migrationBuilder.AddColumn<Guid>(
                name: "MainPictureId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_MainPictureId",
                table: "Items",
                column: "MainPictureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Pictures_MainPictureId",
                table: "Items",
                column: "MainPictureId",
                principalTable: "Pictures",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Pictures_MainPictureId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_MainPictureId",
                table: "Items");

            migrationBuilder.DropColumn(
                name: "MainPictureId",
                table: "Items");

            migrationBuilder.AddColumn<bool>(
                name: "IsMain",
                table: "Pictures",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
