using System;
using Ejercicio01V2.Models;

namespace Ejercicio01V2;

class Program
{
    static void Main(string[] args)
    {
        try
        {
        SocioGimnasio socio1 = new SocioGimnasio(1,"Juan Perez", 100);
        SocioGimnasio socio2 = new SocioGimnasio(2,"Maria Lopez", -200);
        SocioGimnasio socio3 = new SocioGimnasio(3,"Carlos Sanchez", 300);

        Console.WriteLine($"Socio: {socio1.Nombre}, Cuota Final: {socio1.CalcularCuotaFinal()}");
        Console.WriteLine($"Socio: {socio2.Nombre}, Cuota Final: {socio2.CalcularCuotaFinal()}");
        Console.WriteLine($"Socio: {socio3.Nombre}, Cuota Final: {socio3.CalcularCuotaFinal()}");   
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
