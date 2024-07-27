using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Items.Data.Migrations
{
    public partial class _2TicketsUsersTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Symbol",
                table: "Units",
                type: "nvarchar(90)",
                maxLength: 90,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Units",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "SimilarTicketsUsers",
                columns: table => new
                {
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SimilarTicketsUsers", x => new { x.TicketId, x.UserId });
                    table.ForeignKey(
                        name: "FK_SimilarTicketsUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SimilarTicketsUsers_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TicketsSubscribers",
                columns: table => new
                {
                    TicketId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SubscriberId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketsSubscribers", x => new { x.TicketId, x.SubscriberId });
                    table.ForeignKey(
                        name: "FK_TicketsSubscribers_AspNetUsers_SubscriberId",
                        column: x => x.SubscriberId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TicketsSubscribers_Tickets_TicketId",
                        column: x => x.TicketId,
                        principalTable: "Tickets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "TicketTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 4, "NewUnit" });

            migrationBuilder.CreateIndex(
                name: "IX_SimilarTicketsUsers_UserId",
                table: "SimilarTicketsUsers",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketsSubscribers_SubscriberId",
                table: "TicketsSubscribers",
                column: "SubscriberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SimilarTicketsUsers");

            migrationBuilder.DropTable(
                name: "TicketsSubscribers");

            migrationBuilder.DeleteData(
                table: "TicketTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.AlterColumn<string>(
                name: "Symbol",
                table: "Units",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(90)",
                oldMaxLength: 90);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Units",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("04023b09-a38e-48e1-1082-08db8d0db110"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEG+3/Gd96ndyGr5ByDTdX8/HfcOMDVgOwuiIqq0xHQ9d/7UY8zfOd3GAYUpdsu19tQ==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("7bee3220-a1a1-4502-efea-08db9037bc59"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEMSPWmwqz1Ym1DPghW5UB/P1clmz9wt+qLRHyYnFleTrXvgqAdOOwAVxpWKj2+Sudg==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("8b5b3b04-bf70-4018-ffbf-08db913996c1"),
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEFtrjKOXwXUPIjJQDhD2UapPQ4fA7g6r1s/68GQ6dCkB68j2kKqNRcmbC4/gYT4O2g==");
        }
    }
}
