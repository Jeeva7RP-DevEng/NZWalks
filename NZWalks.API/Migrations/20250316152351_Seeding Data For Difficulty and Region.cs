using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataForDifficultyandRegion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("a054baf8-4de8-4a8c-b6eb-e9b4fe0d661e"), "Auckland" },
                    { new Guid("ada6443c-2f08-4489-adb6-76557c061c3e"), "Wellington" },
                    { new Guid("b187c163-b4a2-42ed-b9ae-9fa226cfb0b6"), "Taranaki" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("19253ec9-fa58-4852-8e93-0bc0d15755ff"), "TNK", "Taranaki", "https://example.com/Taranaki.jpg" },
                    { new Guid("21637126-6aaa-48c6-8219-c2dfbc2c8bc5"), "WLG", "Wellington", "https://example.com/wellington.jpg" },
                    { new Guid("c3a31227-3567-4cc7-a0a5-4e21d9dc3e1b"), "AKL", "Auckland", "https://example.com/auckland.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("a054baf8-4de8-4a8c-b6eb-e9b4fe0d661e"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("ada6443c-2f08-4489-adb6-76557c061c3e"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("b187c163-b4a2-42ed-b9ae-9fa226cfb0b6"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("19253ec9-fa58-4852-8e93-0bc0d15755ff"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("21637126-6aaa-48c6-8219-c2dfbc2c8bc5"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("c3a31227-3567-4cc7-a0a5-4e21d9dc3e1b"));
        }
    }
}
