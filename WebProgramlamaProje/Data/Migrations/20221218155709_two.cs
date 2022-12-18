using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProgramlamaProje.Data.Migrations
{
    public partial class two : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "KullaniciTypelar",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciTypelar", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Oyuncular",
                columns: table => new
                {
                    OyuncuID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OyuncuAd = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oyuncular", x => x.OyuncuID);
                });

            migrationBuilder.CreateTable(
                name: "Yonetmenler",
                columns: table => new
                {
                    YonetmenID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YonetmenAd = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Yonetmenler", x => x.YonetmenID);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    KullaniciID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<int>(type: "int", nullable: false),
                    KullaniciTypeID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.KullaniciID);
                    table.ForeignKey(
                        name: "FK_Kullanicilar_KullaniciTypelar_KullaniciTypeID",
                        column: x => x.KullaniciTypeID,
                        principalTable: "KullaniciTypelar",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Filmler",
                columns: table => new
                {
                    FilmID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmAd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FilmPuan = table.Column<float>(type: "real", nullable: false),
                    YonetmenID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filmler", x => x.FilmID);
                    table.ForeignKey(
                        name: "FK_Filmler_Yonetmenler_YonetmenID",
                        column: x => x.YonetmenID,
                        principalTable: "Yonetmenler",
                        principalColumn: "YonetmenID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FilmOyuncu",
                columns: table => new
                {
                    FilmlerFilmID = table.Column<int>(type: "int", nullable: false),
                    OyuncularOyuncuID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmOyuncu", x => new { x.FilmlerFilmID, x.OyuncularOyuncuID });
                    table.ForeignKey(
                        name: "FK_FilmOyuncu_Filmler_FilmlerFilmID",
                        column: x => x.FilmlerFilmID,
                        principalTable: "Filmler",
                        principalColumn: "FilmID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmOyuncu_Oyuncular_OyuncularOyuncuID",
                        column: x => x.OyuncularOyuncuID,
                        principalTable: "Oyuncular",
                        principalColumn: "OyuncuID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KullaniciPuanlar",
                columns: table => new
                {
                    KullaniciPuanID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciID = table.Column<int>(type: "int", nullable: false),
                    FilmID = table.Column<int>(type: "int", nullable: false),
                    Puan = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KullaniciPuanlar", x => x.KullaniciPuanID);
                    table.ForeignKey(
                        name: "FK_KullaniciPuanlar_Filmler_FilmID",
                        column: x => x.FilmID,
                        principalTable: "Filmler",
                        principalColumn: "FilmID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_KullaniciPuanlar_Kullanicilar_KullaniciID",
                        column: x => x.KullaniciID,
                        principalTable: "Kullanicilar",
                        principalColumn: "KullaniciID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filmler_YonetmenID",
                table: "Filmler",
                column: "YonetmenID");

            migrationBuilder.CreateIndex(
                name: "IX_FilmOyuncu_OyuncularOyuncuID",
                table: "FilmOyuncu",
                column: "OyuncularOyuncuID");

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_KullaniciTypeID",
                table: "Kullanicilar",
                column: "KullaniciTypeID");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciPuanlar_FilmID",
                table: "KullaniciPuanlar",
                column: "FilmID");

            migrationBuilder.CreateIndex(
                name: "IX_KullaniciPuanlar_KullaniciID",
                table: "KullaniciPuanlar",
                column: "KullaniciID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmOyuncu");

            migrationBuilder.DropTable(
                name: "KullaniciPuanlar");

            migrationBuilder.DropTable(
                name: "Oyuncular");

            migrationBuilder.DropTable(
                name: "Filmler");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "Yonetmenler");

            migrationBuilder.DropTable(
                name: "KullaniciTypelar");
        }
    }
}
