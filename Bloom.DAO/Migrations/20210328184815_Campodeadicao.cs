using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bloom.DAO.Migrations
{
    public partial class Campodeadicao : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Adicionado",
                table: "Serie",
                nullable: false,
                defaultValue: new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Adicionado",
                table: "Livro",
                nullable: false,
                defaultValue: new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Adicionado",
                table: "Filme",
                nullable: false,
                defaultValue: new DateTime(2010, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Adicionado",
                table: "Serie");

            migrationBuilder.DropColumn(
                name: "Adicionado",
                table: "Livro");

            migrationBuilder.DropColumn(
                name: "Adicionado",
                table: "Filme");
        }
    }
}
