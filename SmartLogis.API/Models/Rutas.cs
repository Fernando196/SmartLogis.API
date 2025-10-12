using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartLogis.API.Models
{
    public class Rutas
    {
        [Key]
        public int IdRuta { get; set; }
        public string CodigoRuta { get; set; } = string.Empty;
        public string Origen { get; set; } = string.Empty;
        public string Destino { get; set; } = string.Empty;
        public int DistanciaKm { get; set; }
        public TimeSpan TiempoEstimadoHoras { get; set; }
        public int IdEstatus { get; set; }
        [ForeignKey("IdEstatus")]
        public required Estatus Estatus { get; set; }
        public ICollection<DetallesEnvio> DetallesEnvio { get; set; } = new List<DetallesEnvio>();

    }
}