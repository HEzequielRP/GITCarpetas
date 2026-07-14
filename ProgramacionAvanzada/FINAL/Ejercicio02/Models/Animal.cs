using System;
namespace Ejercicio02.Models;

public abstract class Animal
{
    public string Nombre {get; set;}
    public int Edad {get; set;}
    public abstract string EmitirSonido();
}