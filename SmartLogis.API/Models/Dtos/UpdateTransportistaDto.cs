using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartLogis.API.Models.Dtos;
public class UpdateTransportistaDto
{
    [Required(ErrorMessage = "El idTransportista es requerido")]
    public int IdTransportista { get; set; }
    [Required(ErrorMessage = "El idEstatus es requerido")]
    public int IdEstatus { get; set; }
    [Required(ErrorMessage = "El nombre es requerido")]
    public string Nombre { get; set; } = string.Empty;
    [Required(ErrorMessage = "El tipo unidad es requerido")]
    public string TipoUnidad { get; set; } = string.Empty;
    [Required(ErrorMessage = "Las placas son requeridas")]
    public string Placas { get; set; } = string.Empty;
    [Required(ErrorMessage = "El telefono es requerido")]
    [Phone(ErrorMessage = "El formato del teléfono no es válido")]
    [MaxLength(15, ErrorMessage = "El telefono no puede exceder los 15 caracteres")]
    public string Telefono { get; set; } = string.Empty;
    [Required(ErrorMessage = "El email es requerido")]
    [EmailAddress(ErrorMessage = "El formato del email no es válido")]
    [MaxLength(250, ErrorMessage = "El email no puede exceder los 250 caracteres")]
    public string Email { get; set; } = string.Empty;
}