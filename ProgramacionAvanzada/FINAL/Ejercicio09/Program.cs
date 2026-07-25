using Ejercicio09.Models;

namespace Ejercicio09;

class Program
{
    static void Main(string[] args)
    {
        SocioFamiliar familiar=new SocioFamiliar(1, "juan", 1000);
        SocioStandard standard=new SocioStandard(2, "Pedro", 1000);
        SocioPremium premium=new SocioPremium(3, "carlos",1000);
        List<Socio>socios=new List<Socio>();
        socios.Add(familiar);
        socios.Add(standard);
        socios.Add(premium);

        foreach(Socio s in socios)
        {
            Console.WriteLine(s.CalcularCuota());
        }

    }
}
