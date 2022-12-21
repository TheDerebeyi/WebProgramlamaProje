using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProgramlamaProje.Data.Migrations
{
    public partial class kullanici : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KullaniciPuanlar_Kullanicilar_KullaniciID",
                table: "KullaniciPuanlar");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "KullaniciTypelar");

            migrationBuilder.RenameColumn(
                name: "KullaniciID",
                table: "KullaniciPuanlar",
                newName: "KullaniciId");

            migrationBuilder.RenameIndex(
                name: "IX_KullaniciPuanlar_KullaniciID",
                table: "KullaniciPuanlar",
                newName: "IX_KullaniciPuanlar_KullaniciId");

            migrationBuilder.AlterColumn<string>(
                name: "KullaniciId",
                table: "KullaniciPuanlar",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Ad",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Soyad",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_KullaniciPuanlar_AspNetUsers_KullaniciId",
                table: "KullaniciPuanlar",
                column: "KullaniciId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KullaniciPuanlar_AspNetUsers_KullaniciId",
                table: "KullaniciPuanlar");

            migrationBuilder.DropColumn(
                name: "Ad",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Soyad",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "KullaniciId",
                table: "KullaniciPuanlar",
                newName: "KullaniciID");

            migrationBuilder.RenameIndex(
                name: "IX_KullaniciPuanlar_KullaniciId",
                table: "KullaniciPuanlar",
                newName: "IX_KullaniciPuanlar_KullaniciID");

            migrationBuilder.AlterColumn<int>(
                name: "KullaniciID",
                table: "KullaniciPuanlar",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

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
                name: "Kullanicilar",
                columns: table => new
                {
                    KullaniciID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KullaniciTypeID = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<int>(type: "int", nullable: false),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_Kullanicilar_KullaniciTypeID",
                table: "Kullanicilar",
                column: "KullaniciTypeID");

            migrationBuilder.AddForeignKey(
                name: "FK_KullaniciPuanlar_Kullanicilar_KullaniciID",
                table: "KullaniciPuanlar",
                column: "KullaniciID",
                principalTable: "Kullanicilar",
                principalColumn: "KullaniciID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
