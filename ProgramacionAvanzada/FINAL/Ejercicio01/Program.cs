using System;
using Ejercicio01.Models;
namespace Ejercicio01;

class Program
{
    static void Main(string[] args)
    {
        SocioGimnasio socio1 = new SocioGimnasio("Juan Perez", 12345, 100.0);
        Console.WriteLine($"Socio: {socio1._nombre}, Número de Socio: {socio1._numeroSocio}, Cuota Final: {socio1.CalcularCuotaFinal()}");
    }
}
