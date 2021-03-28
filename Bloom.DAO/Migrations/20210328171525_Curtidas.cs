using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bloom.DAO.Migrations
{
    public partial class Curtidas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Curtida",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false),
                    FilmeId = table.Column<Guid>(nullable: true),
                    SerieId = table.Column<Guid>(nullable: true),
                    LivroId = table.Column<Guid>(nullable: true),
                    TipoAvaliacao = table.Column<string>(nullable: false, defaultValue: "Filme")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curtida", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Curtida");
        }
    }
}
