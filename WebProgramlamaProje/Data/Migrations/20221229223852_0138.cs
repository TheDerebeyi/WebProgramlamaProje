using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebProgramlamaProje.Data.Migrations
{
    public partial class _0138 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KullaniciPuanlar_AspNetUsers_KullaniciId",
                table: "KullaniciPuanlar");

            migrationBuilder.RenameColumn(
                name: "KullaniciId",
                table: "KullaniciPuanlar",
                newName: "KullaniciID");

            migrationBuilder.RenameIndex(
                name: "IX_KullaniciPuanlar_KullaniciId",
                table: "KullaniciPuanlar",
                newName: "IX_KullaniciPuanlar_KullaniciID");

            migrationBuilder.AlterColumn<string>(
                name: "KullaniciID",
                table: "KullaniciPuanlar",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_KullaniciPuanlar_AspNetUsers_KullaniciID",
                table: "KullaniciPuanlar",
                column: "KullaniciID",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_KullaniciPuanlar_AspNetUsers_KullaniciID",
                table: "KullaniciPuanlar");

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
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddForeignKey(
                name: "FK_KullaniciPuanlar_AspNetUsers_KullaniciId",
                table: "KullaniciPuanlar",
                column: "KullaniciId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
