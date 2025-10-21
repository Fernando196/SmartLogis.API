using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartLogis.API.Models.Dtos
{
    public class CreateRutasDto
    {
        [Required(ErrorMessage = "El Origen es requerido")]
        public string Origen { get; set; } = string.Empty;
        [Required(ErrorMessage = "El Destino es requerido")]
        public string Destino { get; set; } = string.Empty;
        [Required(ErrorMessage = "El DistanciaKm es requerido")]
        public int DistanciaKm { get; set; }
        [Required(ErrorMessage = "El TiempoEstimadoHoras es requerido")]
        public int TiempoEstimadoHoras { get; set; }
        [Required(ErrorMessage = "El idEstatus es requerido")]
        public int IdEstatus { get; set; }
    }
}