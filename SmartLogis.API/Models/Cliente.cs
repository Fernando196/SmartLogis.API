using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
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
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;
        [Required]
        [Column("rfc")]
        [MaxLength(13)]
        public string RFC { get; set; }= string.Empty;
        [Required]
        [Column("direccion")]
        [MaxLength(250)]
        public string Direccion { get; set; } = string.Empty;
        [Required]
        [MaxLength(250)]
        [Column("ciudad")]
        public string Ciudad { get; set; } = string.Empty;
        [Required]
        [MaxLength(120)]
        [Column("pais")]
        public string Pais { get; set; }= string.Empty;
        [Column("telefono")]
        [MaxLength(12)]
        public string? Telefono { get; set; }= string.Empty;
        [Column("email")]
        [MaxLength(250)]
        public string? Email { get; set; } = string.Empty;
        [Column("idCreationUser")]
        public int IdCreationUser { get; set; }
        [Column("creationDate")]
        public DateTime CreationDate { get; set; } = DateTime.Now;
        [Column("idModificationUser")]
        public int? IdModificationUser { get; set; }
        [Column("modificationDate")]
        public DateTime? ModificationDate { get; set; }


        [ForeignKey("IdEstatus")]
        public required Estatus Estatus { get; set; }
        public ICollection<Envio> Envios { get; set; } = new List<Envio>();
    }
}