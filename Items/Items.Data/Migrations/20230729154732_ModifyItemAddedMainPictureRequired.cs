using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Items.Data.Migrations
{
    public partial class ModifyItemAddedMainPictureRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Pictures_MainPictureId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_MainPictureId",
                table: "Items");

            migrationBuilder.AlterColumn<Guid>(
                name: "MainPictureId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Items_MainPictureId",
                table: "Items",
                column: "MainPictureId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Items_Pictures_MainPictureId",
                table: "Items",
                column: "MainPictureId",
                principalTable: "Pictures",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Items_Pictures_MainPictureId",
                table: "Items");

            migrationBuilder.DropIndex(
                name: "IX_Items_MainPictureId",
                table: "Items");

            migrationBuilder.AlterColumn<Guid>(
                name: "MainPictureId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

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
    }
}
