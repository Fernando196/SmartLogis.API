using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartLogis.API.Models.Dtos;
public class CreateDetalleEnvioDto
{
    [Required(ErrorMessage = "El idEnvio es requerido")]
    public int IdEnvio { get; set; }
    [Required(ErrorMessage = "El IdTransportista es requerido")]
    public int IdTransportista { get; set; }
    [Required(ErrorMessage = "El IdRuta es requerido")]
    public int IdRuta { get; set; }
    [Required(ErrorMessage = "El idEstatus es requerido")]
    public int IdEstatus { get; set; }
    [Required(ErrorMessage = "El DescripcionCarga es requerido")]
    public string? DescripcionCarga { get; set; } = string.Empty;
    [Required(ErrorMessage = "El Cantidad es requerido")]
    [MinLength(0,ErrorMessage = "La cantidad no puede de 0" )]
    public int Cantidad { get; set; }
    [Required(ErrorMessage = "El Peso es requerido")]
    [MinLength(0,ErrorMessage = "El no puede de 0" )]
    public decimal Peso { get; set; }
}