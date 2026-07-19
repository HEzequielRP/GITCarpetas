using System;
namespace Ejercicio06;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            SocioGimnasio socio1 = new SocioGimnasio(1, "Juan Perez",-2000);
        }
        catch (CuotaInvalidaException ex)
        {
            Console.WriteLine($"Error {ex.Message}");
        }
    }
}
