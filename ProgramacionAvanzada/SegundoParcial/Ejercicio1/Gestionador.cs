using System.Collections.Generic;
using System.Linq;
using Ejercicio1;
using Ejercicio1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Sqlite;

namespace Ejercicio1;

public class Gestionador
{
    private AdopcionDbContext _context;

    public Gestionador(AdopcionDbContext context)
    {
        _context = context;
    }

    public void AgregarAnimal()
    {
        var nuevoAnimal = new Animal();

        Console.WriteLine("Ingrese nombre del animal");
        string nuevoNombre = Console.ReadLine();
        
        Console.WriteLine("Ingrese especie");
        string nuevaEspecie = Console.ReadLine();
        
        Console.WriteLine("Ingrese edad");
        int nuevaEdad = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Ingrese peso");
        float nuevoPeso = float.Parse(Console.ReadLine());

        nuevoAnimal.Nombre = nuevoNombre;
        nuevoAnimal.Especie = nuevaEspecie;
        nuevoAnimal.Edad = nuevaEdad;
        nuevoAnimal.Peso = nuevoPeso;

        _context.Animales.Add(nuevoAnimal);
        _context.SaveChanges();
    }

    public void AgregarDueno()
    {
        var nuevoDueno = new Dueno();

        Console.WriteLine("Ingrese nombre del dueño");
        string nuevoNombre = Console.ReadLine();
        
        Console.WriteLine("Ingrese apellido");
        string nuevoApellido = Console.ReadLine();
        
        Console.WriteLine("Ingrese teléfono");
        string nuevoTelefono = Console.ReadLine();

        nuevoDueno.Nombre = nuevoNombre;
        nuevoDueno.Apellido = nuevoApellido;
        nuevoDueno.Telefono = nuevoTelefono;

        _context.Duenos.Add(nuevoDueno);
        _context.SaveChanges();
    }

    public void AdoptarAnimal()
    {
        Console.WriteLine("Ingrese ID del animal");
        int animalId = int.Parse(Console.ReadLine());
        
        Console.WriteLine("Ingrese ID del dueño");
        int duenoId = int.Parse(Console.ReadLine());

        var animal = _context.Animales.FirstOrDefault(a => a.AnimalId == animalId);
        
        if (animal != null)
        {
            animal.DuenoId = duenoId;
            _context.SaveChanges();
        }
        else
        {
            Console.WriteLine("Animal no encontrado");
        }
    }

    public void MostrarAnimalesNoAdoptados()
    {
        var animales = _context.Animales.Where(a => a.DuenoId == null).ToList();
        
        foreach (var animal in animales)
        {
            Console.WriteLine($"{animal.AnimalId} - {animal.Nombre} - {animal.Especie} - {animal.Edad} años - {animal.Peso} kg");
        }
    }

    public void MostrarDetalleAnimal()
    {
        Console.WriteLine("Ingrese ID del animal");
        int animalId = int.Parse(Console.ReadLine());

        var animal = _context.Animales.Include(a => a.Dueno).FirstOrDefault(a => a.AnimalId == animalId);
        
        if (animal != null)
        {
            Console.WriteLine($"{animal.AnimalId} - {animal.Nombre} - {animal.Especie} - {animal.Edad} años - {animal.Peso} kg");
            
            if (animal.Dueno != null)
            {
                Console.WriteLine($"Dueño: {animal.Dueno.Nombre} {animal.Dueno.Apellido} - Tel: {animal.Dueno.Telefono}");
            }
            else
            {
                Console.WriteLine("Dueño: No adoptado");
            }
        }
        else
        {
            Console.WriteLine("Animal no encontrado");
        }
    }
}