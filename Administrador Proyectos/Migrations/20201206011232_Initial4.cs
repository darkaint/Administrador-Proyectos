using Microsoft.EntityFrameworkCore.Migrations;

namespace Administrador_Proyectos.Migrations
{
    public partial class Initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompañiaUsuario_Compañia_CompañiaID",
                table: "CompañiaUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_CompañiaUsuario_Usuario_UsuarioID",
                table: "CompañiaUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoriaUsuario_Proyecto_ProyectoID",
                table: "HistoriaUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Proyecto_Compañia_CompañiaID",
                table: "Proyecto");

            migrationBuilder.DropForeignKey(
                name: "FK_Proyecto_Usuario_ResponsableID",
                table: "Proyecto");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_HistoriaUsuario_HistoriaUsuarioID",
                table: "Ticket");

            migrationBuilder.AddForeignKey(
                name: "FK_CompañiaUsuario_Compañia_CompañiaID",
                table: "CompañiaUsuario",
                column: "CompañiaID",
                principalTable: "Compañia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CompañiaUsuario_Usuario_UsuarioID",
                table: "CompañiaUsuario",
                column: "UsuarioID",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoriaUsuario_Proyecto_ProyectoID",
                table: "HistoriaUsuario",
                column: "ProyectoID",
                principalTable: "Proyecto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Proyecto_Compañia_CompañiaID",
                table: "Proyecto",
                column: "CompañiaID",
                principalTable: "Compañia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Proyecto_Usuario_ResponsableID",
                table: "Proyecto",
                column: "ResponsableID",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_HistoriaUsuario_HistoriaUsuarioID",
                table: "Ticket",
                column: "HistoriaUsuarioID",
                principalTable: "HistoriaUsuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CompañiaUsuario_Compañia_CompañiaID",
                table: "CompañiaUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_CompañiaUsuario_Usuario_UsuarioID",
                table: "CompañiaUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_HistoriaUsuario_Proyecto_ProyectoID",
                table: "HistoriaUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_Proyecto_Compañia_CompañiaID",
                table: "Proyecto");

            migrationBuilder.DropForeignKey(
                name: "FK_Proyecto_Usuario_ResponsableID",
                table: "Proyecto");

            migrationBuilder.DropForeignKey(
                name: "FK_Ticket_HistoriaUsuario_HistoriaUsuarioID",
                table: "Ticket");

            migrationBuilder.AddForeignKey(
                name: "FK_CompañiaUsuario_Compañia_CompañiaID",
                table: "CompañiaUsuario",
                column: "CompañiaID",
                principalTable: "Compañia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CompañiaUsuario_Usuario_UsuarioID",
                table: "CompañiaUsuario",
                column: "UsuarioID",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HistoriaUsuario_Proyecto_ProyectoID",
                table: "HistoriaUsuario",
                column: "ProyectoID",
                principalTable: "Proyecto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Proyecto_Compañia_CompañiaID",
                table: "Proyecto",
                column: "CompañiaID",
                principalTable: "Compañia",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Proyecto_Usuario_ResponsableID",
                table: "Proyecto",
                column: "ResponsableID",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Ticket_HistoriaUsuario_HistoriaUsuarioID",
                table: "Ticket",
                column: "HistoriaUsuarioID",
                principalTable: "HistoriaUsuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
