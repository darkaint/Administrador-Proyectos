using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Administrador_Proyectos.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        public string Apellido { get; set; }
        [Required]
        [Display(Name = "Tipo de documento")]
        public Tipo TipoDocumento { get; set; }
        [Required]
        [StringLength(50)]
        public string Documento { get; set; }
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        public ICollection<Ticket> Tickets { get; set; }
        public enum Tipo
        {
            Cedula,
            TarjetaIdentidad,
            Extranjeria,
        }

    }
}
