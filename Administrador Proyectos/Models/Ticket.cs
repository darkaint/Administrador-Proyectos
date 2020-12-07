using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Administrador_Proyectos.Models
{
    public class Ticket
    {
        public int Id { get; set; }        
        //public int UsuarioID { get; set; }        
        public int HistoriaUsuarioID { get; set; }        
        public Usuario Usuario { get; set; }
        public HistoriaUsuario HistoriaUsuario { get; set; }        
        [StringLength(150)]
        public string Comentarios { get; set; }
        public Estado EstadoTicket { get; set; }
        public bool IsCancelado { get; set; }
        public enum Estado
        {
            Activo,
            EnProceso,
            Finalizado
        }
    }
}
