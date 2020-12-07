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
        [Display(Name = "Fecha de Asignacion")]
        [DataType(DataType.Date)]
        public DateTime FechaAsignacion { get; set; }
    }
}
