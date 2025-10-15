using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartLogis.API.Models.Dtos
{
    public class CreateEstatusDto
    {
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(130, ErrorMessage = "El nombre no puede sobre pasar de 130 caracteres")]
        [MinLength(3, ErrorMessage = "El nombre no puede ser menor de 3 caracteres")]
        public string Nombre { get; set; } = string.Empty;
    }
}