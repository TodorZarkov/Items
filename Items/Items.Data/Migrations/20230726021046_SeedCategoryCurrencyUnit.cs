using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Items.Data.Migrations
{
    public partial class SeedCategoryCurrencyUnit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatorId", "Name" },
                values: new object[,]
                {
                    { 1, new Guid("04023b09-a38e-48e1-1082-08db8d0db110"), "Various" },
                    { 2, new Guid("04023b09-a38e-48e1-1082-08db8d0db110"), "Toys" },
                    { 3, new Guid("04023b09-a38e-48e1-1082-08db8d0db110"), "Cars" },
                    { 4, new Guid("04023b09-a38e-48e1-1082-08db8d0db110"), "Weapons" },
                    { 5, new Guid("04023b09-a38e-48e1-1082-08db8d0db110"), "Puzzles" }
                });

            migrationBuilder.InsertData(
                table: "Currencies",
                columns: new[] { "Id", "IsoCode", "Name", "Symbol" },
                values: new object[,]
                {
                    { 1, "USD", "United States dollar", "$" },
                    { 2, "EUR", "Euro", "€" },
                    { 3, "BGN", "Bulgarian lev", "Lev" }
                });

            migrationBuilder.InsertData(
                table: "Units",
                columns: new[] { "Id", "Name", "Symbol" },
                values: new object[,]
                {
                    { 1, "Pieces", "pcs" },
                    { 2, "Meter", "m" },
                    { 3, "Square Meter", "m2" },
                    { 4, "Kilogram", "kg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Currencies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Units",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
