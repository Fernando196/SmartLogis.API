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
        public string Nombre { get; set; } = string.Empty;
        [Required]
        [Column("tipoUnidad")]
        public string TipoUnidad { get; set; } = string.Empty;
        [Required]
        [Column("placas")]
        public string Placas { get; set; } = string.Empty;
        [Required]
        [Column("telefono")]
        public string Telefono { get; set; } = string.Empty;
        [Required]
        [Column("email")]
        public string Email { get; set; } = string.Empty;

        [ForeignKey("IdEstatus")]
        public required Estatus Estatus { get; set; }

        public ICollection<DetallesEnvio> DetallesEnvio { get; set; } = new List<DetallesEnvio>();
    }
}