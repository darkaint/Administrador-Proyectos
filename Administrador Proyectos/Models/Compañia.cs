using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Administrador_Proyectos.Models
{
    public class Compañia
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        public string NIT { get; set; }
        [Required]
        [StringLength(50)]
        public string Direccion { get; set; }        
        [StringLength(50)]
        [Display(Name = "Correo Electronico")]
        [EmailAddress]
        public string CorreoElectronico { get; set; }
        public ICollection<Proyecto> Proyectos { get; set; }
    }
}
