using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SneakerServer.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Brands",
                columns: table => new
                {
                    BrandId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brands", x => x.BrandId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LastAccess = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Birthday = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StreetAddress_Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetAddress_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetAddress_State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sneakers",
                columns: table => new
                {
                    SneakerId = table.Column<int>(type: "int", nullable: false),
                    Model = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BrandId = table.Column<int>(type: "int", nullable: false),
                    Collaboration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RetailPrice = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    ReleaseYear = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ColorWay = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProductDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PrimaryKey_SneakerId", x => x.SneakerId);
                    table.ForeignKey(
                        name: "FK_Sneakers_Brands_SneakerId",
                        column: x => x.SneakerId,
                        principalTable: "Brands",
                        principalColumn: "BrandId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "BrandId", "Name" },
                values: new object[,]
                {
                    { 1, "361 Degrees" },
                    { 2, "A.S.O" },
                    { 3, "Abaeté (clothing)" },
                    { 4, "ABC-Mart" },
                    { 5, "Adidas" },
                    { 6, "Airness" },
                    { 7, "Alden Shoe Company" },
                    { 8, "Allen Edmonds" },
                    { 9, "Alpinestars" },
                    { 10, "Ari Football" },
                    { 11, "Ariat" },
                    { 12, "Asics" },
                    { 13, "Atoms (shoes)" },
                    { 14, "Aubercy" },
                    { 15, "Avia (shoes)" },
                    { 16, "Baldinini" },
                    { 17, "Bally (fashion house)" },
                    { 18, "Banana Republic" },
                    { 19, "Bata Corporation" },
                    { 20, "Bearpaw (brand)" },
                    { 21, "Belle International" },
                    { 22, "Stefano Bemer" },
                    { 23, "Bettanin & Venturi" },
                    { 24, "Birkenstock" },
                    { 25, "Blackstock & Weber" },
                    { 26, "Bontoni" },
                    { 27, "Bucketfeet" },
                    { 28, "Caleres" },
                    { 29, "Calvin Klein (fashion house)" },
                    { 30, "Calzaturificio fratelli soldini" },
                    { 31, "Camper (company)" },
                    { 32, "Cariuma" },
                    { 33, "Caterpillar Inc." },
                    { 34, "Chaco (footwear)" },
                    { 35, "Charles David (company)" },
                    { 36, "Church's" },
                    { 37, "Circa (company)" },
                    { 38, "Colchester Rubber Co." },
                    { 39, "Cole Haan" },
                    { 40, "Columbia Montrail" },
                    { 41, "Columbia Sportswear" },
                    { 42, "Common Projects" },
                    { 43, "Crocs" },
                    { 44, "DC Shoes" },
                    { 45, "Mohamed Dia" },
                    { 46, "Diadora" },
                    { 47, "Dr. Kong (brand)" },
                    { 48, "Dr. Martens" },
                    { 49, "Duarig" },
                    { 50, "Dune London" },
                    { 51, "Dunlop Sport (Australia)" },
                    { 52, "DVS Shoes" },
                    { 53, "EbLens" },
                    { 54, "ECCO" },
                    { 55, "Ed Meier" },
                    { 56, "Edward Green & Co." },
                    { 57, "EMU Australia" },
                    { 58, "Erreà" },
                    { 59, "Etnies" },
                    { 60, "Falc" },
                    { 61, "Fallen Footwear" },
                    { 62, "Famolare" },
                    { 63, "FBT (company)" },
                    { 64, "FEIT" },
                    { 65, "Feiyue" },
                    { 66, "Fila" },
                    { 67, "John Fluevog" },
                    { 68, "Foot Locker" },
                    { 69, "Foreva" },
                    { 70, "Geox" },
                    { 71, "Givova" },
                    { 72, "Globe International" },
                    { 73, "Golden Goose (company)" },
                    { 74, "Goldstar shoes" },
                    { 75, "Goodwill Shoe Company" },
                    { 76, "Grand Sport Group" },
                    { 77, "Gravati" },
                    { 78, "Grendene" },
                    { 79, "Hanes Australasia" },
                    { 80, "Hanwag" },
                    { 81, "Havaianas" },
                    { 82, "Heelys" },
                    { 83, "Herbert Levine (company)" },
                    { 84, "Hi-Tec" },
                    { 85, "Hoka One One" },
                    { 86, "Humanic" },
                    { 87, "The Hundreds" },
                    { 88, "Hunter Boot Ltd" },
                    { 89, "Hush Puppies" },
                    { 90, "Inch2" },
                    { 91, "Insolia" },
                    { 92, "Invicta (company)" },
                    { 93, "IPath Footwear" },
                    { 94, "Irregular Choice" },
                    { 95, "Jello Shoecompany" },
                    { 96, "Jogarbola" },
                    { 97, "Johnston & Murphy" },
                    { 98, "Joma" },
                    { 99, "Journeys (company)" },
                    { 100, "K-Swiss" },
                    { 101, "KangaRoos" },
                    { 102, "Kappa (brand)" },
                    { 103, "Keds" },
                    { 104, "Kickers (brand)" },
                    { 105, "Kinney Shoes" },
                    { 106, "Koyo Bear" },
                    { 107, "Kubba Sportswear" },
                    { 108, "Kustom (footwear)" },
                    { 109, "La New" },
                    { 110, "La Sportiva" },
                    { 111, "Leder und Schuh" },
                    { 112, "Legea" },
                    { 113, "Li-Ning" },
                    { 114, "Loake" },
                    { 115, "John Lobb Bootmaker" },
                    { 116, "Lotto Sport Italia" },
                    { 117, "Lugz" },
                    { 118, "Luigi Voltan" },
                    { 119, "Steve Madden, Ltd." },
                    { 120, "Melville Shoe Corporation" },
                    { 121, "Merrell (company)" },
                    { 122, "Mills (sports brand)" },
                    { 123, "Moon Boot" },
                    { 124, "Muji" },
                    { 125, "Munich (sport shoes)" },
                    { 126, "Naot" },
                    { 127, "New Balance" },
                    { 128, "Nike, Inc." },
                    { 129, "Nocona Boots" },
                    { 130, "Vanessa Noel" },
                    { 131, "Northwave" },
                    { 132, "The Original Car Shoe" },
                    { 133, "Original Penguin" },
                    { 134, "Ortuseight" },
                    { 135, "Osiris Shoes" },
                    { 136, "Panam (brand)" },
                    { 137, "Pearl Izumi" },
                    { 138, "Pediped Footwear" },
                    { 139, "PF Flyers" },
                    { 140, "R. M. Williams (company)" },
                    { 141, "Real United" },
                    { 142, "Red or Dead" },
                    { 143, "Reebok Ventilator" },
                    { 144, "Reef (company)" },
                    { 145, "Rockport (company)" },
                    { 146, "Template:Running shoe brands" },
                    { 147, "Russell & Bromley" },
                    { 148, "Samuel Hubbard Shoe Company" },
                    { 149, "Sanders & Sanders Ltd." },
                    { 150, "SAS (shoemakers)" },
                    { 151, "Sebago (company)" },
                    { 152, "Sergio Rossi" },
                    { 153, "Sessions (clothing company)" },
                    { 154, "Daniella Shevel" },
                    { 155, "ShoeDazzle" },
                    { 156, "Shy (company)" },
                    { 157, "Sidi (company)" },
                    { 158, "Simod" },
                    { 159, "Skechers" },
                    { 160, "SLAM (clothing)" },
                    { 161, "Paul Smith (fashion designer)" },
                    { 162, "Solovair" },
                    { 163, "Sorel (brand)" },
                    { 164, "Source Vagabond Systems" },
                    { 165, "Source Sandals" },
                    { 166, "Start-rite" },
                    { 167, "Superga (brand)" },
                    { 168, "Tecovas (company)" },
                    { 169, "Thom McAn" },
                    { 170, "Tod's" },
                    { 171, "Tom Ford (brand)" },
                    { 172, "Toms Shoes" },
                    { 173, "Tredair" },
                    { 174, "Tricker's" },
                    { 175, "Troentorp Clogs" },
                    { 176, "UGG (brand)" },
                    { 177, "Unification Shoes" },
                    { 178, "United Nude" },
                    { 179, "Vans" },
                    { 180, "Veja (brand)" },
                    { 181, "Veldskoen Shoes" },
                    { 182, "Veritas Bespoke" },
                    { 183, "Vibram" },
                    { 184, "Volley (shoe)" },
                    { 185, "Walk-Over shoes" },
                    { 186, "Warrix Sports" },
                    { 187, "Stuart Weitzman" },
                    { 188, "J. M. Weston" },
                    { 189, "Wildsmith Shoes" },
                    { 190, "World Balance" },
                    { 191, "Xtep" },
                    { 192, "Yohji Yamamoto" },
                    { 193, "Yull Shoes" },
                    { 194, "Giuseppe Zanotti" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Sneakers_Model",
                table: "Sneakers",
                column: "Model");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "Users",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserName",
                table: "Users",
                column: "UserName");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "Users",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Sneakers");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Brands");
        }
    }
}
