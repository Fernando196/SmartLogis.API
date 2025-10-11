using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartLogis.API.Models
{
    public class Bitacora
    {
        [Key]
        public int IdBitacora { get; set; }
        public int IdUsuario { get; set; }
        public DateTime FechaHora { get; set; }
        public string Accion { get; set; } = string.Empty;
        public string Modulo { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;

        [ForeignKey("IdUsuario")]
        public required Usuario Usuario { get; set; }
    }
}