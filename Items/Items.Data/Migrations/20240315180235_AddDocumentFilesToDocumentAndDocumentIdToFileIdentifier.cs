using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Items.Data.Migrations
{
    public partial class AddDocumentFilesToDocumentAndDocumentIdToFileIdentifier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Uri",
                table: "Documents");

            migrationBuilder.AddColumn<Guid>(
                name: "DocumentId",
                table: "FileIdentifiers",
                type: "uniqueidentifier",
                nullable: true);


            migrationBuilder.CreateIndex(
                name: "IX_FileIdentifiers_DocumentId",
                table: "FileIdentifiers",
                column: "DocumentId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileIdentifiers_Documents_DocumentId",
                table: "FileIdentifiers",
                column: "DocumentId",
                principalTable: "Documents",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileIdentifiers_Documents_DocumentId",
                table: "FileIdentifiers");

            migrationBuilder.DropIndex(
                name: "IX_FileIdentifiers_DocumentId",
                table: "FileIdentifiers");

            migrationBuilder.DropColumn(
                name: "DocumentId",
                table: "FileIdentifiers");

            migrationBuilder.AddColumn<string>(
                name: "Uri",
                table: "Documents",
                type: "nvarchar(2048)",
                maxLength: 2048,
                nullable: false,
                defaultValue: "");

           
        }
    }
}
