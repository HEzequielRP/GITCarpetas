using System;
using D11_Exceptions.Models;

namespace D11_Exceptions;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Adoptante ad1 = new Adoptante(1, "Juan", 19, 1000);
            Console.WriteLine("Adoptante creado correctament");
        }
        catch (EdadInvalidaException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch(PresupuestoInvalidoException ex)
        {
            Console.WriteLine ($"{ex.Message} Valor Intentando {ex.PresupuestoIntentado}");
        }
          try
        {
            Adoptante ad1 = new Adoptante(1, "Juan", 15, 1000);
            Console.WriteLine("Adoptante creado correctament");
        }
        catch (EdadInvalidaException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch(PresupuestoInvalidoException ex)
        {
            Console.WriteLine ($"{ex.Message} Valor Intentando {ex.PresupuestoIntentado}");
        }
          try
        {
            Adoptante ad1 = new Adoptante(1, "Juan", 19, -1000);
            Console.WriteLine("Adoptante creado correctament");
        }
        catch (EdadInvalidaException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch(PresupuestoInvalidoException ex)
        {
            Console.WriteLine ($"{ex.Message} Valor Intentando {ex.PresupuestoIntentado}");
        }
          try
        {
            Adoptante ad1 = new Adoptante(1, "Juan", 12, -1000);
            Console.WriteLine("Adoptante creado correctament");
        }
        catch (EdadInvalidaException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch(PresupuestoInvalidoException ex)
        {
            Console.WriteLine ($"{ex.Message} Valor Intentando {ex.PresupuestoIntentado}");
        }
        finally
        {
            Console.WriteLine("Validación concluida");
        }
    }
}
