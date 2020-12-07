using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Administrador_Proyectos.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Compañia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    NIT = table.Column<string>(maxLength: 50, nullable: false),
                    Direccion = table.Column<string>(maxLength: 50, nullable: false),
                    CorreoElectronico = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Compañia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(maxLength: 50, nullable: false),
                    TipoDocumento = table.Column<int>(nullable: false),
                    Documento = table.Column<string>(maxLength: 50, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompañiaUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompañiaID = table.Column<int>(nullable: false),
                    UsuarioID = table.Column<int>(nullable: false),
                    FechaAsignacion = table.Column<DateTime>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompañiaUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CompañiaUsuario_Compañia_CompañiaID",
                        column: x => x.CompañiaID,
                        principalTable: "Compañia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CompañiaUsuario_Usuario_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Proyecto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ResponsableID = table.Column<int>(nullable: false),
                    CompañiaID = table.Column<int>(nullable: false),
                    PorcentajeCumplimiento = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proyecto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Proyecto_Compañia_CompañiaID",
                        column: x => x.CompañiaID,
                        principalTable: "Compañia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Proyecto_Usuario_ResponsableID",
                        column: x => x.ResponsableID,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HistoriaUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProyectoID = table.Column<int>(nullable: false),
                    Titulo = table.Column<string>(maxLength: 50, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 150, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoriaUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HistoriaUsuario_Proyecto_ProyectoID",
                        column: x => x.ProyectoID,
                        principalTable: "Proyecto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ticket",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UsuarioID = table.Column<int>(nullable: false),
                    HistoriaUsuarioID = table.Column<int>(nullable: false),
                    Comentarios = table.Column<string>(maxLength: 150, nullable: true),
                    EstadoTicket = table.Column<int>(nullable: false),
                    IsCancelado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ticket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ticket_HistoriaUsuario_HistoriaUsuarioID",
                        column: x => x.HistoriaUsuarioID,
                        principalTable: "HistoriaUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Ticket_Usuario_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CompañiaUsuario_CompañiaID",
                table: "CompañiaUsuario",
                column: "CompañiaID");

            migrationBuilder.CreateIndex(
                name: "IX_CompañiaUsuario_UsuarioID",
                table: "CompañiaUsuario",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_HistoriaUsuario_ProyectoID",
                table: "HistoriaUsuario",
                column: "ProyectoID");

            migrationBuilder.CreateIndex(
                name: "IX_Proyecto_CompañiaID",
                table: "Proyecto",
                column: "CompañiaID");

            migrationBuilder.CreateIndex(
                name: "IX_Proyecto_ResponsableID",
                table: "Proyecto",
                column: "ResponsableID");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_HistoriaUsuarioID",
                table: "Ticket",
                column: "HistoriaUsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Ticket_UsuarioID",
                table: "Ticket",
                column: "UsuarioID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CompañiaUsuario");

            migrationBuilder.DropTable(
                name: "Ticket");

            migrationBuilder.DropTable(
                name: "HistoriaUsuario");

            migrationBuilder.DropTable(
                name: "Proyecto");

            migrationBuilder.DropTable(
                name: "Compañia");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
