using System;
using System.Collections.Generic;
using Ejercicio02.Models;
namespace Ejercicio02;

class Program
{
    static void Main(string[] args)
    {
        List<Animal> animales;
        animales = new List<Animal>();
        Perro perro1 = new Perro();
        perro1.Nombre = "Bobie";
        perro1.Edad = 2;

        Gato gato1 = new Gato();
        gato1.Nombre = "Jaime";
        gato1.Edad = 4;

        animales.Add(perro1);
        animales.Add(gato1);

        foreach (Animal a in animales)
        {
            Console.WriteLine($"Nombre: {a.Nombre}, Edad: {a.Edad}, Sonido: {a.EmitirSonido()}");
        }
    }
}
