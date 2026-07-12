using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuerpoSano.Models
{
    public class Clase
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Descripcion { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Horario { get; set; } = string.Empty;

        public int CupoMaximo { get; set; }

        public int ProfesorId { get; set; }

        [ForeignKey(nameof(ProfesorId))]
        public virtual Profesor Profesor { get; set; } = null!;

        public virtual ICollection<Miembro> Miembros { get; set; } = new HashSet<Miembro>();
    }
}