using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SmartLogis.API.Models
{
    public class Estatus
    {
        [Key]
        public int IdEstatus { get; set; }
        [Required]
        public string Nombre { get; set; } = string.Empty;
    }
}