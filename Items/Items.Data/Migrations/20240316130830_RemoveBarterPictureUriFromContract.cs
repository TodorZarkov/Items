using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Items.Data.Migrations
{
    public partial class RemoveBarterPictureUriFromContract : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BarterPictureUri",
                table: "Contracts");

            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BarterPictureUri",
                table: "Contracts",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: true);

           
        }
    }
}
