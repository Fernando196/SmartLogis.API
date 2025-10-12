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
        [Column("idUsuario")]
        [Key]
        public int IdCliente { get; set; }
        [Column("idEstatus")]
        [Required]
        public int IdEstatus { get; set; }
        [Column("nombre")]
        [Required]
        public string Nombre { get; set; } = string.Empty;
        [Required]
        [Column("rfc")]
        public string RFC { get; set; }= string.Empty;
        [Required]
        [Column("direccion")]
        public string Direccion { get; set; } = string.Empty;
        [Required]
        [Column("ciudad")]
        public string Ciudad { get; set; } = string.Empty;
        [Required]
        [Column("pais")]
        public string Pais { get; set; }= string.Empty;
        [Column("telefono")]
        public string Telefono { get; set; }= string.Empty;
        [Column("email")]
        public string Email { get; set; } = string.Empty;
        [Column("idCreationUser")]
        public int IdCreationUser { get; set; }
        [Column("creationDate")]
        public DateTime CreationDate { get; set; } = DateTime.Now;
        [Column("idModificationUser")]
        public int IdModificationUser { get; set; }
        [Column("modificationDate")]
        public DateTime ModificationDate { get; set; }


        [ForeignKey("IdEstatus")]
        public required Estatus Estatus { get; set; }
        public ICollection<Envio> Envios { get; set; } = new List<Envio>();
    }
}