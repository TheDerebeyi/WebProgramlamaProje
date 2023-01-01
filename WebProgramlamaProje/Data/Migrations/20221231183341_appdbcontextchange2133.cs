using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProgramlamaProje.Data.Migrations
{
    public partial class appdbcontextchange2133 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FilmOyuncular",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FilmID = table.Column<int>(type: "int", nullable: false),
                    OyuncuID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmOyuncular", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FilmOyuncular_Filmler_FilmID",
                        column: x => x.FilmID,
                        principalTable: "Filmler",
                        principalColumn: "FilmID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FilmOyuncular_Oyuncular_OyuncuID",
                        column: x => x.OyuncuID,
                        principalTable: "Oyuncular",
                        principalColumn: "OyuncuID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FilmOyuncular_FilmID",
                table: "FilmOyuncular",
                column: "FilmID");

            migrationBuilder.CreateIndex(
                name: "IX_FilmOyuncular_OyuncuID",
                table: "FilmOyuncular",
                column: "OyuncuID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FilmOyuncular");
        }
    }
}
