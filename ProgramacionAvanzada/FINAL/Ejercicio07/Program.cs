using Ejercicio07.Models;

namespace Ejercicio07;

class Program
{
    static void Main(string[] args)
    {
        Adoptante adopt1;
        Adoptante adopt2;
        Adoptante adopt3;
        Adoptante adopt4;
        try
        {
            adopt1 = new Adoptante(1, "juan", -5000);
        }
        catch (PresupuestoInvalidoException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            adopt1=null;
        }
        try
        {
            adopt2 = new Adoptante(2, "Pedro", 2000);
        }
        catch (PresupuestoInvalidoException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            adopt2=null;
        }try
        {
            adopt3 = new Adoptante(3, "Tito", 5000);
        }
        catch (PresupuestoInvalidoException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            adopt3=null;
        }try
        {
            adopt4 = new Adoptante(4, "Pedro", 1000);
        }
        catch (PresupuestoInvalidoException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            adopt4=null;
        }
        Contenedor<Adoptante> contenedor1 = new Contenedor<Adoptante>();
        if (adopt1 !=null)
        {
            contenedor1.Valor=adopt1;
        }
         Contenedor<Adoptante> contenedor2 = new Contenedor<Adoptante>();
        if (adopt2 !=null)
        {
            contenedor2.Valor=adopt2;
        }
         Contenedor<Adoptante> contenedor3 = new Contenedor<Adoptante>();
        if (adopt3 !=null)
        {
            contenedor3.Valor=adopt3;
        }
         Contenedor<Adoptante> contenedor4 = new Contenedor<Adoptante>();
        if (adopt4 !=null)
        {
            contenedor4.Valor=adopt4;
        }
        contenedor2.SiguienteNodo=contenedor3;
        contenedor3.SiguienteNodo=contenedor4;

        Contenedor<Adoptante> actual=contenedor2;
        while (actual!=null)
        {
            Console.WriteLine($"ID {actual.Valor.Id}, Nombre {actual.Valor.Nombre}, Presupuesto {actual.Valor.Presupuesto}");
            actual=actual.SiguienteNodo;
        }
    }

}
