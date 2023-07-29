using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Items.Data.Migrations
{
    public partial class ModifyItemAddedIsAuction : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "ItemVisibilities");

            migrationBuilder.AddColumn<bool>(
                name: "IsAuction",
                table: "Items",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsAuction",
                table: "Items");

            migrationBuilder.AddColumn<int>(
                name: "Name",
                table: "ItemVisibilities",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
