using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Administrador_Proyectos.Models;

namespace Administrador_Proyectos.Data
{
    public class Administrador_ProyectosContext : DbContext
    {
        public Administrador_ProyectosContext (DbContextOptions<Administrador_ProyectosContext> options)
            : base(options)
        {
        }

        public DbSet<Administrador_Proyectos.Models.Compañia> Compañia { get; set; }

        public DbSet<Administrador_Proyectos.Models.CompañiaUsuario> CompañiaUsuario { get; set; }

        public DbSet<Administrador_Proyectos.Models.HistoriaUsuario> HistoriaUsuario { get; set; }

        public DbSet<Administrador_Proyectos.Models.Proyecto> Proyecto { get; set; }

        public DbSet<Administrador_Proyectos.Models.Ticket> Ticket { get; set; }

        public DbSet<Administrador_Proyectos.Models.Usuario> Usuario { get; set; }
    }
}
