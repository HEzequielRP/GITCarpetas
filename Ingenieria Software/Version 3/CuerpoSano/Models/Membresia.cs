using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CuerpoSano.Models
{
    public class Membresia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Precio { get; set; }

        [Required]
        public int DuracionDias { get; set; }

        [MaxLength(100)]
        public string Publico { get; set; } = string.Empty;

        public void Altas()
        {
            Console.WriteLine($"Alta de membresia: {Nombre}");
        }

        public void Modificaciones()
        {
            Console.WriteLine($"Modificacion de membresia: {Nombre}");
        }

        public void Bajas()
        {
            Console.WriteLine($"Baja de membresia: {Nombre}");
        }

        public void Consultas()
        {
            Console.WriteLine($"Consulta de membresia: {Nombre}, Precio: {Precio}, Publico: {Publico}");
        }

        public void AplicarDescuentos(double porcentaje)
        {
            decimal descuento = Precio * (decimal)(porcentaje / 100);
            Precio -= descuento;
            Console.WriteLine($"Descuento aplicado. Nuevo precio: {Precio}");
        }

        public void ImpresionCarnet()
        {
            Console.WriteLine($"Imprimiendo carnet de membresia: {Nombre}");
        }
    }
}
