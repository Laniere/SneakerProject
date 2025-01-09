using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SneakerServer.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedUserModel2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("3026a66a-e97b-4bae-9e7d-c71380969970"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f8c339e2-48cd-49b6-8de5-a57822eb268c"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Birthday", "ConcurrencyStamp", "Email", "EmailConfirmed", "LastAccess", "LastName", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("9f6f24df-14dc-4602-8dd5-0916f794ae6f"), 0, null, "4ab1dd1d-55da-4b3f-869c-626334d263a5", "pippo@hotmail.it", false, null, "Franco", false, null, "Pippo", "PIPPO@HOTMAIL.IT", null, null, "3458048190", false, null, false, "PippoFranco" },
                    { new Guid("ca6c85c5-240a-422e-8387-7f4b159f518e"), 0, new DateTime(1989, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "b0b78b48-451f-4ebb-88b5-2615c684886d", "alex4zanetti@hotmail.it", true, null, "Orvieto", false, null, "Alessio", "ALEX4ZANETTI@HOTMAIL.IT", null, null, "3458048190", true, null, false, "Laniere" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9f6f24df-14dc-4602-8dd5-0916f794ae6f"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ca6c85c5-240a-422e-8387-7f4b159f518e"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "AccessFailedCount", "Birthday", "ConcurrencyStamp", "Email", "EmailConfirmed", "LastAccess", "LastName", "LockoutEnabled", "LockoutEnd", "Name", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[,]
                {
                    { new Guid("3026a66a-e97b-4bae-9e7d-c71380969970"), 0, new DateTime(1989, 10, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "88f5a1c2-2f23-4918-b539-da592a1f64b8", "alex4zanetti@hotmail.it", true, null, "Orvieto", false, null, "Alessio", "ALEX4ZANETTI@HOTMAIL.IT", null, null, "3458048190", true, null, false, "Laniere" },
                    { new Guid("f8c339e2-48cd-49b6-8de5-a57822eb268c"), 0, null, "7ba843bb-6bd4-4823-9ecf-617d636cfcc2", "pippo@hotmail.it", false, null, "Franco", false, null, "Pippo", "PIPPO@HOTMAIL.IT", null, null, "3458048190", false, null, false, "PippoFranco" }
                });
        }
    }
}
