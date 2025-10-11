using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SmartLogis.API.Models
{
    public class Cliente
    {
        [Key]
        public int IdCliente { get; set; }
        [Required]
        public string Nombre { get; set; } = string.Empty;
        [Required]
        public string RFC { get; set; }= string.Empty;
        [Required]
        public string Direccion { get; set; } = string.Empty;
        [Required]
        public string Ciudad { get; set; } = string.Empty;
        [Required]
        public string Pais { get; set; }= string.Empty;
        public string Telefono { get; set; }= string.Empty;
        public string Email { get; set; } = string.Empty;
        public int IdCreationUser { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.Now;
        public int IdModificationUser { get; set; }
        public DateTime ModificationDate { get; set; }
        
        [Required]
        public int IdEstatus { get; set; }
        [ForeignKey("IdEstatus")]
        public required Estatus Estatus { get; set; }
    }
}