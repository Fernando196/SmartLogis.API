using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartLogis.API.Models
{
    public class EstatusEnvio
    {   
        [Key]
        public int IdEstatusEnvio { get; set; }
        public int IdEnvio { get; set; }
        public DateTime FechaHora { get; set; }
        public string Ubicacion { get; set; } = string.Empty;
        public string Comentario { get; set; } = string.Empty;

        [ForeignKey("IdEnvio")]
        public required Envio Envio { get; set; }
    }
}