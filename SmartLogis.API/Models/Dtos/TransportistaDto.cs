using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartLogis.API.Models.Dtos;
public class TransportistaDto
{
    public int IdTransportista { get; set; }
    public int IdEstatus { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string TipoUnidad { get; set; } = string.Empty;
    public string Placas { get; set; } = string.Empty;
    public string Telefono { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public required Estatus Estatus { get; set; }

    public ICollection<DetallesEnvio> DetallesEnvio { get; set; } = new List<DetallesEnvio>();
}