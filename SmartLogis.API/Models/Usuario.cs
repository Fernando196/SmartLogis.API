using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartLogis.API.Models
{
    public class Usuario
    {
        [Key]
        [Column("idUsuario")]
        public int IdUsuario { get; set; }
        [Column("nombre")]
        [MaxLength(150)]
        public string Nombre { get; set; } = string.Empty;
        [Column("email")]
        [MaxLength(150)]
        public string Email { get; set; } = string.Empty;
        [Column("password")]
        [MaxLength(500)]
        public string Password { get; set; } = string.Empty;
        [Column("rol")]
        [MaxLength(50)]
        public string Rol { get; set; } = string.Empty;
        [Column("creationDate")]
        public DateTime CreationDate { get; set; } = DateTime.Now;
        [Column("activo")]
        public bool Activo { get; set; } = true;
        public ICollection<Bitacora> Bitacora { get; set; } = new List<Bitacora>();
    }
}