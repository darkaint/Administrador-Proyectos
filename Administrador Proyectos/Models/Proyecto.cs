using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Administrador_Proyectos.Models
{
    public class Proyecto
    {
        public int Id { get; set; }
        public int ResponsableID { get; set; }
        public int CompañiaID { get; set; }
        public Usuario Responsable { get; set; }
        public Compañia Compañia { get; set; }
        [Required]
        [Display(Name = "Porcentaje de Cumplimiento")]
        public int PorcentajeCumplimiento { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        
    }
}
