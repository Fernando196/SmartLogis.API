using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartLogis.API.Models
{
    public class Envio
    {
        [Key]
        public int IdEnvio { get; set; }
        public string NumeroGuia { get; set; } = string.Empty;
        public string Origen { get; set; } = string.Empty;
        public string Destino { get; set; } = string.Empty;
        [Range(0, double.MaxValue)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Peso { get; set; }
        [Range(0, double.MaxValue)]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Volumen { get; set; }
        public int TipoEnvio { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaEntregaEstimada { get; set; }
        public string Observaciones { get; set; } = string.Empty;

        [Required]
        public int IdEstatus { get; set; }
        [ForeignKey("IdEstatus")]
        public required EstatusEnvio Estatus { get; set; }
        public int IdCliente { get; set; }
        [ForeignKey("IdCliente")]
        public required Cliente Cliente { get; set; }
    }
}