using System;
using Ejercicio04.Models;
using Models;
namespace Ejercicio04;

class Program
{
    static void Main(string[] args)
    {
        SocioGimnasio socio = new SocioGimnasio(1, "Juan",2000);
        IControlable controlable = socio;
        bool esValido = controlable.Validar();

        Console.WriteLine ($"Esvalido?:{esValido}");

        SocioGimnasio socio2 = new SocioGimnasio(2, "", 1);
        IControlable controlable2 = socio2;
        bool esValido2 = controlable2.Validar();

        Console.WriteLine ($"Esvalido?:{esValido2}");


        
    }
}
