using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuerpoSano.Models
{
    public class Profesor : Persona
    {
        [MaxLength(50)]
        public string CodigoProfesor { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Especialidad { get; set; } = string.Empty;

        public byte[]? Certificado { get; set; }

        public virtual ICollection<Clase> Clases { get; set; } = new HashSet<Clase>();

        public override void Altas()
        {
            Console.WriteLine("Registrando nuevo profesor...");
        }

        public override void Modificaciones()
        {
            Console.WriteLine("Modificando datos del profesor...");
        }

        public override void Bajas()
        {
            Console.WriteLine("Eliminando profesor...");
        }

        public override void Consultas()
        {
            Console.WriteLine("Consultando datos del profesor...");
        }
    }
}
