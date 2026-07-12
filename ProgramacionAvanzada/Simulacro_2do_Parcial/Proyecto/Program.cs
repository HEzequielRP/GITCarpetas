using Proyecto.Models;

namespace Proyecto;

class Program
{
    static void Main(string[] args)
    {
        using var db = new ProyectoDbContext();
        var gestion = new Gestionador(db);
        string opcion ="";

        while (opcion!="6")
        {
             Console.WriteLine("\n1. Nuevo Proyecto\n2. Listar\n3. Asignar Consultor\n4. Buscar Especialidad\n5. Finalizar\n6. Salir");
            opcion = Console.ReadLine();

            switch(opcion)
            {
                case "1": 
                    gestion.AgregarProyecto();
                    break;
                case "2":
                    gestion.ListarProyectos();
                    break;
                case "3":
                    gestion.AsignarConsultor();
                    break;
                case "4":
                    gestion.BuscarConsultoresPorEspecialidad();
                    break;
                case "5":
                    gestion.FinalizarProyecto();
                    break;
                case "6":
                    Console.WriteLine("Finalizando");
                    break;

            }
        }
    }
}
