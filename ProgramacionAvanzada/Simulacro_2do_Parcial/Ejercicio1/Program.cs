using System;
using System.Dynamic;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;
using Ejercicio1;
using Microsoft.VisualBasic;

namespace Ejercicio1;

class Program
{
    static void Main(string[] args)
        {
        var context=new CarreraDbContext();
        var gestionador = new Gestionador(context);

         Console.WriteLine("=== SISTEMA DE GESTIÓN ACADÉMICA ===");

        while (true)  // Bucle para que el menú se repita hasta elegir Salir
        {
            Console.WriteLine("\n--- MENÚ PRINCIPAL ---");
            Console.WriteLine("1. Agregar Carrera");
            Console.WriteLine("2. Listar Carreras");
            Console.WriteLine("3. Agregar Estudiante");
            Console.WriteLine("4. Eliminar Estudiante");
            Console.WriteLine("5. Salir");
            Console.Write("Opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    gestionador.AgregarCarrera();
                    break;

                case "2":
                    gestionador.Listar();
                    break;

                case "3":
                    gestionador.AgregarEstudiante();
                    break;

                case "4":
                    gestionador.Eliminar();
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
    
