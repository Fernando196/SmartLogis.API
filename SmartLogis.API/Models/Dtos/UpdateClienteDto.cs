using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartLogis.API.Models.Dtos
{
    public class UpdateClienteDto
    {
        public int IdEstatus { get; set; }

        [MaxLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres")]
        public string Nombre { get; set; } = string.Empty;

        [MaxLength(13, ErrorMessage = "El RFC no puede exceder los 13 caracteres")]
        public string RFC { get; set; } = string.Empty;

        [MaxLength(250,ErrorMessage = "La direccion no puede exceder los 250 caracteres")]
        public string Direccion { get; set; } = string.Empty;

        [MaxLength(250, ErrorMessage = "La ciudad no puede")]
        public string Ciudad { get; set; } = string.Empty;

        [MaxLength(120,ErrorMessage = "El pais no puede exceder los 120 caracteres")]
        public string Pais { get; set; } = string.Empty;

        [MaxLength(12, ErrorMessage = "El telefono no puede exceder los 12 caracteres")]
        public string Telefono { get; set; } = string.Empty;
        
        [MaxLength(250, ErrorMessage = "El email no puede exceder los 250 caracteres")]
        public string Email { get; set; } = string.Empty;
    }
}