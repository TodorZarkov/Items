using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Items.Data.Migrations
{
    public partial class seedAdminRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[]
                    { new Guid("07ebfa14-da6f-471f-a29a-c3232eb436c9"), "F4C41BE7-D11A-4DE4-99FB-7C8C0C8C3A26", "Admin", "ADMIN" }
                );

           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("07ebfa14-da6f-471f-a29a-c3232eb436c9"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("b8e078af-5cbc-4360-a99a-0aa387c563e1"));

            
        }
    }
}
