using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace kuaforsalonu.Migrations
{
    /// <inheritdoc />
    public partial class Salonlar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SalonId",
                table: "Çalışanlar",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Salonlar",
                columns: table => new
                {
                    SalonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ad = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Adres = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CalismaSaatleri = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salonlar", x => x.SalonId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Çalışanlar_SalonId",
                table: "Çalışanlar",
                column: "SalonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Çalışanlar_Salonlar_SalonId",
                table: "Çalışanlar",
                column: "SalonId",
                principalTable: "Salonlar",
                principalColumn: "SalonId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Çalışanlar_Salonlar_SalonId",
                table: "Çalışanlar");

            migrationBuilder.DropTable(
                name: "Salonlar");

            migrationBuilder.DropIndex(
                name: "IX_Çalışanlar_SalonId",
                table: "Çalışanlar");

            migrationBuilder.DropColumn(
                name: "SalonId",
                table: "Çalışanlar");
        }
    }
}
