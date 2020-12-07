using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Administrador_Proyectos.Models
{
    public class HistoriaUsuario
    {
        public int Id { get; set; }
        public int ProyectoID { get; set; }
        public Proyecto Proyecto { get; set; }
        [Required]
        [StringLength(50)]        
        public string Titulo { get; set; }
        [Required]
        [StringLength(150)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        ICollection<Ticket> Tickets { get; set; }
    }
}
