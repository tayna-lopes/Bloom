using Microsoft.EntityFrameworkCore.Migrations;

namespace Bloom.DAO.Migrations
{
    public partial class AmizadeModificada : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Amizade_ConvidadoId",
                table: "Amizade",
                column: "ConvidadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Amizade_ConvidanteId",
                table: "Amizade",
                column: "ConvidanteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Amizade_Usuario_ConvidadoId",
                table: "Amizade",
                column: "ConvidadoId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Amizade_Usuario_ConvidanteId",
                table: "Amizade",
                column: "ConvidanteId",
                principalTable: "Usuario",
                principalColumn: "UsuarioId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amizade_Usuario_ConvidadoId",
                table: "Amizade");

            migrationBuilder.DropForeignKey(
                name: "FK_Amizade_Usuario_ConvidanteId",
                table: "Amizade");

            migrationBuilder.DropIndex(
                name: "IX_Amizade_ConvidadoId",
                table: "Amizade");

            migrationBuilder.DropIndex(
                name: "IX_Amizade_ConvidanteId",
                table: "Amizade");
        }
    }
}
