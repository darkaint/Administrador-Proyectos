using Microsoft.EntityFrameworkCore.Migrations;

namespace Administrador_Proyectos.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Usuario_UsuarioID",
                table: "Ticket");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioID",
                table: "Ticket",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Usuario_UsuarioID",
                table: "Ticket",
                column: "UsuarioID",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_Usuario_UsuarioID",
                table: "Ticket");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioID",
                table: "Ticket",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_Usuario_UsuarioID",
                table: "Ticket",
                column: "UsuarioID",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
