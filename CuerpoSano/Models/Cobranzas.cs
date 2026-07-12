using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CuerpoSano.Models;

namespace CuerpoSano.Models
{
    public class Cobranzas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime FechaCobranza { get; set; } = DateTime.Now;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }

        [MaxLength(50)]
        public string FormaPago { get; set; } = string.Empty;

        public int MiembroId { get; set; }

        [ForeignKey(nameof(MiembroId))]
        public virtual Miembro Miembro { get; set; }

        public void Registro()
        {
            Console.WriteLine("Registrando cobranza...");
        }

        public void ImpresionRecibo()
        {
            Console.WriteLine("Imprimiendo recibo...");
        }

        public void Consultas()
        {
            Console.WriteLine("Consultando cobranza...");
        }
    }
}