using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Items.Data.Migrations
{
    public partial class datesAndSeverityToTicket : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                table: "Tickets",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Severity",
                table: "Tickets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Modified",
                table: "Tickets");

            migrationBuilder.DropColumn(
                name: "Severity",
                table: "Tickets");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("04023b09-a38e-48e1-1082-08db8d0db110"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEBYOtxhQSkHEK8ilHPj/BPspgNwZNylwdiF9OEjgDPbkZdlseyaUuNBZGSvnl/cOaQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7bee3220-a1a1-4502-efea-08db9037bc59"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEM5DCWFX9a72xcWlS/yd+P7FFx70kTG2sfBxkVVOxHZWyUuaEB26AlmLRLhDb1S44A==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8b5b3b04-bf70-4018-ffbf-08db913996c1"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEKpF3UNfF3DYutA5T/xEctD4qSl8yurfvYF5fPRkpQ9fPI3lY5km3oBddnmnpz7T8Q==");
        }
    }
}
