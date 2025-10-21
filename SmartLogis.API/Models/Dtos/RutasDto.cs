using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartLogis.API.Models.Dtos
{
    public class RutasDto
    {
        public int IdRuta { get; set; }
        public string CodigoRuta { get; set; } = string.Empty;
        public string Origen { get; set; } = string.Empty;
        public string Destino { get; set; } = string.Empty;
        public int DistanciaKm { get; set; }
        public int TiempoEstimadoHoras { get; set; }
        public int IdEstatus { get; set; }
        public required Estatus Estatus { get; set; }
        public ICollection<DetallesEnvio> DetallesEnvio { get; set; } = new List<DetallesEnvio>();
    }
}