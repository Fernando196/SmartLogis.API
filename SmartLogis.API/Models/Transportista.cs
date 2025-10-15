using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartLogis.API.Models
{
    public class Transportista
    {
        [Key]
        [Column("idTransportista")]
        public int IdTransportista { get; set; }
        [Required]
        public int IdEstatus { get; set; }
        [Required]
        [Column("nombre")]
        [MaxLength(150)]
        public string Nombre { get; set; } = string.Empty;
        [Required]
        [Column("tipoUnidad")]
        [MaxLength(150)]
        public string TipoUnidad { get; set; } = string.Empty;
        [Required]
        [Column("placas")]
        [MaxLength(30)]
        public string Placas { get; set; } = string.Empty;
        [Required]
        [Column("telefono")]
        [MaxLength(20)]
        public string Telefono { get; set; } = string.Empty;
        [Required]
        [Column("email")]
        [MaxLength(150)]
        public string Email { get; set; } = string.Empty;

        [ForeignKey("IdEstatus")]
        public required Estatus Estatus { get; set; }

        public ICollection<DetallesEnvio> DetallesEnvio { get; set; } = new List<DetallesEnvio>();
    }
}