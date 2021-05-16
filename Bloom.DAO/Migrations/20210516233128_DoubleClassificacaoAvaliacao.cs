using Microsoft.EntityFrameworkCore.Migrations;

namespace Bloom.DAO.Migrations
{
    public partial class DoubleClassificacaoAvaliacao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Classificacao",
                table: "Avaliacao",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Classificacao",
                table: "Avaliacao",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
