using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kuaforsalonu.Migrations
{
    /// <inheritdoc />
    public partial class InstallCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Çalışanlar",
                columns: table => new
                {
                    CalisanNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Uzmanlik = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Çalışanlar", x => x.CalisanNo);
                });

            migrationBuilder.CreateTable(
                name: "Saat",
                columns: table => new
                {
                    SaatID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Saat", x => x.SaatID);
                });

            migrationBuilder.CreateTable(
                name: "Yetki",
                columns: table => new
                {
                    YetkiNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YetkiAdı = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yetki", x => x.YetkiNo);
                });

            migrationBuilder.CreateTable(
                name: "Müşteriler",
                columns: table => new
                {
                    MusteriNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Soyadi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sifre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    YetkiNo = table.Column<int>(type: "int", nullable: false),
                    YetkiNo1 = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Müşteriler", x => x.MusteriNo);
                    table.ForeignKey(
                        name: "FK_Müşteriler_Yetki_YetkiNo1",
                        column: x => x.YetkiNo1,
                        principalTable: "Yetki",
                        principalColumn: "YetkiNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Randevular",
                columns: table => new
                {
                    RandevuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MusteriNo = table.Column<int>(type: "int", nullable: false),
                    CalisanNo = table.Column<int>(type: "int", nullable: false),
                    Tarih = table.Column<DateTime>(type: "date", nullable: false),
                    SaatID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Randevular", x => x.RandevuID);
                    table.ForeignKey(
                        name: "FK_Randevular_Müşteriler_MusteriNo",
                        column: x => x.MusteriNo,
                        principalTable: "Müşteriler",
                        principalColumn: "MusteriNo",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Randevular_Saat_SaatID",
                        column: x => x.SaatID,
                        principalTable: "Saat",
                        principalColumn: "SaatID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Randevular_Çalışanlar_CalisanNo",
                        column: x => x.CalisanNo,
                        principalTable: "Çalışanlar",
                        principalColumn: "CalisanNo",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Müşteriler_YetkiNo1",
                table: "Müşteriler",
                column: "YetkiNo1");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_CalisanNo",
                table: "Randevular",
                column: "CalisanNo");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_MusteriNo",
                table: "Randevular",
                column: "MusteriNo");

            migrationBuilder.CreateIndex(
                name: "IX_Randevular_SaatID",
                table: "Randevular",
                column: "SaatID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Randevular");

            migrationBuilder.DropTable(
                name: "Müşteriler");

            migrationBuilder.DropTable(
                name: "Saat");

            migrationBuilder.DropTable(
                name: "Çalışanlar");

            migrationBuilder.DropTable(
                name: "Yetki");
        }
    }
}
