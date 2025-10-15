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
        [Column("idEstatus")]
        public int IdEstatus { get; set; }
        [Column("idEnvio")]
        public int IdEnvio { get; set; }
        [Column("fechaHora")]
        public DateTime FechaHora { get; set; }
        [Column("ubicacion")]
        public string Ubicacion { get; set; } = string.Empty;
        [Column("comentario")]
        public string Comentario { get; set; } = string.Empty;

        [ForeignKey("idEnvio")]
        public required Envio Envio { get; set; }
    }
}