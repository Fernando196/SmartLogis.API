using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartLogis.API.Models.Dtos
{
    public class ClienteDto
    {
        public int IdCliente { get; set; }
        public int IdEstatus { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public string RFC { get; set; }= string.Empty;
        public string Direccion { get; set; } = string.Empty;
        public string Ciudad { get; set; } = string.Empty;
        public string Pais { get; set; }= string.Empty;
        public string Telefono { get; set; }= string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public DateTime ModificationDate { get; set; }

        public required Estatus Estatus { get; set; }
        public ICollection<Envio> Envios { get; set; } = new List<Envio>();
    }
}