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
        [Column("idBitacora")]
        public int IdBitacora { get; set; }
        [Column("idUsuario")]
        public int IdUsuario { get; set; }
        [Column("fechaHora")]
        public DateTime FechaHora { get; set; }
        [Column("accion")]
        public string Accion { get; set; } = string.Empty;
        [Column("modulo")]
        public string Modulo { get; set; } = string.Empty;
        [Column("descripcion")]
        public string Descripcion { get; set; } = string.Empty;

        [ForeignKey("IdUsuario")]
        public required Usuario Usuario { get; set; }
    }
}