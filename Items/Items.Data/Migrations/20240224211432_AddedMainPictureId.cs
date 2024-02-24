using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Items.Data.Migrations
{
    public partial class AddedMainPictureId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "MainPictureId",
                table: "Items",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MainPictureId",
                table: "Items");

            
        }
    }
}
