using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SneakerServer.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9f6f24df-14dc-4602-8dd5-0916f794ae6f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ca6c85c5-240a-422e-8387-7f4b159f518e"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Birthday", "ConcurrencyStamp", "Email", "EmailConfirmed", "LastAccess", "LastName", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("2e376b4e-d236-45dc-ad3d-c59595b228e5"), 0, new DateTime(1989, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "1b06e71a-5120-4dd9-951b-9e115076e6c9", "alex4zanetti@hotmail.it", true, null, "Orvieto", false, null, "Alessio", "ALEX4ZANETTI@HOTMAIL.IT", null, null, "3458048190", true, null, false, "Laniere" },
                    { new Guid("6630f933-d653-446b-915d-d2ee7c93894a"), 0, null, "3ade2e5c-4a6a-4ce8-84d7-03c6fffd2fc0", "pippo@hotmail.it", false, null, "Franco", false, null, "Pippo", "PIPPO@HOTMAIL.IT", null, null, "3458048190", false, null, false, "PippoFranco" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2e376b4e-d236-45dc-ad3d-c59595b228e5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("6630f933-d653-446b-915d-d2ee7c93894a"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Birthday", "ConcurrencyStamp", "Email", "EmailConfirmed", "LastAccess", "LastName", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("9f6f24df-14dc-4602-8dd5-0916f794ae6f"), 0, null, "4ab1dd1d-55da-4b3f-869c-626334d263a5", "pippo@hotmail.it", false, null, "Franco", false, null, "Pippo", "PIPPO@HOTMAIL.IT", null, null, "3458048190", false, null, false, "PippoFranco" },
                    { new Guid("ca6c85c5-240a-422e-8387-7f4b159f518e"), 0, new DateTime(1989, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "b0b78b48-451f-4ebb-88b5-2615c684886d", "alex4zanetti@hotmail.it", true, null, "Orvieto", false, null, "Alessio", "ALEX4ZANETTI@HOTMAIL.IT", null, null, "3458048190", true, null, false, "Laniere" }
                });
        }
    }
}
