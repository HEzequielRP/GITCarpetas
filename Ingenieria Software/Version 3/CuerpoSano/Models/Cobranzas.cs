using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuerpoSano.Models
{
    public class Cobranzas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Monto { get; set; }

        public bool Pagado { get; set; }

        [MaxLength(50)]
        public string FormaPago { get; set; } = string.Empty;

        public int MiembroId { get; set; }

        [ForeignKey(nameof(MiembroId))]
        public virtual Miembro Miembro { get; set; } = null!;

        public void Registro()
        {
            Console.WriteLine("Registrando cobranza...");
        }

        public void ImpresionRecibo()
        {
            string nombreArchivo = $"Recibo_Cobranza_{Id}_{Fecha:yyyyMMdd}.txt";
            string rutaCompleta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, nombreArchivo);
            string contenido = $@"
                ==========================================
                        RECIBO DE PAGO - CUERPOSANO
                ==========================================
                ID Recibo: {Id}
                Fecha: {Fecha:dd/MM/yyyy}
                Monto: {Monto:C}
                Forma de Pago: {FormaPago}
                Estado: {(Pagado ? "PAGADO" : "PENDIENTE")}
                ------------------------------------------
                ¡Gracias por su pago!
                ==========================================
                Archivo guardado en: {rutaCompleta}";

            File.WriteAllText(rutaCompleta, contenido);

            Console.WriteLine(contenido);
        }

        public void Consultas()
        {
            Console.WriteLine("Consultando cobranza...");
        }
    }
}
