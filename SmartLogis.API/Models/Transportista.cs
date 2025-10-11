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
        public int IdTransportista { get; set; }
        [Required]
        public string Nombre { get; set; } = string.Empty;
        [Required]
        public string TipoUnidad { get; set; } = string.Empty;
        [Required]
        public string Placas { get; set; } = string.Empty;
        [Required]
        public string Telefono { get; set; } = string.Empty;
        [Required]
        public string Email { get; set; } = string.Empty;
        [Required]
        public int IdEstatus { get; set; }
        [ForeignKey("IdEstatus")]
        public required Estatus Estatus { get; set; }
    }
}