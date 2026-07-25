using D12_Persistencia.Models;

namespace D12_Persistencia;

class Program
{
    static void Main(string[] args)
    {
        using(var context=new BibliotecaDbContext())
        {
        var gestionador = new Gestionador(context);

         Console.WriteLine("=== SISTEMA DE GESTIÓN DE BIBLIOTECA ===");

        while (true)  // Bucle para que el menú se repita hasta elegir Salir
        {
            Console.WriteLine("\n--- MENÚ PRINCIPAL ---");
            Console.WriteLine("1. Agregar Libro");
            Console.WriteLine("2. Agregar Autor");
            Console.WriteLine("3. Listar Libros");
            Console.WriteLine("4. Actualizar Titulo Libro");
            Console.WriteLine("5. Salir");
            Console.Write("Opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    gestionador.CrearLibro();
                    break;

                case "2":
                    gestionador.CrearAutor();
                    break;

                case "3":
                    gestionador.TraerLibrosAutor();
                    break;

                case "4":
                    gestionador.ActualizarLibro();
                    break;

                case "5":
                    Console.WriteLine("Saliendo...");
                    return;

                default:
                    Console.WriteLine("Opción inválida. Intente de nuevo.");
                    break;
            }
        }
        }
    }
}
