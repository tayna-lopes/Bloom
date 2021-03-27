using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bloom.DAO.Migrations
{
    public partial class Tabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filme_Usuario_UsuarioId",
                table: "Filme");

            migrationBuilder.DropColumn(
                name: "CriadorId",
                table: "Filme");

            migrationBuilder.AlterColumn<Guid>(
                name: "UsuarioId",
                table: "Filme",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Classificacao",
                table: "Filme",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.CreateTable(
                name: "Amizade",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ConvidanteId = table.Column<Guid>(nullable: false),
                    ConvidadoId = table.Column<Guid>(nullable: false),
                    Status = table.Column<string>(nullable: false, defaultValue: "Pendente")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Amizade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Avaliacao",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Texto = table.Column<string>(nullable: true),
                    Classificacao = table.Column<int>(nullable: false),
                    UsuarioId = table.Column<Guid>(nullable: false),
                    FilmeId = table.Column<Guid>(nullable: true),
                    SerieId = table.Column<Guid>(nullable: true),
                    LivroId = table.Column<Guid>(nullable: true),
                    TipoAvaliacao = table.Column<string>(nullable: false, defaultValue: "Filme")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Avaliacao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comentario",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Texto = table.Column<string>(nullable: true),
                    UsuarioId = table.Column<Guid>(nullable: false),
                    FilmeId = table.Column<Guid>(nullable: true),
                    SerieId = table.Column<Guid>(nullable: true),
                    LivroId = table.Column<Guid>(nullable: true),
                    TipoAvaliacao = table.Column<string>(nullable: false, defaultValue: "Filme")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Livro",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Autores = table.Column<string>(nullable: true),
                    Titulo = table.Column<string>(nullable: true),
                    Editora = table.Column<string>(nullable: true),
                    Pais = table.Column<string>(nullable: true),
                    Ano = table.Column<int>(nullable: false),
                    Classificacao = table.Column<double>(nullable: false),
                    Genero = table.Column<string>(nullable: false, defaultValue: "Aventura"),
                    UsuarioId = table.Column<Guid>(nullable: false),
                    Status = table.Column<string>(nullable: false, defaultValue: "Pendente")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Livro_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Serie",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Diretor = table.Column<string>(nullable: true),
                    Titulo = table.Column<string>(nullable: true),
                    Elenco = table.Column<string>(nullable: true),
                    Pais = table.Column<string>(nullable: true),
                    Ano = table.Column<int>(nullable: false),
                    Classificacao = table.Column<double>(nullable: false),
                    NumeroDeTemporadas = table.Column<int>(nullable: false),
                    Genero = table.Column<string>(nullable: false, defaultValue: "Aventura"),
                    UsuarioId = table.Column<Guid>(nullable: false),
                    Status = table.Column<string>(nullable: false, defaultValue: "Pendente")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Serie", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Serie_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "UsuarioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Livro_UsuarioId",
                table: "Livro",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Serie_UsuarioId",
                table: "Serie",
                column: "UsuarioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Filme_Usuario_UsuarioId",
                table: "Filme",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Filme_Usuario_UsuarioId",
                table: "Filme");

            migrationBuilder.DropTable(
                name: "Amizade");

            migrationBuilder.DropTable(
                name: "Avaliacao");

            migrationBuilder.DropTable(
                name: "Comentario");

            migrationBuilder.DropTable(
                name: "Livro");

            migrationBuilder.DropTable(
                name: "Serie");

            migrationBuilder.AlterColumn<Guid>(
                name: "UsuarioId",
                table: "Filme",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<int>(
                name: "Classificacao",
                table: "Filme",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<Guid>(
                name: "CriadorId",
                table: "Filme",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Filme_Usuario_UsuarioId",
                table: "Filme",
                column: "UsuarioId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
