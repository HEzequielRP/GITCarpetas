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
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [Range(0, double.MaxValue)]
        public double Precio { get; set; }

        [Required]
        [StringLength(100)]
        public string Publico { get; set; } = string.Empty;

        public void Altas()
        {
            Console.WriteLine($"Alta de membresía: {Nombre}");
        }

        public void Modificaciones()
        {
            Console.WriteLine($"Modificación de membresía: {Nombre}");
        }

        public void Bajas()
        {
            Console.WriteLine($"Baja de membresía: {Nombre}");
        }

        public void Consultas()
        {
            Console.WriteLine($"Consulta de membresía: {Nombre}, Precio: {Precio}, Público: {Publico}");
        }

        public void AplicarDescuentos(double porcentaje)
        {
            double descuento = Precio * (porcentaje / 100);
            Precio -= descuento;
            Console.WriteLine($"Descuento aplicado. Nuevo precio: {Precio}");
        }

        public void ImpresionCarnet()
        {
            Console.WriteLine($"Imprimiendo carnet de membresía: {Nombre}");
        }
    }
}