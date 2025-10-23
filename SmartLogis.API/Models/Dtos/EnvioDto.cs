using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartLogis.API.Models.Dtos
{
    public class EnvioDto
    {
        public int IdEnvio { get; set; }
        public int IdEstatus { get; set; }
        public int IdCliente { get; set; }
        public string NumeroGuia { get; set; } = string.Empty;
        public string Origen { get; set; } = string.Empty;
        public string Destino { get; set; } = string.Empty;
        public decimal Peso { get; set; }
        public decimal Volumen { get; set; }
        public string TipoEnvio { get; set; } = string.Empty;
        public DateTime FechaSalida { get; set; }
        public DateTime FechaEntregaEstimada { get; set; }
        public string Observaciones { get; set; } = string.Empty;

        public Cliente Cliente { get; set; }
        public ICollection<DetallesEnvio> DetallesEnvio { get; set; } = new List<DetallesEnvio>();
        public ICollection<EstatusEnvio> EstatusEnvios { get; set; } = new List<EstatusEnvio>();
    }
}