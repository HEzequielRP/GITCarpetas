using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuerpoSano.Models
{
    public abstract class Persona
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [MaxLength(50)]
        public string Apellido { get; set; } = string.Empty;

        [Required]
        [MaxLength(20)]
        public string TipoDocumento { get; set; } = string.Empty;

        [Required]
        public int NumeroDocumento { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

        [MaxLength(100)]
        public string? Email { get; set; }

        [Required]
        public long TelCelular { get; set; }

        [Required]
        [MaxLength(100)]
        public string Direccion { get; set; } = string.Empty;

        public bool Activo { get; set; } = true;

        public virtual ICollection<Clase> ListaClases { get; set; }

        protected Persona()
        {
            ListaClases = new HashSet<Clase>();
        }

        public abstract void Altas();
        public abstract void Modificaciones();
        public abstract void Bajas();
        public abstract void Consultas();
    }
}