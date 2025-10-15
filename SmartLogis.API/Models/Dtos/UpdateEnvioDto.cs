using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartLogis.API.Models.Dtos
{
    public class UpdateEnvioDto
    {
        [Required(ErrorMessage = "El idEstatus es requerido")]
        public int IdEstatus { get; set; }

        [Required(ErrorMessage = "El idCliente es requerido")]
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "El numeroGuia es requerido")]
        public string NumeroGuia { get; set; } = string.Empty;

        [Required(ErrorMessage = "El origen es requerido")]
        public string Origen { get; set; } = string.Empty;

        [Required(ErrorMessage = "El destino es requerido")]
        public string Destino { get; set; } = string.Empty;

        [Required(ErrorMessage = "El peso es requerido")]
        public decimal Peso { get; set; }

        [Required(ErrorMessage = "El volumen es requerido")]
        public decimal Volumen { get; set; }

        [Required(ErrorMessage = "El tipo envio es requerido")]
        public string TipoEnvio { get; set; } = string.Empty;

        public DateTime? FechaSalida { get; set; }

        public DateTime? FechaEntregaEstimada { get; set; }

        public string? Observaciones { get; set; } = string.Empty;
    }
}