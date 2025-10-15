using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartLogis.API.Models
{
    public class Estatus
    {
        [Key]
        [Column("idEstatus")]
        public int IdEstatus { get; set; }
        [Required]
        [Column("nombre")]
        [MaxLength(130)]
        public string Nombre { get; set; } = string.Empty;
    }
}