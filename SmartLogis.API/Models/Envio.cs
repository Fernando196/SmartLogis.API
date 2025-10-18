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
        [Column("idEnvio")]
        public int IdEnvio { get; set; }
        [Required]
        [Column("idEstatus")]
        public int IdEstatus { get; set; }
        [Column("idCliente")]
        public int IdCliente { get; set; }
        [Column("numeroGuia")]
        [MaxLength(50)]
        public string NumeroGuia { get; set; } = string.Empty;
        [Column("origen")]
        [MaxLength(250)]
        public string Origen { get; set; } = string.Empty;
        [Column("destino")]
        [MaxLength(500)]
        public string Destino { get; set; } = string.Empty;
        [Range(0, double.MaxValue)]
        [Column("peso", TypeName = "decimal(18,2)")]
        public decimal Peso { get; set; }
        [Range(0, double.MaxValue)]
        [Column("volumen",TypeName = "decimal(18,2)")]
        public decimal Volumen { get; set; }
        [Column("tipoEnvio")]
        [MaxLength(250)]
        public string TipoEnvio { get; set; } = string.Empty;
        [Column("fechaSalida")]
        public DateTime? FechaSalida { get; set; }
        [Column("fechaEntregaEstimada")]
        public DateTime? FechaEntregaEstimada { get; set; }
        [Column("observaciones")]
        [MaxLength(600)]
        public string? Observaciones { get; set; } = string.Empty;

        [ForeignKey("IdCliente")]
        public required Cliente Cliente { get; set; }

        public ICollection<DetallesEnvio> DetallesEnvio { get; set; } = new List<DetallesEnvio>();
        public ICollection<EstatusEnvio> EstatusEnvios { get; set; } = new List<EstatusEnvio>();
    }
}