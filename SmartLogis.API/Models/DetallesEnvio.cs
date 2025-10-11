using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartLogis.API.Models
{
    public class DetallesEnvio
    {
        [Key]
        public int IdDetalle { get; set; }
        public int IdEnvio { get; set; }
        public int IdTransportista { get; set; }
        public int IdRuta { get; set; }
        public int IdEstatus { get; set; }
        public string DescripcionCarga { get; set; } = string.Empty;
        public int Cantidad { get; set; }
        [Range(0, double.MaxValue)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Peso { get; set; }

        [ForeignKey("IdEnvio")]
        public required Envio Envio { get; set; }
        [ForeignKey("IdTransportista")]
        public required Transportista Transportista { get; set; }
        [ForeignKey("IdRuta")]
        public required Rutas Rutas { get; set; }
        [ForeignKey("IdEstatus")]
        public required Estatus Estatus { get; set; }
    }
}