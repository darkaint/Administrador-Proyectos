using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Administrador_Proyectos.Models
{
    public class CompañiaUsuario
    {
        public int Id { get; set; }
        public int CompañiaID { get; set; }
        public int UsuarioID { get; set; }
        public Compañia Compañia { get; set; }
        public Usuario Usuario { get; set; }
        [StringLength(50)]
        [Display(Name = "Correo Electronico")]
        public DateTime FechaAsignacion { get; set; }
    }
}
