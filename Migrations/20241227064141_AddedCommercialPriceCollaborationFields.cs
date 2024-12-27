﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SneakerServer.Migrations
{
    /// <inheritdoc />
    public partial class AddedCommercialPriceCollaborationFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "CommercialPrice",
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
                name: "CommercialPrice",
                table: "Sneakers");
        }
    }
}