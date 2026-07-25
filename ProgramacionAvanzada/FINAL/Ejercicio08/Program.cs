using System.Data.Common;

namespace Ejercicio08;

class Program
{
    static void Main(string[] args)
    {
        Adoptante adopt1 = new Adoptante();
        adopt1.Id=1;
        adopt1.Nombre="Juan";
        adopt1.Presupuesto=3000;
        Adoptante adopt2 = new Adoptante();
        adopt2.Id=2;
        adopt2.Nombre="Pedro";
        adopt2.Presupuesto=5000;

       Adoptante grupo = adopt1+adopt2;
        Console.WriteLine ($"Id {grupo.Id}, Nombre {grupo.Nombre}, Presupuesto {grupo.Presupuesto}");
       if(adopt1>adopt2)
        {
            Console.WriteLine("El adoptante 1 es mayor que el 2");
        }
        else
        {
            Console.WriteLine("El adoptante 2 es mayor que el 1");
        }


    }
}
