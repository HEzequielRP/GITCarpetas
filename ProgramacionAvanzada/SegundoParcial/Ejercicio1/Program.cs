using System.Collections.Generic;
using System.Linq;
using Ejercicio1;
using Ejercicio1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace Ejercicio1;

class Program
{
    static void Main(string[] args)
    {
        var context = new AdopcionDbContext();
        var gestionador = new Gestionador(context);

        Console.WriteLine("=== SISTEMA DE ADOPCIÓN DE ANIMALES ===");

        while (true)
        {
            Console.WriteLine("\n--- MENÚ PRINCIPAL ---");
            Console.WriteLine("1. Agregar Animal");
            Console.WriteLine("2. Agregar Dueño");
            Console.WriteLine("3. Adoptar Animal");
            Console.WriteLine("4. Mostrar Animales No Adoptados");
            Console.WriteLine("5. Mostrar Detalle de Animal");
            Console.WriteLine("6. Salir");
            Console.Write("Opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    gestionador.AgregarAnimal();
                    break;

                case "2":
                    gestionador.AgregarDueno();
                    break;

                case "3":
                    gestionador.AdoptarAnimal();
                    break;

                case "4":
                    gestionador.MostrarAnimalesNoAdoptados();
                    break;

                case "5":
                    gestionador.MostrarDetalleAnimal();
                    break;

                case "6":
                    Console.WriteLine("Saliendo...");
                    return;

                default:
                    Console.WriteLine("Opción inválida. Intente de nuevo.");
                    break;
            }
        }
    }
}