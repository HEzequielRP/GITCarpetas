using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuerpoSano.Models
{
    public class Miembro : Persona
    {
        [MaxLength(20)]
        public string CodigoAlumno { get; set; } = string.Empty;

        [MaxLength(20)]
        public string? Telefono { get; set; }

        public int MembresiaId { get; set; }

        [ForeignKey(nameof(MembresiaId))]
        public virtual Membresia Membresia { get; set; } = null!;

        public virtual ICollection<Cobranzas> Cobranzas { get; set; } = new HashSet<Cobranzas>();
        
        public virtual ICollection<Clase> ListaClases { get; set; } = new HashSet<Clase>();
        
        public override void Altas()
        {
            Console.WriteLine("Registrando nuevo miembro...");
        }

        public override void Modificaciones()
        {
            Console.WriteLine("Modificando datos del miembro...");
        }

        public override void Bajas()
        {
            Console.WriteLine("Eliminando miembro...");
        }

        public override void Consultas()
        {
            Console.WriteLine("Consultando datos del miembro...");
        }
    }
}
