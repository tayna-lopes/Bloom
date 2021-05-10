using Microsoft.EntityFrameworkCore.Migrations;

namespace Bloom.DAO.Migrations
{
    public partial class FotoEmMidias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Serie",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Livro",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Filme",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Serie");

            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Livro");

            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Filme");
        }
    }
}
