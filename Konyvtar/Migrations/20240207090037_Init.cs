using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Konyvtar.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Szerzo",
                columns: table => new
                {
                    szerzoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Keresztnev = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Vezeteknev = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Szerzo", x => x.szerzoID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tanulo",
                columns: table => new
                {
                    TanuloID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Keresztnev = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Vezeteknev = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SzulDatum = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    No = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Osztaly = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tanulo", x => x.TanuloID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tipus",
                columns: table => new
                {
                    TipusID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nev = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipus", x => x.TipusID);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Konyv",
                columns: table => new
                {
                    KonyvID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Cim = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Oldalszam = table.Column<int>(type: "int", nullable: true),
                    Pontszam = table.Column<int>(type: "int", nullable: true),
                    SzerzoID = table.Column<int>(type: "int", nullable: true),
                    TipusID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Konyv", x => x.KonyvID);
                    table.ForeignKey(
                        name: "FK_Konyv_Szerzo_SzerzoID",
                        column: x => x.SzerzoID,
                        principalTable: "Szerzo",
                        principalColumn: "szerzoID");
                    table.ForeignKey(
                        name: "FK_Konyv_Tipus_TipusID",
                        column: x => x.TipusID,
                        principalTable: "Tipus",
                        principalColumn: "TipusID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Kolcsonzes",
                columns: table => new
                {
                    KolcsonzesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TanuloID = table.Column<int>(type: "int", nullable: true),
                    KonyvID = table.Column<int>(type: "int", nullable: true),
                    Elvitel = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Visszahozas = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Visszahozta = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kolcsonzes", x => x.KolcsonzesID);
                    table.ForeignKey(
                        name: "FK_Kolcsonzes_Konyv_KonyvID",
                        column: x => x.KonyvID,
                        principalTable: "Konyv",
                        principalColumn: "KonyvID");
                    table.ForeignKey(
                        name: "FK_Kolcsonzes_Tanulo_TanuloID",
                        column: x => x.TanuloID,
                        principalTable: "Tanulo",
                        principalColumn: "TanuloID");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Szerzo",
                columns: new[] { "szerzoID", "Keresztnev", "Vezeteknev" },
                values: new object[,]
                {
                    { 1, "Isaac", "Asimov" },
                    { 2, "Dick", "Philip" },
                    { 3, "Géza", "Gárdonyi" }
                });

            migrationBuilder.InsertData(
                table: "Tipus",
                columns: new[] { "TipusID", "Nev" },
                values: new object[,]
                {
                    { 1, "Sci-Fi" },
                    { 2, "Fantasy" },
                    { 3, "Documentary" }
                });

            migrationBuilder.InsertData(
                table: "Konyv",
                columns: new[] { "KonyvID", "Cim", "Oldalszam", "Pontszam", "SzerzoID", "TipusID" },
                values: new object[,]
                {
                    { 1, "Ember a fellegvárban", 550, 9, 2, 1 },
                    { 2, "Egri Csillagok", 520, 6, 3, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Kolcsonzes_KonyvID",
                table: "Kolcsonzes",
                column: "KonyvID");

            migrationBuilder.CreateIndex(
                name: "IX_Kolcsonzes_TanuloID",
                table: "Kolcsonzes",
                column: "TanuloID");

            migrationBuilder.CreateIndex(
                name: "IX_Konyv_SzerzoID",
                table: "Konyv",
                column: "SzerzoID");

            migrationBuilder.CreateIndex(
                name: "IX_Konyv_TipusID",
                table: "Konyv",
                column: "TipusID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kolcsonzes");

            migrationBuilder.DropTable(
                name: "Konyv");

            migrationBuilder.DropTable(
                name: "Tanulo");

            migrationBuilder.DropTable(
                name: "Szerzo");

            migrationBuilder.DropTable(
                name: "Tipus");
        }
    }
}
