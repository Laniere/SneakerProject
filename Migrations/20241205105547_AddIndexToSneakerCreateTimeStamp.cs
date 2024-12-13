using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SneakerServer.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexToSneakerCreateTimeStamp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Sneakers",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Sneakers_Model",
                table: "Sneakers",
                column: "Model");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Sneakers_Model",
                table: "Sneakers");

            migrationBuilder.AlterColumn<string>(
                name: "Model",
                table: "Sneakers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");
        }
    }
}
