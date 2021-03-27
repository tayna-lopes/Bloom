using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bloom.DAO.Migrations
{
    public partial class FilmeMapping : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Filme",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Diretor = table.Column<string>(nullable: true),
                    Titulo = table.Column<string>(nullable: true),
                    Elenco = table.Column<string>(nullable: true),
                    Pais = table.Column<string>(nullable: true),
                    Ano = table.Column<int>(nullable: false),
                    Classificacao = table.Column<int>(nullable: false),
                    Genero = table.Column<string>(nullable: false, defaultValue: "Aventura"),
                    CriadorId = table.Column<Guid>(nullable: false),
                    Status = table.Column<string>(nullable: false, defaultValue: "Pendente"),
                    UsuarioId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filme", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Filme_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Filme_UsuarioId",
                table: "Filme",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Filme");
        }
    }
}
