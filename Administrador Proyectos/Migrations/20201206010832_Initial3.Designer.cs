﻿// <auto-generated />
using System;
using Administrador_Proyectos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Administrador_Proyectos.Migrations
{
    [DbContext(typeof(Administrador_ProyectosContext))]
    [Migration("20201206010832_Initial3")]
    partial class Initial3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Administrador_Proyectos.Models.Compañia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CorreoElectronico")
                        .HasMaxLength(50);

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("NIT")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Compañia");
                });

            modelBuilder.Entity("Administrador_Proyectos.Models.CompañiaUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompañiaID");

                    b.Property<DateTime>("FechaAsignacion")
                        .HasMaxLength(50);

                    b.Property<int>("UsuarioID");

                    b.HasKey("Id");

                    b.HasIndex("CompañiaID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("CompañiaUsuario");
                });

            modelBuilder.Entity("Administrador_Proyectos.Models.HistoriaUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(150);

                    b.Property<int>("ProyectoID");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("ProyectoID");

                    b.ToTable("HistoriaUsuario");
                });

            modelBuilder.Entity("Administrador_Proyectos.Models.Proyecto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CompañiaID");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("PorcentajeCumplimiento");

                    b.Property<int>("ResponsableID");

                    b.HasKey("Id");

                    b.HasIndex("CompañiaID");

                    b.HasIndex("ResponsableID");

                    b.ToTable("Proyecto");
                });

            modelBuilder.Entity("Administrador_Proyectos.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comentarios")
                        .HasMaxLength(150);

                    b.Property<int>("EstadoTicket");

                    b.Property<int>("HistoriaUsuarioID");

                    b.Property<bool>("IsCancelado");

                    b.Property<int?>("UsuarioID");

                    b.HasKey("Id");

                    b.HasIndex("HistoriaUsuarioID");

                    b.HasIndex("UsuarioID");

                    b.ToTable("Ticket");
                });

            modelBuilder.Entity("Administrador_Proyectos.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Documento")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("TipoDocumento");

                    b.HasKey("Id");

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("Administrador_Proyectos.Models.CompañiaUsuario", b =>
                {
                    b.HasOne("Administrador_Proyectos.Models.Compañia", "Compañia")
                        .WithMany()
                        .HasForeignKey("CompañiaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Administrador_Proyectos.Models.Usuario", "Usuario")
                        .WithMany()
                        .HasForeignKey("UsuarioID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Administrador_Proyectos.Models.HistoriaUsuario", b =>
                {
                    b.HasOne("Administrador_Proyectos.Models.Proyecto", "Proyecto")
                        .WithMany()
                        .HasForeignKey("ProyectoID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Administrador_Proyectos.Models.Proyecto", b =>
                {
                    b.HasOne("Administrador_Proyectos.Models.Compañia", "Compañia")
                        .WithMany("Proyectos")
                        .HasForeignKey("CompañiaID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Administrador_Proyectos.Models.Usuario", "Responsable")
                        .WithMany()
                        .HasForeignKey("ResponsableID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Administrador_Proyectos.Models.Ticket", b =>
                {
                    b.HasOne("Administrador_Proyectos.Models.HistoriaUsuario", "HistoriaUsuario")
                        .WithMany()
                        .HasForeignKey("HistoriaUsuarioID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Administrador_Proyectos.Models.Usuario", "Usuario")
                        .WithMany("Tickets")
                        .HasForeignKey("UsuarioID");
                });
#pragma warning restore 612, 618
        }
    }
}
