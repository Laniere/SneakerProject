using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SneakerServer.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedSneakerModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Collaboration",
                table: "Sneakers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ColorWay",
                table: "Sneakers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ProductDescription",
                table: "Sneakers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "ReleaseYear",
                table: "Sneakers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<decimal>(
                name: "RetailPrice",
                table: "Sneakers",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Collaboration",
                table: "Sneakers");

            migrationBuilder.DropColumn(
                name: "ColorWay",
                table: "Sneakers");

            migrationBuilder.DropColumn(
                name: "ProductDescription",
                table: "Sneakers");

            migrationBuilder.DropColumn(
                name: "ReleaseYear",
                table: "Sneakers");

            migrationBuilder.DropColumn(
                name: "RetailPrice",
                table: "Sneakers");
        }
    }
}
