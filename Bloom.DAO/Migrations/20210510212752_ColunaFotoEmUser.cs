using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bloom.DAO.Migrations
{
    public partial class ColunaFotoEmUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Foto",
                table: "Usuario",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AvaliacaoId",
                table: "Curtida",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Foto",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "AvaliacaoId",
                table: "Curtida");
        }
    }
}
