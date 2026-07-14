using System;
namespace Ejercicio02.Models;

public class Perro : Animal
{
    public override string EmitirSonido()
    {
        return "Guau";
    }
}