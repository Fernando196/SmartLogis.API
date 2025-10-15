using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartLogis.API.Models.Dtos
{
    public class EstatusDto
    {
        public int IdEstatus { get; set; }
        public string Nombre { get; set; } = string.Empty;
    }
}